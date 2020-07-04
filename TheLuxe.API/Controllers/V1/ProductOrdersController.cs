using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.ProductOrder;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductOrdersController : ControllerBase
    {
        private readonly IProductOrderRepo _productOrderRepo;
        private readonly IMapper _mapper;

        public ProductOrdersController(IProductOrderRepo productOrderRepo, IMapper mapper)
        {
            _productOrderRepo = productOrderRepo;
            _mapper = mapper;
        }

        [HttpGet("GetProductOrderWithShift/{FromShiftID}/{StockDamageDateTo}/{ProductID}/{UserID}/{ProductCategoryID}/{OrderStatusID}/{CustomerID}/{ProductCategoryLocationID}/{CategoryGroupID}/{CompanyLocationID}", Name = "GetProductOrderWithShift")]
        public async Task<IActionResult> GetProductOrderWithShift(int FromShiftID, int StockDamageDateTo, int ProductID, int UserID,
            int ProductCategoryID, int OrderStatusID, int CustomerID, int ProductCategoryLocationID, int CategoryGroupID, int CompanyLocationID)
        {
            var addressFromRepo = await _productOrderRepo.GetProductOrderWithShiftAsync(FromShiftID, StockDamageDateTo, ProductID, UserID, ProductCategoryID,
                OrderStatusID, CustomerID, ProductCategoryLocationID, CategoryGroupID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductOrderWithShift>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }
    }
}
