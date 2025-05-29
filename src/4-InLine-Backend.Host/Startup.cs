using InLineBackend.Host.Extensions;
using System.Reflection;

namespace InLineBackend.Host
{
    public class Startup
    {
        private IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
              .AddDbContexts(Configuration)
              //.AddHandlersServices()
              .AddRepositories()
              .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
              .AddControllers()
            ;
            //services.AddControllers();
            //services.AddADConfigurations();
            
            services.AddEndpointsApiExplorer();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCorsConfig();
            services.AddSwaggerConfig();
            
            //services.AddAuthenticationConfig();
            //services.AddHealthChecksConfigurations(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCorsConfigurations();
            app.UseSwaggerConfigurations();

            //app.UseMiddleware<ErrorHandlingMiddleware>();
            //app.UseEnvConfigurations(env);
            //app.UseHealthCheckConfigurations();

        }

    }
}
