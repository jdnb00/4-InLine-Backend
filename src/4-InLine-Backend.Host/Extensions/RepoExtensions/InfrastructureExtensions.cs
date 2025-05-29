using InLineBackend.Domain.Interfaces;
using InLineBackend.Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace InLineBackend.Host.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
          services
            .AddScoped<IJuegoRepository, JuegoRepository>()

          ;
    }
}

