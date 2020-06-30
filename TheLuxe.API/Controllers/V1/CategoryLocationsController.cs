using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductCategoryLocation;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryLocationsController : ControllerBase
    {
        private readonly ICategoryLocationRepo _categoryLocationRepo;
        private readonly IMapper _mapper;

        public CategoryLocationsController(ICategoryLocationRepo categoryLocationRepo, IMapper mapper)
        {
            _categoryLocationRepo = categoryLocationRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteProductCategoryLocation/{ProductCategoryLocationId}", Name = "DeleteProductCategoryLocation")]
        public async Task<IActionResult> DeleteProductCategoryLocation(int ProductCategoryLocationId)
        {
            var objFromRepo = _categoryLocationRepo.GetProductCategoryLocation(ProductCategoryLocationId);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _categoryLocationRepo.DeleteProductCategoryLocationAsync(objFromRepo);

            if (_categoryLocationRepo.Save() == false)
            {
                throw new Exception($"Deleting Category Location {ProductCategoryLocationId} failed on save.");
            }

            return NoContent();
        }

        [HttpGet("GetNoOfProductCategoryLocation", Name = "GetNoOfProductCategoryLocation")]
        public async Task<IActionResult> GetNoOfProductCategoryLocation()
        {
            var objFromRepo = await _categoryLocationRepo.GetNoOfProductCategoryLocationAsync();

            var obj = _mapper.Map<IEnumerable<uspSelectNoOfProductCategoryLocation>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpGet("GetProductCategoryLocation", Name = "GetProductCategoryLocation")]
        public async Task<IActionResult> GetProductCategoryLocation()
        {
            var objFromRepo = await _categoryLocationRepo.GetProductCategoryLocationAsync();

            var obj = _mapper.Map<IEnumerable<uspSelectProductCategoryLocation>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostCategoryLocation", Name = "PostCategoryLocation")]
        public async Task<IActionResult> PostCategoryLocation([FromBody] CategoryLocationForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryLocationRepo.AddProductCategoryLocationAsync(model.ProductCategoryLocationName, model.PrinterName);

            return Ok(model);
        }

        [HttpPut("PutCategoryLocation", Name = "PutCategoryLocation")]
        public async Task<IActionResult> PutCategoryLocation([FromBody] CategoryLocationForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryLocationRepo.UpdateProductCategoryLocationAsync(model.ProductCategoryLocationID, model.ProductCategoryLocationName, model.PrinterName);

            return Ok(model);
        }
    }
}
