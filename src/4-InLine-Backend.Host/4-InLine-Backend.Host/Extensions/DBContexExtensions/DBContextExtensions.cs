using _4_InLine_Backend.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace _4_InLine_Backend.Host.Extensions
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
