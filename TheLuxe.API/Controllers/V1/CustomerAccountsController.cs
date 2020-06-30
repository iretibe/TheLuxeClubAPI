using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.CustomerAccount;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerAccountsController : ControllerBase
    {
        private readonly ICustomerAccountRepo _customerAccountRepo;
        private readonly IMapper _mapper;

        public CustomerAccountsController(ICustomerAccountRepo customerAccountRepo, IMapper mapper)
        {
            _customerAccountRepo = customerAccountRepo;
            _mapper = mapper;
        }

        [HttpGet("GetCustomerAccount", Name = "GetCustomerAccount")]
        public async Task<IActionResult> GetCustomerAccount()
        {
            var objFromRepo = await _customerAccountRepo.GetCustomerAccountAsync();

            var obj = _mapper.Map<IEnumerable<uspSelectCustomerAccount>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }
    }
}
