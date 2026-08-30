// <copyright file="HostBuilderExtensions.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Infrastructure.HostBuilders;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Domain.Entities;
using BSDSalzburg2024.Infrastructure;
using BSDSalzburg2024.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class HostBuilderExtensions
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
            services.AddScoped<IBaseRepository<Municipality, int>, EntityRepository<Municipality, int>>();
            services.AddScoped<IBaseRepository<Location, string>, EntityRepository<Location, string>>();
            services.AddScoped<IBaseRepository<Donor, int>, EntityRepository<Donor, int>>();
            services.AddScoped<IBaseRepository<DonationEvent, int>, EntityRepository<DonationEvent, int>>();
        });

        return host;
    }
}