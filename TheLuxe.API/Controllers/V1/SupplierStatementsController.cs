using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.SupplierStatement;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SupplierStatementsController : ControllerBase
    {
        private readonly ISupplierStatementRepo _supplierStatementRepo;
        private readonly IMapper _mapper;

        public SupplierStatementsController(ISupplierStatementRepo supplierStatementRepo, IMapper mapper)
        {
            _supplierStatementRepo = supplierStatementRepo;
            _mapper = mapper;
        }

        [HttpGet("GetSupplierStatement/{SupplierID}/{SupplierStatementDateFrom}/{SupplierStatementDateTo}", Name = "GetSupplierStatement")]
        public async Task<IActionResult> GetSupplierStatement(int SupplierID, DateTime SupplierStatementDateFrom, DateTime SupplierStatementDateTo)
        {
            var objFromRepo = await _supplierStatementRepo.GetSupplierStatementAsync(SupplierID, SupplierStatementDateFrom, SupplierStatementDateTo);

            var obj = _mapper.Map<IEnumerable<uspSelectSupplierStatement>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }
    }
}
