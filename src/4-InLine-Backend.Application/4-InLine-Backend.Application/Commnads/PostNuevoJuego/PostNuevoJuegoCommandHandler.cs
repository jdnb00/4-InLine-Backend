using _4_InLine_Backend.Domain.Aggregate;
using _4_InLine_Backend.Domain.Interfaces;
using _4_InLine_Backend.Domain.ValueObjects;
using MediatR;

namespace _4_InLine_Backend.Application.Commnads.PostNuevoJuego
{
    public class PostNuevoJuegoCommandHandler : IRequestHandler<PostNuevoJuegoCommand, PostNuevoJuegoResultDto>
    {
        private readonly IJuegoRepository _JuegoRepository;

        public PostNuevoJuegoCommandHandler(IJuegoRepository juegoRepository)
        {
            _JuegoRepository = juegoRepository;
        }

        public async Task<PostNuevoJuegoResultDto> Handle(PostNuevoJuegoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //borrar toda la bd del juego actual y crear jueg nuevo
                var juegoNuevo = new Juego()
                {
                    IdJuego = Guid.NewGuid().ToString(),
                    ColumnasMax = request.Columna,
                    FilasMax = request.Fila,
                    Finalizado = false,
                    Ganador = null,
                    Jugadas = new List<Jugada>()
                };

                var data = await _JuegoRepository.PostNuevoJuego(juegoNuevo);
                //mapper
                var res = new PostNuevoJuegoResultDto()
                {

                };

                await _JuegoRepository.SaveAsync();
                return res;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error en Nuevo");
            }
        }
    }
}
