using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.SupplierProduct;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SupplierProductsController : ControllerBase
    {
        private readonly ISupplierProductRepo _supplierProductRepo;
        private readonly IMapper _mapper;

        public SupplierProductsController(ISupplierProductRepo supplierProductRepo, IMapper mapper)
        {
            _supplierProductRepo = supplierProductRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteSupplierProduct/{SupplierProductId}", Name = "DeleteSupplierProduct")]
        public async Task<IActionResult> DeleteSupplierProduct(int SupplierProductId)
        {
            var objFromRepo = _supplierProductRepo.GetSupplierProduct(SupplierProductId);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _supplierProductRepo.DeleteSupplierProductAsync(objFromRepo);

            if (_supplierProductRepo.Save() == false)
            {
                throw new Exception($"Deleting Supplier Product {SupplierProductId} failed on save.");
            }

            return NoContent();
        }

        [HttpGet("GetSupplierProduct/{SupplierID}", Name = "GetSupplierProduct")]
        public async Task<IActionResult> GetSupplierProduct(int SupplierID)
        {
            var objFromRepo = await _supplierProductRepo.GetSupplierProductAsync(SupplierID);

            var obj = _mapper.Map<IEnumerable<uspSelectSupplierProduct>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostSupplierProduct", Name = "PostSupplierProduct")]
        public async Task<IActionResult> PostSupplierProduct([FromBody] SupplierProductForInsertionModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _supplierProductRepo.AddSupplierProductAsync(model.ProductID, model.SupplierID);

            return Ok(model);
        }
    }
}
