using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.Order;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        [HttpGet("GetCustomerOustandingBalance/{CustomerID}", Name = "GetCustomerOustandingBalance")]
        public async Task<IActionResult> GetCustomerOustandingBalance(int CustomerID)
        {
            var objFromRepo = await _orderRepo.GetCustomerOustandingBalanceAsync(CustomerID);

            var obj = _mapper.Map<IEnumerable<uspSelectCustomerOustandingBalance>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpGet("GetOrderByCustomer/{CustomerID}", Name = "GetOrderByCustomer")]
        public async Task<IActionResult> GetOrderByCustomer(int CustomerID)
        {
            var objFromRepo = await _orderRepo.GetOrderByCustomerAsync(CustomerID);

            var obj = _mapper.Map<IEnumerable<uspSelectOrderByCustomer>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpGet("GetPendingOrderByCustomerID/{CustomerID}", Name = "GetPendingOrderByCustomerID")]
        public async Task<IActionResult> GetPendingOrderByCustomerID(int CustomerID)
        {
            var objFromRepo = await _orderRepo.GetPendingOrderByCustomerIDAsync(CustomerID);

            var obj = _mapper.Map<IEnumerable<uspSelectPendingOrderByCustomerID>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }
    }
}
