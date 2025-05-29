using InLineBackend.Domain.Aggregate;

namespace InLineBackend.Domain.Interfaces
{
    public interface IJuegoRepository 
    {
        Task SaveAsync();
        Task<Juego?> GetEstadoJuego(string id);
        Task<Juego> NuevoJuego(Juego juegoNuevo);
        void BorrarJuegos();
    }
}
