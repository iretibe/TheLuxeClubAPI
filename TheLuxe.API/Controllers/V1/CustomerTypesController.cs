using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.CustomerType;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerTypesController : ControllerBase
    {
        private readonly ICustomerTypeRepo _customerTypeRepo;
        private readonly IMapper _mapper;

        public CustomerTypesController(ICustomerTypeRepo customerTypeRepo, IMapper mapper)
        {
            _customerTypeRepo = customerTypeRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteCustomerType/{CustomerTypeId}", Name = "DeleteCustomerType")]
        public async Task<IActionResult> DeleteCustomerType(int CustomerTypeId)
        {
            var objFromRepo = _customerTypeRepo.GetCustomerType(CustomerTypeId);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _customerTypeRepo.DeleteCustomerTypeAsync(objFromRepo);

            if (_customerTypeRepo.Save() == false)
            {
                throw new Exception($"Deleting Customer Type {CustomerTypeId} failed on save.");
            }

            return NoContent();
        }

        [HttpGet("GetCustomerType", Name = "GetCustomerType")]
        public async Task<IActionResult> GetCustomerType()
        {
            var objFromRepo = await _customerTypeRepo.GetCustomerTypeAsync();

            var obj = _mapper.Map<IEnumerable<uspSelectCustomerType>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpGet("GetCustomerTypeForDropDown", Name = "GetCustomerTypeForDropDown")]
        public async Task<IActionResult> GetCustomerTypeForDropDown()
        {
            var addressFromRepo = await _customerTypeRepo.GetCustomerTypeForDropDownAsync();

            var title = _mapper.Map<IEnumerable<uspSelectCustomerTypeForDropDown>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpPost("PostCustomerType", Name = "PostCustomerType")]
        public async Task<IActionResult> PostCustomerType([FromBody] CustomerTypeForInsertionModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _customerTypeRepo.AddCustomerTypeAsync(model.CustomerTypeName, model.Discount, model.Description);

            return Ok(model);
        }

        [HttpPut("PutCustomerType", Name = "PutCustomerType")]
        public async Task<IActionResult> PutCustomerType([FromBody] CustomerTypeForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _customerTypeRepo.UpdateCustomerTypeAsync(model.CustomerTypeID, model.CustomerTypeName, model.Description);

            return Ok(model);
        }
    }
}
