using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.ProductPurchase;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductPurchasesController : ControllerBase
    {
        private readonly IProductPurchaseRepo _productPurchaseRepo;
        private readonly IMapper _mapper;

        public ProductPurchasesController(IProductPurchaseRepo productPurchaseRepo, IMapper mapper)
        {
            _productPurchaseRepo = productPurchaseRepo;
            _mapper = mapper;
        }

        [HttpGet("GetProductForStockPurchase/{ProductCodeName}/{ProductID}/{ProductCategoryID}/{CompanyLocationID}", Name = "GetProductForStockPurchase")]
        public async Task<IActionResult> GetProductForStockPurchase(string ProductCodeName, int ProductID, int ProductCategoryID, int CompanyLocationID)
        {
            var addressFromRepo = await _productPurchaseRepo.GetProductForStockPurchaseAsync(ProductCodeName, ProductID, ProductCategoryID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductForStockPurchase>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductPurchase/{StockPurchaseDateFrom}/{StockPurchaseDateTo}/{ProductID}/{SupplierID}/{UserID}/{CompanyLocationID}", Name = "GetProductPurchase")]
        public async Task<IActionResult> GetProductPurchase(DateTime? StockPurchaseDateFrom, DateTime? StockPurchaseDateTo, int? ProductID, int? SupplierID, int? UserID, int? CompanyLocationID)
        {
            var addressFromRepo = await _productPurchaseRepo.GetProductPurchaseAsync(StockPurchaseDateFrom, StockPurchaseDateTo, ProductID, SupplierID, UserID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductPurchase>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }
    }
}
