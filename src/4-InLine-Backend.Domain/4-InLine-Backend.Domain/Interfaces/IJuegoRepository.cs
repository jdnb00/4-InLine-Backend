using _4_InLine_Backend.Domain.Aggregate;

namespace _4_InLine_Backend.Domain.Interfaces
{
    public interface IJuegoRepository 
    {
        Task SaveAsync();
        Task<Juego?> GetEstadoJuego(string id);
        Task<Juego> NuevoJuego(Juego juegoNuevo);
        void BorrarJuegos();
    }
}
