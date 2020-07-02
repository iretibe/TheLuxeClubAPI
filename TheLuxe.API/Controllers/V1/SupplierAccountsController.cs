using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.SupplierAccount;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SupplierAccountsController : ControllerBase
    {
        private readonly ISupplierAccountRepo _supplierAccountRepo;
        private readonly IMapper _mapper;

        public SupplierAccountsController(ISupplierAccountRepo supplierAccountRepo, IMapper mapper)
        {
            _supplierAccountRepo = supplierAccountRepo;
            _mapper = mapper;
        }

        [HttpGet("GetSupplierAccount/{SupplierID}", Name = "GetSupplierAccount")]
        public async Task<IActionResult> GetCreditCustomer(int SupplierID)
        {
            var objFromRepo = await _supplierAccountRepo.GetSupplierAccountAsync(SupplierID);

            var obj = _mapper.Map<IEnumerable<uspSelectSupplierAccount>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }
    }
}
