using _4_InLine_Backend.Application.Dto;
using _4_InLine_Backend.Domain.Interfaces;
using MediatR;

namespace _4_InLine_Backend.Application.Queries.GetEstadoJuego
{
    public class GetEstadoJuegoHandler : IRequestHandler<GetEstadoJuegoQuery, GetEstadoJuegoResultDto>
    {
        private readonly IJuegoRepository _JuegoRepository;
       
        public GetEstadoJuegoHandler(IJuegoRepository juegoRepository)
        {
            _JuegoRepository = juegoRepository;
        }

        public async Task<GetEstadoJuegoResultDto> Handle(GetEstadoJuegoQuery request, CancellationToken cancellationToken)
        {
            var juego = await _JuegoRepository.GetEstadoJuego(request.IdJuego);

            var result = new GetEstadoJuegoResultDto()
            {
                Juego = new JuegoDto()
                {
                    Id = juego.IdJuego,
                    ColumnaMax = juego.ColumnasMax,
                    FilaMax = juego.FilasMax,
                    Finalizado = juego.Finalizado,
                    Ganador = new JugadorDto()
                    {
                        Id = juego.Ganador.Id,
                        Nombre = juego.Ganador.Nombre
                    }
                },
                Matriz = juego.Jugadas.Select(x => new JugadaDto()
                {
                    Id = x.Id,
                    IdJuego = x.IdJuego,
                    Jugador = new JugadorDto() 
                    {
                        Id = x.Jugador.Id,
                        Nombre = x.Jugador.Nombre
                    },
                    Columna = x.Columna,
                    Fila = x.Fila,
                    Marcada = x.Marcada
                }).ToList()
            };

            return await Task.FromResult(result);
        }
    }
}
