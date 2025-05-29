using InLineBackend.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace InLineBackend.Host.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DBContextExtensions
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection @this, IConfiguration Configuration)
        {
            @this
              .AddDbContext<AppOnlyDbContext>(options => options.UseSqlite("Data Source=app.db"))
            ;

            return @this;
        }

    }
}
