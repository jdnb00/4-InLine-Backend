using MediatR;
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
        private readonly IMediator _mediator;

        public OneController(IMediator mediator)
        {
            _mediator = mediator;
            _log.Information("Init");
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Primer Endpoint de Prueba")]
        [Route("EstadoJuego")]
        public async Task<IActionResult> GetEstadoJuego() 
            => await Task.FromResult(Ok("¡Funciona!... Respuesta de prueba1"));

        [HttpPost]
        [SwaggerOperation(Summary = "Primer Endpoint de Prueba")]
        [Route("NuevoJuego")]
        public async Task<IActionResult> PostNuevoJuego()
            => await Task.FromResult(Ok("¡Funciona!... Respuesta de prueba2"));

        [HttpPost]
        [SwaggerOperation(Summary = "Primer Endpoint de Prueba")]
        [Route("NuevaJugada")]
        public async Task<IActionResult> PostNuevaJugada()
            => await Task.FromResult(Ok("¡Funciona!... Respuesta de prueba3"));

    }
}
