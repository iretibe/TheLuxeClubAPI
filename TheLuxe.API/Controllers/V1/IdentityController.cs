using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TheLuxe.API.Services;
using TheLuxe.Model.User;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityRepo;

        public IdentityController(IIdentityService identityRepo)
        {
            _identityRepo = identityRepo;
        }

        [HttpPost("PostUserRegistration")]
        public async Task<IActionResult> PostUserRegistration([FromBody] UserRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(s => s.ErrorMessage))
                });                
            }
            var authResponse = await _identityRepo.RegisterAsync(model.UserName, model.Password, model.FullName, 
                model.IsAdmin, model.IsActive, model.CreatedBy, model.CreatedDateTime, model.CanGiveDiscount, 
                model.UserTypeID, model.MobilePassword);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }

        [HttpPost("PostUserAuthentication")]
        public async Task<IActionResult> PostUserAuthentication([FromBody] UserLoginModel model)
        {
            var authResponse = await _identityRepo.LoginAsync(model.UserName, model.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }
    }
}
