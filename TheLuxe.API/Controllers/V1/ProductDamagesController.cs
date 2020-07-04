using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.ProductDamage;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductDamagesController : ControllerBase
    {
        private readonly IProductDamageRepo _productDamageRepo;
        private readonly IMapper _mapper;

        public ProductDamagesController(IProductDamageRepo productDamageRepo, IMapper mapper)
        {
            _productDamageRepo = productDamageRepo;
            _mapper = mapper;
        }

        [HttpGet("GetProductDamage/{StockDamageDateFrom}/{StockDamageDateTo}/{ProductID}/{UserID}/{CompanyLocationID}", Name = "GetProductDamage")]
        public async Task<IActionResult> GetProductDamage(DateTime StockDamageDateFrom, DateTime StockDamageDateTo, int ProductID, int UserID, int CompanyLocationID)
        {
            var addressFromRepo = await _productDamageRepo.GetProductDamageAsync(StockDamageDateFrom, StockDamageDateTo, ProductID, UserID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductDamage>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductForStockDamage/{ProductCodeName}/{ProductID}/{ProductCategoryID}/{CompanyLocationID}", Name = "GetProductForStockDamage")]
        public async Task<IActionResult> GetProductForStockDamage(string ProductCodeName, int ProductID, int ProductCategoryID, int CompanyLocationID)
        {
            var addressFromRepo = await _productDamageRepo.GetProductForStockDamageAsync(ProductCodeName, ProductID, ProductCategoryID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductForStockDamage>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }
    }
}
