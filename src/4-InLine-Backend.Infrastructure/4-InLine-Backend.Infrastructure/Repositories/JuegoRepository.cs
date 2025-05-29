using InLineBackend.Domain.Aggregate;
using InLineBackend.Domain.Interfaces;
using InLineBackend.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InLineBackend.Infrastructure.Repositories
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
        public async Task<Juego> NuevoJuego(Juego juegoNuevo)
        {
            await Context.Juegos.AddAsync(juegoNuevo);
            return juegoNuevo;
        }
        public void BorrarJuegos()
        {
            context.Juegos.RemoveRange(context.Juegos);
        }


    }
}
