using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.SupplierContactPerson;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SupplierContactPersonsController : ControllerBase
    {
        private readonly ISupplierContactPersonRepo _supplierContactPersonRepo;
        private readonly IMapper _mapper;

        public SupplierContactPersonsController(ISupplierContactPersonRepo supplierContactPersonRepo, IMapper mapper)
        {
            _supplierContactPersonRepo = supplierContactPersonRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteSupplierContactPerson/{SupplierContactPersonId}", Name = "DeleteSupplierContactPerson")]
        public async Task<IActionResult> DeleteSupplierContactPerson(int SupplierContactPersonId)
        {
            var objFromRepo = _supplierContactPersonRepo.GetSupplierSupplierContactPerson(SupplierContactPersonId);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _supplierContactPersonRepo.DeleteSupplierContactPersonAsync(objFromRepo);

            if (_supplierContactPersonRepo.Save() == false)
            {
                throw new Exception($"Deleting Supplier Contact Person {SupplierContactPersonId} failed on save.");
            }

            return NoContent();
        }

        [HttpGet("GetSupplierContactPerson/{SupplierContactPersonID}/{SupplierID}", Name = "GetSupplierContactPerson")]
        public async Task<IActionResult> GetSupplierContactPerson(int SupplierContactPersonID, int SupplierID)
        {
            var objFromRepo = await _supplierContactPersonRepo.GetSupplierContactPersonAsync(SupplierContactPersonID, SupplierID);

            var obj = _mapper.Map<IEnumerable<uspSelectSupplierContactPerson>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostSupplierContactPerson", Name = "PostSupplierContactPerson")]
        public async Task<IActionResult> PostSupplierContactPerson([FromBody] SupplierContactPersonForInsertionModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _supplierContactPersonRepo.AddSupplierContactPersoAsync(model.TitleID, model.PositionID, 
                model.ContactPersonName, model.MobilePhoneNo, model.HomePhoneNo, model.OfficePhoneNo, model.Address, model.SupplierID);

            return Ok(model);
        }

        [HttpPut("PutSupplierContactPerson", Name = "PutSupplierContactPerson")]
        public async Task<IActionResult> PutSupplierContactPerson([FromBody] SupplierContactPersonForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _supplierContactPersonRepo.UpdateSupplierContactPersoAsync(model.SupplierContactPersonID, model.TitleID, model.PositionID,
                model.ContactPersonName, model.MobilePhoneNo, model.HomePhoneNo, model.OfficePhoneNo, model.Address, model.SupplierID);

            return Ok(model);
        }
    }
}
