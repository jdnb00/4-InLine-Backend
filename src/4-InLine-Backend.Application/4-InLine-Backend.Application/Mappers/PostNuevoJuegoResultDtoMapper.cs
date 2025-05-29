using InLineBackend.Application.Commnads.PostNuevoJuego;
using InLineBackend.Domain.Aggregate;

namespace InLineBackend.Application.Mappers
{
    public static class PostNuevoJuegoResultDtoMapper
    {
        public static PostNuevoJuegoResultDto Map(Juego data)
        {
            return new PostNuevoJuegoResultDto()
            {
                IdJuego = data.IdJuego,
                ColumnasMax = data.ColumnasMax,
                FilasMax = data.FilasMax,
                Finalizado = data.Finalizado
            };
        }
    }
}
