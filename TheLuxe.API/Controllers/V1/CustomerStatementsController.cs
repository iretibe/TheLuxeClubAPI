using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.CustomerStatement;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerStatementsController : ControllerBase
    {
        private readonly ICustomerStatementRepo _customerStatementRepo;
        private readonly IMapper _mapper;

        public CustomerStatementsController(ICustomerStatementRepo customerStatementRepo, IMapper mapper)
        {
            _customerStatementRepo = customerStatementRepo;
            _mapper = mapper;
        }

        [HttpGet("GetCustomerStatement/{CustomerID}/{CustomerStatementDateFrom}/{CustomerStatementDateTo}", Name = "GetCustomerStatement")]
        public async Task<IActionResult> GetCustomerStatement(int CustomerID, DateTime CustomerStatementDateFrom, DateTime CustomerStatementDateTo)
        {
            var objFromRepo = await _customerStatementRepo.GetCustomerStatementAsync(CustomerID, CustomerStatementDateFrom, CustomerStatementDateTo);

            var obj = _mapper.Map<IEnumerable<uspSelectCustomerStatement>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }
    }
}
