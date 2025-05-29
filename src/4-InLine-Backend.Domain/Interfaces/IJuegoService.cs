using InLineBackend.Domain.Aggregate;

namespace InLineBackend.Domain.Interfaces
{
    public interface IJuegoService
    {
        Task SaveContext();
        Task<Juego?> GetEstadoJuego(string id);
    }
}
