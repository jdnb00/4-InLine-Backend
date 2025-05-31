using InLineBackend.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;

namespace InLineBackend.Infrastructure.Contexts
{
    [ExcludeFromCodeCoverage]
    public class AppOnlyDbContext : DbContext
    {
        public virtual DbSet<Juego> Juegos { get; set; }

        public AppOnlyDbContext(DbContextOptions<AppOnlyDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Juego>(juego =>
            {
                juego.HasKey(j => j.IdJuego);

                // Jugadas como colección de entidades
                juego.OwnsMany(j => j.Jugadas, jugadas =>
                {
                    jugadas.WithOwner();
                    jugadas.HasKey(j => j.Id);
                });
            });
        }
    }

    [ExcludeFromCodeCoverage]
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
