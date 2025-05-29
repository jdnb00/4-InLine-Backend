using _4_InLine_Backend.Domain.Interfaces;
using _4_InLine_Backend.Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace _4_InLine_Backend.Host.Extensions
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

