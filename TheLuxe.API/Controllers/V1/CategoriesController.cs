using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.ProductCategory;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteProductCategory/{ProductCategoryID}", Name = "DeleteProductCategory")]
        public async Task<IActionResult> DeleteProductCategory(int ProductCategoryID)
        {
            var objFromRepo = _categoryRepo.GetProductCategory(ProductCategoryID);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _categoryRepo.DeleteProductCategoryAsync(objFromRepo);

            if (_categoryRepo.Save() == false)
            {
                throw new Exception($"Deleting Category {ProductCategoryID} failed on save.");
            }

            return NoContent();
        }

        [HttpGet("GetMobileProductCategory", Name = "GetMobileProductCategory")]
        public async Task<IActionResult> GetMobileProductCategory()
        {
            var objFromRepo = await _categoryRepo.GetMobileProductCategoryAsync();

            var obj = _mapper.Map<IEnumerable<uspMobileSelectProductCategory>>(objFromRepo);

            if (obj == null)return NotFound();

            return Ok(obj);
        }

        [HttpGet("GetCategory/{ProductCategoryID}/{CategoryName}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int? ProductCategoryID, string CategoryName, int PageSize, int PageNumber, string SortBy, string SortOrder)
        {
            var addressFromRepo = await _categoryRepo.GetCategoryAsync(ProductCategoryID, CategoryName, PageSize, PageNumber, SortBy, SortOrder);

            var title = _mapper.Map<IEnumerable<uspSelectCategory>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductCategory/{ProductCategoryID}", Name = "GetProductCategory")]
        public async Task<IActionResult> GetProductCategory(int ProductCategoryID)
        {
            var objFromRepo = await _categoryRepo.GetProductCategoryAsync(ProductCategoryID);

            var obj = _mapper.Map<IEnumerable<uspSelectProductCategory>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpGet("GetProductCategoryForMenu/{ProductCategoryID}/{CategoryGroupID}/{CompanyLocationID}", Name = "GetProductCategoryForMenu")]
        public async Task<IActionResult> GetProductCategoryForMenu(int ProductCategoryID, int CategoryGroupID, int CompanyLocationID)
        {
            var objFromRepo = await _categoryRepo.GetProductCategoryForMenuAsync(ProductCategoryID, CategoryGroupID, CompanyLocationID);

            var obj = _mapper.Map<IEnumerable<uspSelectProductCategoryForMenu>>(objFromRepo);
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostCategory", Name = "PostCategory")]
        public async Task<IActionResult> PostCategory([FromBody] CategoryForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryRepo.AddProductCategoryAsync(model.CategoryName, model.CategoryGroupID, model.SelectOption);

            return Ok(model);
        }

        [HttpPut("PutCategory", Name = "PutCategory")]
        public async Task<IActionResult> PutCategory([FromBody] CategoryForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryRepo.UpdateProductCategoryAsync(model.ProductCategoryID, model.CategoryName, model.CategoryGroupID, model.SelectOption);

            return Ok(model);
        }
    }
}
