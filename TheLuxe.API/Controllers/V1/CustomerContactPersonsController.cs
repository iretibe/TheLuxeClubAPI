using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.CustomerContactPerson;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerContactPersonsController : ControllerBase
    {
        private readonly ICustomerContactPersonRepo _customerContactPersonRepo;
        private readonly IMapper _mapper;

        public CustomerContactPersonsController(ICustomerContactPersonRepo customerContactPersonRepo, IMapper mapper)
        {
            _customerContactPersonRepo = customerContactPersonRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteCustomerContactPerson/{CustomerContactPersonID}", Name = "DeleteCustomerContactPerson")]
        public async Task<IActionResult> DeleteCustomerContactPerson(int CustomerContactPersonID)
        {
            var objFromRepo = _customerContactPersonRepo.GetCustomerContactPerson(CustomerContactPersonID);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _customerContactPersonRepo.DeleteCustomerContactPersonAsync(objFromRepo);

            if (_customerContactPersonRepo.Save() == false)
            {
                throw new Exception($"Deleting Customer Contact Person {CustomerContactPersonID} failed on save.");
            }

            return NoContent();
        }

        [HttpGet("GetCustomerContactPerson/{int CustomerID}", Name = "GetCustomerContactPerson")]
        public async Task<IActionResult> GetCustomerContactPerson(int CustomerID)
        {
            var objFromRepo = await _customerContactPersonRepo.GetCustomerContactPersonAsync(CustomerID);

            var obj = _mapper.Map<IEnumerable<uspSelectCustomerContactPerson>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostCustomerContactPerson", Name = "PostCustomerContactPerson")]
        public async Task<IActionResult> PostCustomerContactPerson([FromBody] CustomerContactPersonForInsertionModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _customerContactPersonRepo.AddCustomerContactPersonAsync(model.TitleID, model.PositionID, 
                model.ContactPersonName, model.MobilePhoneNo, model.HomePhoneNo, model.OfficePhoneNo, model.Address, model.CustomerID);

            return Ok(model);
        }

        [HttpPut("PutCustomerContactPerson", Name = "PutCustomerContactPerson")]
        public async Task<IActionResult> PutCustomerContactPerson([FromBody] CustomerContactPersonForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _customerContactPersonRepo.UpdateCustomerContactPersonAsync(model.CustomerContactPersonID, model.TitleID, 
                model.PositionID, model.ContactPersonName, model.MobilePhoneNo, model.HomePhoneNo, model.OfficePhoneNo, model.Address, model.CustomerID);

            return Ok(model);
        }
    }
}
