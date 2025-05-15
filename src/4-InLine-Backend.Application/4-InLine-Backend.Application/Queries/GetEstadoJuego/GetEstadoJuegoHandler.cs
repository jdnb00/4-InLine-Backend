using _4_InLine_Backend.Application.Dto;
using MediatR;

namespace _4_InLine_Backend.Application.Queries.GetEstadoJuego
{
    public class GetEstadoJuegoHandler : IRequestHandler<GetEstadoJuegoQuery, GetEstadoJuegoResultDto>
    {
        public async Task<GetEstadoJuegoResultDto> Handle(GetEstadoJuegoQuery request, CancellationToken cancellationToken)
        {
            //Busqueda en Bd de juego activo

            var estado = new GetEstadoJuegoResultDto()
            {
                Juego = new JuegoDto()
                {
                    Id =  Guid.NewGuid().ToString(),
                    ColumnaMax = 1,
                    FilaMax = 1,
                    Finalizado = true,
                    Ganador = new JugadorDto()
                },
                Matriz = new List<JugadaDto>() { }
            };

            return await Task.FromResult(estado);
        }
    }
}
