using System;
using System.Threading.Tasks;
using TheLuxe.Model.User;

namespace TheLuxe.API.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string UserName, string Password, string FullName, bool IsAdmin,
            bool? IsActive, int CreatedBy, DateTime CreatedDateTime, bool CanGiveDiscount, int UserTypeID, string MobilePassword);
        Task AddUserAsync(string UserName, string Password, string FullName, bool IsAdmin,
            bool? IsActive, int CreatedBy, bool CanGiveDiscount, int UserTypeID, string MobilePassword);
        Task<AuthenticationResult> LoginAsync(string UserName, string Password);
    }
}
