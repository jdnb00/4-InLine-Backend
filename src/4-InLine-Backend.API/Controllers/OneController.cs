using InLineBackend.Application.Commnads.PostNuevaJugada;
using InLineBackend.Application.Commnads.PostNuevoJuego;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace InLineBackend.API.Controllers
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

        [HttpPost]
        [SwaggerOperation(Summary = "Endpoint para Crear un Nuevo Juego")]
        [Route("NuevoJuego/{columna}/{fila}")]
        public async Task<IActionResult> PostNuevoJuego(int columna, int fila)
        {
            var command = new PostNuevoJuegoCommand(columna, fila);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Endpoint para agregar una nueva jugada")]
        [Route("NuevaJugada/{idJuego}/{jugador}/{columna}")]
        public async Task<IActionResult> PostNuevaJugada(string idJuego, int jugador, int columna)
        {
            var command = new PostNuevaJugadaCommand(idJuego, jugador, columna);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

    }
}
