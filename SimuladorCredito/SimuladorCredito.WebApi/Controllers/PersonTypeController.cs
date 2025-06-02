using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimuladorCredito.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("aplication/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PersonTypeController : ControllerBase
    {
    }
}
