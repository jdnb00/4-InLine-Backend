using _4_InLine_Backend.Application.Commnads.PostNuevoJuego;
using _4_InLine_Backend.Domain.Aggregate;

namespace _4_InLine_Backend.Application.Mappers
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
