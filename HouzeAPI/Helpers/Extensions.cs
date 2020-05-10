using System;
using HouzeAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HouzeAPI.Helpers
{
    public static class Extensions
    {
        public static IWebHost MigrateDatabase<T>(this IWebHost webHost) where T : DbContext
        {
            // Manually run any pending migrations if configured to do so.
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (env == "Production")
            {
                var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

                var x = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate();
                }
            }
            return webHost;
        }
    }
}