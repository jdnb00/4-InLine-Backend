using InLineBackend.Application.Dto;
using InLineBackend.Domain.Interfaces;
using MediatR;

namespace InLineBackend.Application.Queries.GetEstadoJuego
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
                    Ganador = juego.Ganador
                },
                Matriz = juego.Jugadas.Select(x => new JugadaDto()
                {
                    Id = x.Id,
                    IdJuego = x.IdJuego,
                    Jugador = x.Jugador,
                    Columna = x.Columna,
                    Fila = x.Fila,
                    Marcada = x.Marcada
                }).ToList()
            };

            return await Task.FromResult(result);
        }
    }
}
