using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.API
{
    public static class Extensions
    {
        /// <summary>
        ///     Auto migrate version of database from migrations
        /// </summary>
        public static IApplicationBuilder UseAutoMigrateDatabase<TDbContext>(this IApplicationBuilder builder)
            where TDbContext : DbContext
        {
            using (var serviceScope =
                builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<TDbContext>().Database.Migrate();
            }

            return builder;
        }
    }
}