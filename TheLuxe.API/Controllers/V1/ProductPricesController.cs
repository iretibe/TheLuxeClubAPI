using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.ProductPrice;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductPricesController : ControllerBase
    {
        private readonly IProductPriceRepo _productPriceRepo;
        private readonly IMapper _mapper;

        public ProductPricesController(IProductPriceRepo productPriceRepo, IMapper mapper)
        {
            _productPriceRepo = productPriceRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteProductPrice/{ProductPriceId}", Name = "DeleteProductPrice")]
        public async Task<IActionResult> DeleteProductPrice(int ProductPriceId)
        {
            var objFromRepo = _productPriceRepo.GetProductPrice(ProductPriceId);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _productPriceRepo.DeleteProductPriceAsync(objFromRepo);

            if (_productPriceRepo.Save() == false)
            {
                throw new Exception($"Deleting Product Price {ProductPriceId} failed on save.");
            }

            return NoContent();
        }

        [HttpDelete("TruncateProductPrice", Name = "TruncateProductPrice")]
        public IActionResult TruncateProductPrice()
        {
            _productPriceRepo.TruncateProductPrice();

            return Ok();
        }

        [HttpGet("GetProductPriceByPackageID/{ProductID}/{PackageID}/{CompanyLocationID}", Name = "GetProductPriceByPackageID")]
        public async Task<IActionResult> GetProductPriceByPackageID(int ProductID, int PackageID, int CompanyLocationID)
        {
            var addressFromRepo = await _productPriceRepo.GetProductPriceByPackageIDAsync(ProductID, PackageID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductPriceByPackageID>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetMobileAvailableProductWithPriceForCashier/{CompanyLocationID}/{ProductCategoryID}", Name = "GetMobileAvailableProductWithPriceForCashier")]
        public async Task<IActionResult> GetMobileAvailableProductWithPriceForCashier(int CompanyLocationID, int ProductCategoryID)
        {
            var addressFromRepo = await _productPriceRepo.GetMobileAvailableProductWithPriceForCashierAsync(CompanyLocationID, ProductCategoryID);

            var title = _mapper.Map<IEnumerable<uspMobileSelectAvailableProductWithPriceForCashier>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetAvailableProductWithPriceForCashier/{CompanyLocationID}/{ProductCategoryID}", Name = "GetAvailableProductWithPriceForCashier")]
        public async Task<IActionResult> GetAvailableProductWithPriceForCashier(int CompanyLocationID, int ProductCategoryID)
        {
            var addressFromRepo = await _productPriceRepo.GetAvailableProductWithPriceForCashierAsync(CompanyLocationID, ProductCategoryID);

            var title = _mapper.Map<IEnumerable<uspSelectAvailableProductWithPriceForCashier>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductPrice/{ProductID}/{CompanyLocationID}", Name = "GetProductPrice")]
        public async Task<IActionResult> GetProductPrice(int ProductID, int CompanyLocationID)
        {
            var addressFromRepo = await _productPriceRepo.GetProductPriceAsync(ProductID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductPrice>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductPriceChange/{ProductCategoryID}", Name = "GetProductPriceChange")]
        public IActionResult GetProductPriceChange(int ProductCategoryID)
        {
            var addressFromRepo = _productPriceRepo.GetProductPriceChangeAsync(ProductCategoryID);

            return Ok(addressFromRepo);
        }

        [HttpGet("GetProductSellingUnit/{ProductID}/{CompanyLocationID}", Name = "GetProductSellingUnit")]
        public async Task<IActionResult> GetProductSellingUnit(int ProductID, int CompanyLocationID)
        {
            var addressFromRepo = await _productPriceRepo.GetProductSellingUnitAsync(ProductID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductSellingUnit>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetSellingUnitByProductID/{ProductID}", Name = "GetSellingUnitByProductID")]
        public async Task<IActionResult> GetSellingUnitByProductID(int ProductID)
        {
            var addressFromRepo = await _productPriceRepo.GetSellingUnitByProductIDAsync(ProductID);

            var title = _mapper.Map<IEnumerable<uspSelectSellingUnitByProductID>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpPost("PostProductPrice", Name = "PostProductPrice")]
        public async Task<IActionResult> PostProductPrice([FromBody] ProductPriceForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productPriceRepo.AddProductPriceAsync(model.ProductID, model.PackageID, model.CostPrice, model.QtyInPackage,
                model.SellingPriceWithoutTAX, model.VAT, model.NHIL, model.TL, model.SellingPriceWithTAX, model.ExemptVAT, model.ExemptNHIL, 
                model.ExemptTL, model.UserID, model.ShowInMenuList);

            return Ok(model);
        }

        [HttpPost("PostProductPriceChange", Name = "PostProductPriceChange")]
        public async Task<IActionResult> PostProductPriceChange([FromBody] ProductPriceChangeForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productPriceRepo.AddProductPriceChangeAsync(model.ProductID, model.PackageID, 
                model.SellingPriceWithoutTAX, model.NewSellingPrice, model.UserID);

            return Ok();
        }

        [HttpPost("PostProductPriceForNewlyCreatedCompanyLocation", Name = "PostProductPriceForNewlyCreatedCompanyLocation")]
        public async Task<IActionResult> PostProductPriceForNewlyCreatedCompanyLocation([FromBody] ProductPriceForNewlyCreatedCompanyLocationForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productPriceRepo.AddProductPriceForNewlyCreatedCompanyLocationAsync(model.CompanyLocationID);

            return Ok(model);
        }

        [HttpPost("PostProductStockTaking", Name = "PostProductStockTaking")]
        public async Task<IActionResult> PostProductStockTaking([FromBody] ProductStockTakingForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productPriceRepo.AddProductStockTakingAsync(model.ProductID, model.ProductName, 
                model.BaseUnitID, model.StockLevel, model.NewStockLevel, model.UserID);

            return Ok(model);
        }

        [HttpPut("PutProductCostPrice", Name = "PutProductCostPrice")]
        public async Task<IActionResult> PutProductCostPrice([FromBody] ProductCostPriceForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productPriceRepo.UpdateProductCostPriceAsync(model.ProductID);

            return Ok(model);
        }

        [HttpPut("PutProductPrice", Name = "PutProductPrice")]
        public async Task<IActionResult> PutProductPrice([FromBody] ProductPriceForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productPriceRepo.UpdateProductPriceAsync(model.ProductPriceID, model.ProductID, model.PackageID, 
                model.CostPrice, model.QtyInPackage, model.SellingPriceWithoutTAX, model.VAT, model.NHIL, model.TL, 
                model.SellingPriceWithTAX, model.ExemptVAT, model.ExemptNHIL, model.ExemptTL, model.UserID, model.ShowInMenuList);

            return Ok(model);
        }

        [HttpPut("PutProductPriceForNewProduct", Name = "PutProductPriceForNewProduct")]
        public async Task<IActionResult> PutProductPriceForNewProduct([FromBody] ProductPriceForNewProductForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productPriceRepo.UpdateProductPriceForNewProductAsync(model.ProductPriceID, model.ProductID, model.PackageID, 
                model.CostPrice, model.QtyInPackage, model.SellingPriceWithoutTAX, model.VAT, model.NHIL, model.TL, model.SellingPriceWithTAX,
                model.ExemptVAT, model.ExemptNHIL, model.ExemptTL, model.UserID, model.ShowInMenuList);

            return Ok(model);
        }

        [HttpPut("PutProductPriceFromInventory", Name = "PutProductPriceFromInventory")]
        public async Task<IActionResult> PutProductPriceFromInventory([FromBody] ProductPriceFromInventoryForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productPriceRepo.UpdateProductPriceFromInventoryAsync(model.ProductPriceID, model.ProductID, model.PackageID,
                model.CostPrice, model.QtyInPackage, model.SellingPriceWithoutTAX, model.VAT, model.NHIL, model.SellingPriceWithTAX,
                model.ExemptVAT, model.ExemptNHIL, model.UserID);

            return Ok(model);
        }

        [HttpPut("PutProductPriceFromProduct", Name = "PutProductPriceFromProduct")]
        public async Task<IActionResult> PutProductPriceFromProduct([FromBody] ProductPriceFromProductForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productPriceRepo.UpdateProductPriceFromProductAsync(model.ProductID, model.PackageID, model.CostPrice,
                model.SellingPriceWithTAX , model.UserID, model.CompanyLocationID, model.ProductPriceID);

            return Ok(model);
        }
    }
}
