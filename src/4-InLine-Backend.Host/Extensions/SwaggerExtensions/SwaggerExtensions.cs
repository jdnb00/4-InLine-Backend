using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace InLineBackend.Host.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection @this)
        {
            @this.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
             new OpenApiInfo
                 {
                 //Title = Assembly.GetExecutingAssembly().GetName().Name,
                     Title = "4InLine Api Rest",
                     Version = "v1"
                 });
                //Documentation
                c.EnableAnnotations();
            });
            return @this;
        }

        public static IApplicationBuilder UseSwaggerConfigurations(this IApplicationBuilder @this)
        {
            //if (EnvironmentHelper.IsProduction()) return @this;

            @this.UseSwagger(c =>
            {
                c.RouteTemplate = "4InLine/api/swagger/{documentName}/swagger.json";
            });
            @this.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/4InLine/api/swagger/v1/swagger.json", name: Assembly.GetExecutingAssembly().GetName().Name);
                c.RoutePrefix = "4InLine/api/swagger";
            });

            return @this;
        }

    }
}
