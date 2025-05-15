using _4_InLine_Backend.Application.Commnads.PostNuevoJuego;
using _4_InLine_Backend.Application.Queries.GetEstadoJuego;
using _4_InLine_Backend.Domain.Aggregate;
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
        [Route("EstadoJuego/{idJuego}")]
        public async Task<IActionResult> GetEstadoJuego(string idJuego)
        {
            var query = new GetEstadoJuegoQuery(idJuego);
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Primer Endpoint de Prueba")]
        [Route("NuevoJuego/{columna}/{fila}")]
        public async Task<IActionResult> PostNuevoJuego(int columna, int fila)
        {
            var command = new PostNuevoJuegoCommand(columna, fila);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Primer Endpoint de Prueba")]
        [Route("NuevaJugada")]
        public async Task<IActionResult> PostNuevaJugada()
            => await Task.FromResult(Ok("¡Funciona!... Respuesta de prueba3"));

    }
}
