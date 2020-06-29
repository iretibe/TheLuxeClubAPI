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

        [HttpGet("GetProductPriceByPackageID/{ProductID}/{PackageID}/{CompanyLocationID}", Name = "GetProductPriceByPackageID")]
        public async Task<IActionResult> GetProductPriceByPackageID(int ProductID, int PackageID, int CompanyLocationID)
        {
            var addressFromRepo = await _productPriceRepo.GetProductPriceByPackageIDAsync(ProductID, PackageID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductPriceByPackageID>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }
    }
}
