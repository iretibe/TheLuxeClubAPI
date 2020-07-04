using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.Product;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteProduct/{ProductId}", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            var objFromRepo = _productRepo.GetProduct(ProductId);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _productRepo.DeleteProductAsync(objFromRepo);

            if (_productRepo.Save() == false)
            {
                throw new Exception($"Deleting Product {ProductId} failed on save.");
            }

            return NoContent();
        }

        [HttpDelete("TruncateProduct", Name = "TruncateProduct")]
        public IActionResult TruncateProduct()
        {
            _productRepo.TruncateProduct();

            return Ok();
        }

        [HttpGet("GetAvailableProduct/{ProductCodeName}/{ProductID}/{ProductCategoryID}", Name = "GetAvailableProduct")]
        public async Task<IActionResult> GetAvailableProduct(string ProductCodeName, int ProductID, int ProductCategoryID)
        {
            var addressFromRepo = await _productRepo.GetAvailableProductAsync(ProductCodeName, ProductID, ProductCategoryID);

            var title = _mapper.Map<IEnumerable<uspSelectAvailableProduct>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetAvailableProductByBarCode/{BarCode}/{ProductID}/{ProductCategoryID}", Name = "GetAvailableProductByBarCode")]
        public IActionResult GetAvailableProductByBarCode(string BarCode, int ProductID, int ProductCategoryID)
        {
            var addressFromRepo = _productRepo.GetAvailableProductByBarCodeAsync(BarCode, ProductID, ProductCategoryID);

            return Ok(addressFromRepo);
        }

        [HttpGet("GetProductDropDown", Name = "GetProductDropDown")]
        public async Task<IActionResult> GetProductDropDown()
        {
            var addressFromRepo = await _productRepo.GetProductDropDownAsync();

            var title = _mapper.Map<IEnumerable<uspSelectProductDropDown>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductDropDownForStockPurchase", Name = "GetProductDropDownForStockPurchase")]
        public async Task<IActionResult> GetProductDropDownForStockPurchase()
        {
            var addressFromRepo = await _productRepo.GetProductDropDownForStockPurchaseAsync();

            var title = _mapper.Map<IEnumerable<uspSelectProductDropDownForStockPurchase>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductInStock/{ProductCodeName}", Name = "GetProductInStock")]
        public IActionResult GetProductInStock(string ProductCodeName)
        {
            var addressFromRepo = _productRepo.GetProductInStockAsync(ProductCodeName);

            return Ok(addressFromRepo);
        }

        [HttpGet("GetProductPicture/{ProductID}", Name = "GetProductPicture")]
        public async Task<IActionResult> GetProductPicture(int ProductID)
        {
            var addressFromRepo = await _productRepo.GetProductPictureAsync(ProductID);

            var title = _mapper.Map<IEnumerable<uspSelectProductPicture>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductPriceNew/{ProductCategoryID}", Name = "GetProductPriceNew")]
        public async Task<IActionResult> GetProductPriceNew(int? ProductCategoryID)
        {
            var addressFromRepo = await _productRepo.GetProductPriceNewAsync(ProductCategoryID);

            var title = _mapper.Map<IEnumerable<uspSelectProductPriceNew>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductWithNoStockForRecipe/{ProductCodeName}/{ProductID}/{ProductCategoryID}", Name = "GetProductWithNoStockForRecipe")]
        public async Task<IActionResult> GetProductWithNoStockForRecipe(string ProductCodeName, int? ProductID, int? ProductCategoryID)
        {
            var addressFromRepo = await _productRepo.GetProductWithNoStockForRecipeAsync(ProductCodeName, ProductID, ProductCategoryID);

            var title = _mapper.Map<IEnumerable<uspSelectProductWithNoStockForRecipe>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }
        
        [HttpPost("PostProduct", Name = "PostProduct")]
        public async Task<IActionResult> PostProduct([FromBody] ProductForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productRepo.AddProductAsync(model.ProductCode, model.BarCode, model.ProductName, model.IsActive,
                model.StockLevel, model.BaseUnitID, model.ReOrderLevel, model.ProductCategoryID, model.UserID, model.DoesItHaveStock, 
                model.AllowProtocol, model.SellingPrice, model.CostPrice, model.CompanyLocationID);

            return Ok(model);
        }

        [HttpPut("PutProduct", Name = "PutProduct")]
        public async Task<IActionResult> PutProduct([FromBody] ProductForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productRepo.UpdateProductAsync(model.ProductID, model.ProductCode, model.BarCode, model.ProductName, model.IsActive,
                model.BaseUnitID, model.ProductCategoryID, model.UserID, model.DoesItHaveStock, model.AllowProtocol, model.NoOfPortion);

            return Ok(model);
        }

        [HttpPut("PutProductFromInventory", Name = "PutProductFromInventory")]
        public async Task<IActionResult> PutProductFromInventory([FromBody] ProductFromInventoryForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productRepo.UpdateProductFromInventoryAsync(model.ProductID, model.ProductCode, model.BarCode, model.ProductName, 
                model.Description, model.StatusID, model.BaseUnitID, model.ExpiryDate, model.ProductCategoryID, model.UserID, model.DoesItHaveStock);

            return Ok(model);
        }

        [HttpPut("PutProductPicture", Name = "PutProductPicture")]
        public async Task<IActionResult> PutProductPicture([FromBody] ProductPictureForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productRepo.UpdateProductPictureAsync(model.ProductID, model.ProductPicture);

            return Ok(model);
        }

        [HttpPut("PutProductWithPrice", Name = "PutProductWithPrice")]
        public async Task<IActionResult> PutProductWithPrice([FromBody] ProductWithPriceForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productRepo.UpdateProductWithPriceAsync(model.ProductID, model.ProductCode, model.BarCode, model.ProductName, 
                model.IsActive, model.BaseUnitID, model.ProductCategoryID, model.UserID, model.DoesItHaveStock, model.AllowProtocol, 
                model.SellingPrice, model.CostPrice, model.CompanyLocationID, model.ProductPriceID);

            return Ok(model);
        }
    }
}
