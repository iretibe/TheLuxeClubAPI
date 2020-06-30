using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        //[HttpDelete("DeductProductRecipe/{OrderDetailID}/{ProductID}/{Qty}/{ShiftID}/{CompanyLocationID}", Name = "DeductProductRecipe")]
        //public async Task<IActionResult> DeductProductRecipe(int OrderDetailID, int ProductID, double Qty, int ShiftID, int CompanyLocationID)
        //{
        //    var objFromRepo = _productRecipeRepo.DeductProductRecipeAsync(OrderDetailID, ProductID, Qty, ShiftID, CompanyLocationID);
            
        //    if (objFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    var obj = _mapper.Map<uspMobileSelectProductCategory>(objFromRepo);

        //    if (obj == null) return NotFound();

        //    return Ok(obj);
        //}
    }
}
