using InLineBackend.Application.Services;
using InLineBackend.Domain.Interfaces;

namespace InLineBackend.Host.Extensions.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services
                .AddScoped<IJuegoService, JuegoService>()

            ;

    }
}
