using InLineBackend.Application.Services;
using InLineBackend.Domain.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace InLineBackend.Host.Extensions.ServiceExtensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services
                .AddScoped<IJuegoService, JuegoService>()

            ;

    }
}
