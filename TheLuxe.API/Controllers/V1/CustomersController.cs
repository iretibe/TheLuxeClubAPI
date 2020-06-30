using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.Customer;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteCustomer/{CustomerID}", Name = "DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int CustomerID)
        {
            var objFromRepo = _customerRepo.GetCustomer(CustomerID);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _customerRepo.DeleteCustomerAsync(objFromRepo);

            if (_customerRepo.Save() == false)
            {
                throw new Exception($"Deleting Customer {CustomerID} failed on save.");
            }

            return NoContent();
        }

        [HttpDelete("TruncateCustomer", Name = "TruncateCustomer")]
        public IActionResult TruncateCustomer()
        {
            _customerRepo.TruncateCustomerAsync();

            return Ok();
        }

        [HttpGet("GetCreditCustomer/{CustomerName}/{CustomerID}", Name = "GetCreditCustomer")]
        public async Task<IActionResult> GetCreditCustomer(string CustomerName, int CustomerID)
        {
            var objFromRepo = await _customerRepo.GetCreditCustomerAsync(CustomerName, CustomerID);

            var obj = _mapper.Map<IEnumerable<uspSelectCreditCustomer>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpGet("GetCustomer/{CustomerName}/{CustomerID}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(string CustomerName, int CustomerID)
        {
            var addressFromRepo = await _customerRepo.GetCustomerAsync(CustomerName, CustomerID);

            var title = _mapper.Map<IEnumerable<uspSelectCustomer>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetCustomerDiscount/{CustomerName}", Name = "GetCustomerDiscount")]
        public async Task<IActionResult> GetCustomerDiscount(string CustomerName)
        {
            var objFromRepo = await _customerRepo.GetCustomerDiscountAsync(CustomerName);

            var obj = _mapper.Map<IEnumerable<uspSelectCustomerDiscount>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpGet("GetCustomerForCashier/{CustomerID}", Name = "GetCustomerForCashier")]
        public async Task<IActionResult> GetCustomerForCashier(int CustomerID)
        {
            var objFromRepo = await _customerRepo.GetCustomerForCashierAsync(CustomerID);

            var obj = _mapper.Map<IEnumerable<uspSelectCustomerForCashier>>(objFromRepo);
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostCustomer", Name = "PostCustomer")]
        public async Task<IActionResult> PostCustomer([FromBody] CustomerForInsertionModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _customerRepo.AddCustomerAsync(model.RegistrationDate, model.CustomerName, model.PhoneNo, model.FaxNo,
                model.EMailAddress, model.WebSite, model.Address, model.IsActive, model.Debit, model.Credit, model.CreditLimit,
                model.ApplyProtocolSetup, model.ProtocolTypeID, model.Amount, model.CustomerTypeID);

            return Ok(model);
        }

        [HttpPost("PostMobileInsertCustomer", Name = "PostMobileInsertCustomer")]
        public async Task<IActionResult> PostMobileInsertCustomer([FromBody] MobileForInsertionModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _customerRepo.AddMobileInsertCustomerAsync(model.CustomerName, model.PhoneNo, model.EMailAddress, model.Address, model.Note);

            return Ok(model);
        }

        [HttpPut("PutCustomer", Name = "PutCustomer")]
        public async Task<IActionResult> PutCustomer([FromBody] CustomerForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _customerRepo.UpdateCustomerAsync(model.CustomerID, model.RegistrationDate, model.CustomerName, model.PhoneNo, 
                model.FaxNo, model.EMailAddress, model.WebSite, model.Address, model.IsActive, model.Debit, model.Credit, model.CreditLimit,
                model.ApplyProtocolSetup, model.ProtocolTypeID, model.Amount, model.CustomerTypeID);

            return Ok(model);
        }
    }
}
