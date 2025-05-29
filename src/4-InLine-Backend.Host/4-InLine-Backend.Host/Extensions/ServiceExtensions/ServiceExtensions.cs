using _4_InLine_Backend.Application.Services;
using _4_InLine_Backend.Domain.Interfaces;

namespace _4_InLine_Backend.Host.Extensions.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services
                .AddScoped<IJuegoService, JuegoService>()

            ;

    }
}
