using _4_InLine_Backend.Application.Mappers;
using _4_InLine_Backend.Domain.Aggregate;
using _4_InLine_Backend.Domain.Interfaces;
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
                //Borrar toda la bd del juego actual y crear jueg nuevo
                _JuegoRepository.BorrarJuego();
                //Crear Nuevo Juego
                var data = await _JuegoRepository.NuevoJuego(Juego.Crear(request.Columna, request.Fila));
                //Mapper
                var res = PostNuevoJuegoResultDtoMapper.Map(data);
                //Guardar Contexto
                await _JuegoRepository.SaveAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error en Nuevo" + ex.ToString());
            }
        }
    }
}
