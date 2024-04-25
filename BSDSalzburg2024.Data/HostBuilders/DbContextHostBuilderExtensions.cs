// <copyright file="DbContextHostBuilderExtensions.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.HostBuilders;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/// <summary>
/// Container for extension methods used during the generic host build process.
/// </summary>
public static class DbContextHostBuilderExtensions
{
    /// <summary>
    /// Configures and adds the DB context to the collection of services.
    /// </summary>
    /// <param name="host">Host builder.</param>
    /// <returns>The same host builder.</returns>
    public static IHostBuilder AddDbContextLocal(this IHostBuilder host)
    {
        host.ConfigureServices((context, services) =>
        {
            var connectionString = context.Configuration.GetConnectionString("BSD");

            services.AddDbContext<BsdDatabaseContext>(o => o.UseSqlServer(connectionString));
        });

        return host;
    }
}