using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.Services.Interfaces;

namespace SimuladorCredito.WebApi.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ModalityController(IModalityService modalityService) : ControllerBase
    {
        private readonly IModalityService _modalityService = modalityService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAllAsync()
        {
            var modalities = await _modalityService.GetAllAsync();
            if (modalities == null || !modalities.Any())
            {
                return NotFound();
            }

            var modalityNames = modalities.Select(m => m.Name).ToList();
            return Ok(modalityNames);
        }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok(_modalityService.Ping());
        }
    }
}
