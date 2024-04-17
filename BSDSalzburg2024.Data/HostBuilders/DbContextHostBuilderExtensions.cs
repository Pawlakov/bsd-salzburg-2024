namespace BSDSalzburg2024.Data.HostBuilders;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class DbContextHostBuilderExtensions
{
    public static IHostBuilder AddDbContextLocal(this IHostBuilder host)
    {
        host.ConfigureServices((context, services) =>
        {
            var connectionString = context.Configuration.GetConnectionString("BSD");
            Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(connectionString);

            services.AddDbContext<BsdDatabaseContext>(configureDbContext);
        });

        return host;
    }
}