using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductRecipe;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductRecipesController : ControllerBase
    {
        private readonly IProductRecipeRepo _productRecipeRepo;
        private readonly IMapper _mapper;

        public ProductRecipesController(IProductRecipeRepo productRecipeRepo, IMapper mapper)
        {
            _productRecipeRepo = productRecipeRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteProductRecipe/{ProductRecipeId}", Name = "DeleteProductRecipe")]
        public async Task<IActionResult> DeleteProductRecipe(int ProductRecipeId)
        {
            var objFromRepo = _productRecipeRepo.GetProductRecipe(ProductRecipeId);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _productRecipeRepo.DeleteProductRecipeAsync(objFromRepo);

            if (_productRecipeRepo.Save() == false)
            {
                throw new Exception($"Deleting Product Recipe {ProductRecipeId} failed on save.");
            }

            return NoContent();
        }

        [HttpDelete("DeductProductRecipe/{OrderDetailID}/{ProductID}/{Qty}/{ShiftID}/{CompanyLocationID}", Name = "DeductProductRecipe")]
        public IActionResult DeductProductRecipe(int OrderDetailID, int ProductID, double Qty, int ShiftID, int CompanyLocationID)
        {
            _productRecipeRepo.DeductProductRecipeAsync(OrderDetailID, ProductID, Qty, ShiftID, CompanyLocationID);

            return Ok();
        }

        [HttpGet("GetProductRecipe/{ProductRecipeID}/{ProductID}", Name = "GetProductRecipe")]
        public async Task<IActionResult> GetProductRecipe(int? ProductRecipeID, int? ProductID)
        {
            var addressFromRepo = await _productRecipeRepo.GetProductRecipeAsync(ProductRecipeID, ProductID);

            var title = _mapper.Map<IEnumerable<uspSelectProductRecipe>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductRecipeSelector/{ProductID}/{ProductCategoryID}", Name = "GetProductRecipeSelector")]
        public async Task<IActionResult> GetProductRecipeSelector(int ProductID, int? ProductCategoryID)
        {
            var addressFromRepo = await _productRecipeRepo.GetProductRecipeSelectorAsync(ProductID, ProductCategoryID);

            var title = _mapper.Map<IEnumerable<uspSelectProductRecipeSelector>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpPost("PostProductRecipe", Name = "PostProductRecipe")]
        public async Task<IActionResult> PostProductRecipe([FromBody] ProductRecipeForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productRecipeRepo.AddProductRecipeAsync(model.ProductID, model.RecipeID, model.Qty, model.PackageID, model.CostPrice);

            return Ok(model);
        }

        [HttpPut("PutProductRecipe", Name = "PutProductRecipe")]
        public async Task<IActionResult> PutProductRecipe([FromBody] ProductRecipeForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productRecipeRepo.UpdateProductRecipeAsync(model.ProductRecipeID, model.ProductID, model.RecipeID,
                model.Qty, model.PackageID, model.CostPrice);

            return Ok(model);
        }
    }
}
