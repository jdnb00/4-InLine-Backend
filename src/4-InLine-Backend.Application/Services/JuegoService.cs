using InLineBackend.Domain.Aggregate;
using InLineBackend.Domain.Interfaces;

namespace InLineBackend.Application.Services
{
    public class JuegoService(IJuegoRepository juegoRepository) : IJuegoService
    {
        private readonly IJuegoRepository _JuegoRepository = juegoRepository;

        public async Task<Juego?> GetEstadoJuego(string id)
        {
            return await _JuegoRepository.GetEstadoJuego(id);
        }

        public async Task SaveContext()
        {
           await _JuegoRepository.SaveAsync();
        }
    }
}
