using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Application.Services.Interfaces;

namespace SimuladorCredito.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PersonTypeController(IPersonTypeService personTypeService) : ControllerBase
    {
        private readonly IPersonTypeService _personTypeService = personTypeService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAllAsync()
        {
            var personTypes = await _personTypeService.GetAllAsync();
            if (personTypes == null || !personTypes.Any())
            {
                return NotFound();
            }

            var personTypeNames = personTypes.Select(pt => pt.Name).ToList();
            return Ok(personTypeNames);
        }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok(_personTypeService.Ping());
        }
    }
}
