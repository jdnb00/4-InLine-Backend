using System.Diagnostics.CodeAnalysis;

namespace _4_InLine_Backend.Host.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsConfig(this IServiceCollection @this)
        {
            @this.AddCors(options =>
            {
                options.AddPolicy("PoliticaCors",
                       builder =>
                       {
                               builder.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                           });
            });
            return @this;
        }

        public static IApplicationBuilder UseCorsConfigurations(this IApplicationBuilder @this)
        {
            @this.UseCors(x => x
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed(origin => true));

            @this.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return @this;
        }

    }
}
