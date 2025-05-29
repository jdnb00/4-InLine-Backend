using _4_InLine_Backend.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace _4_InLine_Backend.Infrastructure.Contexts
{
    public class AppOnlyDbContext : DbContext
    {
        public DbSet<Juego> Juegos { get; set; }

        public AppOnlyDbContext(DbContextOptions<AppOnlyDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Juego>(juego =>
            {
                juego.HasKey(j => j.IdJuego);

                // Value object embebido como Ganador
                juego.OwnsOne(j => j.Ganador);

                // Jugadas como colección de entidades
                juego.OwnsMany(j => j.Jugadas, jugadas =>
                {
                    jugadas.WithOwner();
                    jugadas.HasKey(j => j.Id);
                    jugadas.OwnsOne(j => j.Jugador); // Value object dentro de jugada
                });
            });
        }
    }
    public class AppOnlyDbContextFactory : IDesignTimeDbContextFactory<AppOnlyDbContext>
    {
        public AppOnlyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppOnlyDbContext>();
            optionsBuilder.UseSqlite("Data Source=app.db"); // Usa el mismo string que en DBCOntextExtensions.cs

            return new AppOnlyDbContext(optionsBuilder.Options);
        }
    }
}
