using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.Services.Interfaces;

namespace SimuladorCredito.WebApi.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            if (products == null || !products.Any())
            {
                return NotFound();
            }

            var productNames = products.Select(p => p.Name).ToList();
            return Ok(productNames);
        }

        [HttpGet]
        [Route("GetByPersonType/{personTypeId}")]
        public async Task<ActionResult<IEnumerable<string>>> GetByPersonTypeAsync(int personTypeId)
        {
            var products = await _productService.GetProductByPersonTypeAsync(personTypeId);
            if (products == null || !products.Any())
            {
                return NotFound();
            }

            var productNames = products.Select(p => p.Name).ToList();
            return Ok(productNames);
        }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok(_productService.Ping());
        }
    }
}
