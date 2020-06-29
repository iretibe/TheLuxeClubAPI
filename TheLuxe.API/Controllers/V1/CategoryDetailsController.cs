using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductCategoryDetail;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryDetailsController : ControllerBase
    {
        private readonly ICategoryDetailRepo _categoryDetailRepo;
        private readonly IMapper _mapper;

        public CategoryDetailsController(ICategoryDetailRepo categoryDetailRepo, IMapper mapper)
        {
            _categoryDetailRepo = categoryDetailRepo;
            _mapper = mapper;
        }

        [HttpGet("GetProductCategoryDetail/{ProductCategoryID}", Name = "GetProductCategoryDetail")]
        public async Task<IActionResult> GetProductCategoryDetail(int ProductCategoryID)
        {
            var objFromRepo = await _categoryDetailRepo.GetProductCategoryDetailAsync(ProductCategoryID);

            var obj = _mapper.Map<IEnumerable<uspSelectProductCategoryDetail>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostCategoryDetail", Name = "PostCategoryDetail")]
        public async Task<IActionResult> PostCategoryDetail([FromBody] CategoryDetailForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryDetailRepo.AddProductCategoryDetailsAsync(model.ProductCategoryID, model.CompanyLocationID);

            return Ok(model);
        }

        [HttpPut("PutCategoryDetail", Name = "PutCategoryDetail")]
        public async Task<IActionResult> PutCategoryDetail([FromBody] CategoryDetailForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _categoryDetailRepo.UpdateProductCategoryDetailsAsync(model.ProductCategoryDetailID, model.ShowInMenu, model.ProductCategoryLocationID);

            return Ok(model);
        }
    }
}
