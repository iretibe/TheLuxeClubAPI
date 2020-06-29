using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.ProductCategoryGroup;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryGroupsController : ControllerBase
    {
        private readonly ICategoryGroupRepo _categoryGroupRepo;
        private readonly IMapper _mapper;

        public CategoryGroupsController(ICategoryGroupRepo categoryGroupRepo, IMapper mapper)
        {
            _categoryGroupRepo = categoryGroupRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteProductCategoryGroup/{ProductCategoryGroupId}", Name = "DeleteProductCategoryGroup")]
        public async Task<IActionResult> DeleteProductCategoryGroup(int ProductCategoryGroupId)
        {
            var objFromRepo = _categoryGroupRepo.GetProductCategoryGroup(ProductCategoryGroupId);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _categoryGroupRepo.DeleteCategoryGroupAsync(objFromRepo);

            if (_categoryGroupRepo.Save() == false)
            {
                throw new Exception($"Deleting Category Group {ProductCategoryGroupId} failed on save.");
            }

            return NoContent();
        }

        [HttpGet("GetCategoryGroup", Name = "GetCategoryGroup")]
        public async Task<IActionResult> GetCategoryGroup()
        {
            var objFromRepo = await _categoryGroupRepo.GetCategoryGroupAsync();

            var obj = _mapper.Map<IEnumerable<uspSelectCategoryGroup>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostCategoryGroup", Name = "PostCategoryGroup")]
        public async Task<IActionResult> PostCategoryGroup([FromBody] CategoryGroupForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryGroupRepo.AddCategoryGroupAsync(model.CategoryGroupName);

            return Ok(model);
        }

        [HttpPut("PutCategoryGroup", Name = "PutCategoryGroup")]
        public async Task<IActionResult> PutCategoryGroup([FromBody] CategoryGroupForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryGroupRepo.UpdateCategoryGroupAsync(model.CategoryGroupID, model.CategoryGroupName);

            return Ok(model);
        }
    }
}
