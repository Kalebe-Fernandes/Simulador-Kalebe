using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.DTOs;
using SimuladorCredito.Application.Services.Interfaces;
using SimuladorCredito.Domain.Entities;

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

        [HttpGet("GetRateByAsync/{personTypeId}/{modalityId}/{productId}/{segmentId}")]
        public async Task<ActionResult<float>> GetRateByAsync(int personTypeId, int modalityId, int productId, int segmentId)
        {
            var rateDTO = await _rateService.GetRateByAsync(personTypeId, modalityId, productId, segmentId);
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
