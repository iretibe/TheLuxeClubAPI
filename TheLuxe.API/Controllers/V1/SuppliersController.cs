using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.Supplier;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepo _supplierRepo;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierRepo supplierRepo, IMapper mapper)
        {
            _supplierRepo = supplierRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteSupplier/{SupplierId}", Name = "DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier(int SupplierId)
        {
            var objFromRepo = _supplierRepo.GetSupplier(SupplierId);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _supplierRepo.DeleteSupplierAsync(objFromRepo);

            if (_supplierRepo.Save() == false)
            {
                throw new Exception($"Deleting Supplier {SupplierId} failed on save.");
            }

            return NoContent();
        }

        [HttpDelete("TruncateSupplier", Name = "TruncateSupplier")]
        public IActionResult TruncateSupplier()
        {
            _supplierRepo.TruncateSupplierAsync();

            return Ok();
        }

        [HttpGet("GetSupplier/{SupplierName}", Name = "GetSupplier")]
        public async Task<IActionResult> GetSupplier(string SupplierName)
        {
            var objFromRepo = await _supplierRepo.GetSupplierAsync(SupplierName);

            var obj = _mapper.Map<IEnumerable<uspSelectSupplier>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostSupplier", Name = "PostSupplier")]
        public async Task<IActionResult> PostSupplier([FromBody] SupplierForInsertionModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _supplierRepo.AddSupplierAsync(model.RegistrationDate, model.SupplierName, model.PhoneNo,
                model.FaxNo, model.EMailAddress, model.WebSite, model.Address, model.IsActive, model.Debit, model.Credit);

            return Ok(model);
        }

        [HttpPut("PutSupplier", Name = "PutSupplier")]
        public async Task<IActionResult> PutSupplier([FromBody] SupplierForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _supplierRepo.UpdateSupplierAsync(model.SupplierID, model.RegistrationDate, model.SupplierName, model.PhoneNo,
                model.FaxNo, model.EMailAddress, model.WebSite, model.Address, model.IsActive, model.Debit, model.Credit);

            return Ok(model);
        }
    }
}
