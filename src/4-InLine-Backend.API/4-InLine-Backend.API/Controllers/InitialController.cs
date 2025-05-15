using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace _4_InLine_Backend.API.Controllers
{
    [ApiController]
    [Route("4inline/api/[controller]")]
    public class InitialController : ControllerBase
    {
        private static readonly ILogger _log = Log.ForContext<InitialController>();
        private readonly IMediator _mediator;

        public InitialController(IMediator mediator)
        {
            _mediator = mediator;
            _log.Information("Init");
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Primer Endpoint de Prueba")]
        [Route("InitialEndponit")]
        public async Task<IActionResult> PrimerEndpoint(
          //[FromRoute] QueryModels.GetListaDocumentacionImprimibleTiendaModelInput query,
          //[FromServices] IQueryHandlers handlers
          ) => await Task.FromResult(Ok("Respuesta de prueba"));
    }
}
