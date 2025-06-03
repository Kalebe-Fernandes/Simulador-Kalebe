using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;

namespace SimuladorCredito.WebApi.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class RateController(IRateService rateService) : ControllerBase
    {
        private readonly IRateService _rateService = rateService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateDTO>>> GetAllAsync()
        {
            var rates = await _rateService.GetAllAsync();
            if (rates == null || !rates.Any())
            {
                return NotFound();
            }

            return Ok(rates);
        }

        [HttpGet("GetRateByAsync/{personTypeName}/{modalityName}/{productName}/{segmentName}")]
        public async Task<ActionResult<float>> GetRateByAsync(string personTypeName, string modalityName, string productName, string segmentName)
        {
            var rateDTO = await _rateService.GetRateByAsync(personTypeName, modalityName, productName, segmentName);
            if (rateDTO == null)
            {
                return NotFound();
            }

            return Ok(rateDTO.Value);
        }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok(_rateService.Ping());
        }
    }
}
