using _4_InLine_Backend.Domain.Aggregate;
using _4_InLine_Backend.Domain.Interfaces;
using _4_InLine_Backend.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _4_InLine_Backend.Infrastructure.Repositories
{
    public class JuegoRepository(AppOnlyDbContext context) : IJuegoRepository
    {
        private readonly AppOnlyDbContext Context = context;

        public async Task SaveAsync() => await Context.SaveChangesAsync();

        public async Task<Juego?> GetEstadoJuego(string id)
        {
            var juego = await Context.Juegos.Where(c => c.IdJuego == id).FirstOrDefaultAsync();
            return juego;
        }

        public async Task<Juego> PostNuevoJuego(Juego juegoNuevo)
        {
            await Context.AddAsync(juegoNuevo);
            return juegoNuevo;
        }
    }
}
