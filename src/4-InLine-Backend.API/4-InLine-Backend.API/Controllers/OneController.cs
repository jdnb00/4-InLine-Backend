using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace _4_InLine_Backend.API.Controllers
{
    [ApiController]
    [Route("4InLine/api/[controller]")]
    public class OneController : ControllerBase
    {
        private static readonly ILogger _log = Log.ForContext<OneController>();
        //private readonly IMediator _mediator;

        public OneController()
        {
            //_mediator = mediator;
            _log.Information("Init");
        }

        [HttpGet("hello")]
        public IActionResult Hello() => Ok("¡Funciona!");

        [HttpGet]
        [SwaggerOperation(Summary = "Primer Endpoint de Prueba")]
        [Route("InitialEndpoint")]
        public async Task<IActionResult> PrimerEndpoint(
          //[FromRoute] QueryModels.GetListaDocumentacionImprimibleTiendaModelInput query,
          //[FromServices] IQueryHandlers handlers
          ) => await Task.FromResult(Ok("Respuesta de prueba"));
    }
}
