using System.Diagnostics.CodeAnalysis;

namespace InLineBackend.Host
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                  .ConfigureAppConfiguration(config =>
                  {
                      IConfiguration configuration = config.Build();

                      //var appConfigurationConnection = configuration["AppConfigurationConnection"];
                      //var roleName = configuration["CloudRoleName"];
                      //if (!string.IsNullOrEmpty(appConfigurationConnection) && !string.IsNullOrEmpty(roleName))
                      //{
                      //    config.AddAzureAppConfigurationCustom(appConfigurationConnection, roleName)
                      //    .AddUserSecrets(Assembly.GetExecutingAssembly());
                      //}
                  })
                  //.ConfigureLogging()
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      webBuilder.UseStartup<Startup>();
                  });
        }
    }
}