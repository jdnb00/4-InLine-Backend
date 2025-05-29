using _4_InLine_Backend.Domain.Aggregate;

namespace _4_InLine_Backend.Domain.Interfaces
{
    public interface IJuegoService
    {
        void SaveContext();
        Task<Juego?> GetEstadoJuego(string id);
        Task<Juego> DefinirGanador(Juego juego);
    }
}
