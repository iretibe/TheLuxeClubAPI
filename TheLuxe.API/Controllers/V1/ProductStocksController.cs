using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.ProductStock;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductStocksController : ControllerBase
    {
        private readonly IProductStockRepo _productStockRepo;
        private readonly IMapper _mapper;

        public ProductStocksController(IProductStockRepo productStockRepo, IMapper mapper)
        {
            _productStockRepo = productStockRepo;
            _mapper = mapper;
        }

        [HttpDelete("TruncateProductStockLevel", Name = "TruncateProductStockLevel")]
        public IActionResult TruncateProductStockLevel()
        {
            var addressFromRepo = _productStockRepo.TruncateProductStockLevel();

            return Ok(addressFromRepo);
        }

        [HttpGet("GetProductStock/{ProductID}/{CompanyLocationID}/{ProductCategoryID}", Name = "GetProductStock")]
        public async Task<IActionResult> GetProductStock(int? ProductID, int? CompanyLocationID, int? ProductCategoryID)
        {
            var addressFromRepo = await _productStockRepo.GetProductStockAsync(ProductID, CompanyLocationID, ProductCategoryID);

            var title = _mapper.Map<IEnumerable<uspSelectProductStock>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductStockLevel/{ProductID}/{CompanyLocationID}", Name = "GetProductStockLevel")]
        public async Task<IActionResult> GetProductStockLevel(int? ProductID, int? CompanyLocationID)
        {
            var addressFromRepo = await _productStockRepo.GetProductStockLevelAsync(ProductID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductStockLevel>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductStockTaking/{ProductCategoryID}/{CompanyLocationID}", Name = "GetProductStockTaking")]
        public async Task<IActionResult> GetProductStockTaking(int? ProductCategoryID, int? CompanyLocationID)
        {
            var addressFromRepo = await _productStockRepo.GetProductStockTakingAsync(ProductCategoryID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductStockTaking>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductStockToUpdate/{ProductID}/{CompanyLocationID}/{ProductCategoryID}", Name = "GetProductStockToUpdate")]
        public async Task<IActionResult> GetProductStockToUpdate(int? ProductID, int? CompanyLocationID, int? ProductCategoryID)
        {
            var addressFromRepo = await _productStockRepo.GetProductStockToUpdateAsync(ProductID, CompanyLocationID, ProductCategoryID);

            var title = _mapper.Map<IEnumerable<uspSelectProductStockToUpdate>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductTransactionSummary/{ProductCategoryID}/{ProductID}/{CompanyLocationID}", Name = "GetProductTransactionSummary")]
        public async Task<IActionResult> GetProductTransactionSummary(int? ProductCategoryID, int? ProductID, int CompanyLocationID)
        {
            var addressFromRepo = await _productStockRepo.GetProductTransactionSummaryAsync(ProductCategoryID, ProductID, CompanyLocationID);

            var title = _mapper.Map<IEnumerable<uspSelectProductTransactionSummary>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpGet("GetProductWichHasStock/{ProductCodeName}", Name = "GetProductWichHasStock")]
        public async Task<IActionResult> GetProductWichHasStock(string ProductCodeName)
        {
            var addressFromRepo = await _productStockRepo.GetProductWichHasStockAsync(ProductCodeName);

            var title = _mapper.Map<IEnumerable<uspSelectProductWichHasStock>>(addressFromRepo);
            if (title == null)
                return NotFound();

            return Ok(title);
        }

        [HttpPost("PostProductStock", Name = "PostProductStock")]
        public async Task<IActionResult> PostProductStock([FromBody] ProductStockForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productStockRepo.AddProductStockAsync(model.ProductID, model.StockLevel, model.ReOrderLevel, model.NoStockUpdate);

            return Ok(model);
        }

        [HttpPost("PostProductStockForNewlyCreatedCompanyLocation", Name = "PostProductStockForNewlyCreatedCompanyLocation")]
        public async Task<IActionResult> PostProductStockForNewlyCreatedCompanyLocation([FromBody] ProductStockForNewlyCreatedCompanyLocationForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productStockRepo.AddProductStockForNewlyCreatedCompanyLocationAsync(model.CompanyLocationID);

            return Ok(model);
        }

        [HttpPut("PutProductStock", Name = "PutProductStock")]
        public async Task<IActionResult> PutProductStock([FromBody] ProductStockForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productStockRepo.UpdateProductStockAsync(model.ProductID, model.StockLevel, model.ReOrderLevel, model.CompanyLocationID, model.UserID);

            return Ok(model);
        }

        [HttpPut("PutProductStockLevel", Name = "PutProductStockLevel")]
        public async Task<IActionResult> PutProductStockLevel([FromBody] ProductStockLevelForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _productStockRepo.UpdateProductStockLevelAsync(model.ProductID, model.Qty);

            return Ok(model);
        }
    }
}
