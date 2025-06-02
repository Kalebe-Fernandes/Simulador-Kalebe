using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimuladorCredito.WebApi.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ModalityController : ControllerBase
    {
    }
}
