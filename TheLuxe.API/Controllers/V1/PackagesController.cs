using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheLuxe.Model.ProductPackage;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageRepo _packageRepo;
        private readonly IMapper _mapper;

        public PackagesController(IPackageRepo packageRepo, IMapper mapper)
        {
            _packageRepo = packageRepo;
            _mapper = mapper;
        }

        [HttpDelete("DeleteProductPackage/{ProductPackageID}", Name = "DeleteProductPackage")]
        public async Task<IActionResult> DeleteProductPackage(int ProductPackageID)
        {
            var objFromRepo = _packageRepo.GetProductPackage(ProductPackageID);
            if (objFromRepo == null)
            {
                return NotFound();
            }

            await _packageRepo.DeleteProductPackageAsync(objFromRepo);

            if (_packageRepo.Save() == false)
            {
                throw new Exception($"Deleting Package {ProductPackageID} failed on save.");
            }

            return NoContent();
        }

        [HttpGet("GetPackage", Name = "GetPackage")]
        public async Task<IActionResult> GetPackage()
        {
            var objFromRepo = await _packageRepo.GetPackageAsync();

            var obj = _mapper.Map<IEnumerable<uspSelectPackage>>(objFromRepo);

            if (obj == null) return NotFound();

            return Ok(obj);
        }

        [HttpPost("PostPackage", Name = "PostPackage")]
        public async Task<IActionResult> PostPackage([FromBody] PackageForInsertModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _packageRepo.AddProductPackageAsync(model.PackageName);

            return Ok(model);
        }

        [HttpPut("PutPackage", Name = "PutPackage")]
        public async Task<IActionResult> PutPackage([FromBody] PackageForUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            await _packageRepo.UpdateProductPackageAsync(model.PackageID, model.PackageName);

            return Ok(model);
        }
    }
}
