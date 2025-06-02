using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.Services.Interfaces;

namespace SimuladorCredito.WebApi.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class SegmentController(ISegmentService segmentService) : ControllerBase
    {
        private readonly ISegmentService _segmentService = segmentService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAllAsync()
        {
            var segments = await _segmentService.GetAllAsync();
            if (segments == null || !segments.Any())
            {
                return NotFound();
            }

            var segmentNames = segments.Select(s => s.Name).ToList();
            return Ok(segmentNames);
        }

        [HttpGet("GetSegmentByPersonTypeAsync/{personTypeId}/{minimumIncome}")]
        public async Task<ActionResult<IEnumerable<string>>> GetSegmentByPersonTypeAsync(int personTypeId, int minimumIncome)
        {
            var segment = await _segmentService.GetSegmentByPersonTypeAsync(personTypeId, minimumIncome);
            if (segment == null)
            {
                return NotFound();
            }

            return Ok(segment.Name);
        }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok(_segmentService.Ping());
        }
    }
}
