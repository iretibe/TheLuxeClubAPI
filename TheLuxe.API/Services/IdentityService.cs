using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TheLuxe.API.Options;
using TheLuxe.Data;
using TheLuxe.Model;
using TheLuxe.Model.User;

namespace TheLuxe.API.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly TheLuxeClubContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(TheLuxeClubContext context, UserManager<ApplicationUser> userManager, JwtSettings jwtSettings)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task AddUserAsync(string UserName, string Password, string FullName, 
            bool IsAdmin, bool? IsActive, int CreatedBy, bool CanGiveDiscount, int UserTypeID, string MobilePassword)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertUser";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@UserName", UserName));
                cmdObj.Parameters.Add(new SqlParameter("@Password", Password));
                cmdObj.Parameters.Add(new SqlParameter("@FullName", FullName));
                cmdObj.Parameters.Add(new SqlParameter("@IsAdmin", IsAdmin));
                cmdObj.Parameters.Add(new SqlParameter("@IsActive", IsActive));
                cmdObj.Parameters.Add(new SqlParameter("@CreatedBy", CreatedBy));
                cmdObj.Parameters.Add(new SqlParameter("@CanGiveDiscount", CanGiveDiscount));
                cmdObj.Parameters.Add(new SqlParameter("@UserTypeID", UserTypeID));
                cmdObj.Parameters.Add(new SqlParameter("@MobilePassword", MobilePassword));
                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<AuthenticationResult> LoginAsync(string UserName, string Password)
        {
            var user = await _userManager.FindByNameAsync(UserName);

            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[]
                    {
                        "User does not exists"
                    }
                };
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, Password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[]
                    {
                        "Username or Password is wrong"
                    }
                };
            }

            return GenerateAuthenticationResultForUser(user);
        }

        public async Task<AuthenticationResult> RegisterAsync(string UserName, string Password, string FullName, bool IsAdmin,
            bool? IsActive, int CreatedBy, DateTime CreatedDateTime, bool CanGiveDiscount, int UserTypeID, string MobilePassword)
        {
            var existingUser = await _userManager.FindByNameAsync(UserName);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[]
                    {
                        "User with this name already exists"
                    }
                };
            }

            var newUser = new ApplicationUser
            {
                UserName = UserName,
                FullName = FullName,
                IsAdmin = IsAdmin,
                IsActive = IsActive,
                CreatedBy = CreatedBy,
                CreatedDateTime = DateTime.UtcNow,
                CanGiveDiscount = CanGiveDiscount,
                UserTypeID = UserTypeID,
                MobilePassword = MobilePassword
            };

            var createdUser = await _userManager.CreateAsync(newUser, Password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            await AddUserAsync(UserName, Password, FullName, IsAdmin, IsActive,CreatedBy, CanGiveDiscount, UserTypeID, MobilePassword);

            return GenerateAuthenticationResultForUser(newUser);
        }

        private AuthenticationResult GenerateAuthenticationResultForUser(ApplicationUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, newUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.UserName),
                    new Claim("id", newUser.UserID.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
