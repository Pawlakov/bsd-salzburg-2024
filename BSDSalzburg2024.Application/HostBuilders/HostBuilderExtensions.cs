// <copyright file="HostBuilderExtensions.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.HostBuilders;

using BSDSalzburg2024.Application.Municipalities;
using BSDSalzburg2024.Application.Validation;

using FluentValidation;

using Mediator;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class HostBuilderExtensions
{
    public static IServiceCollection AddDataValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CreateMunicipalityCommandDataValidator).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }

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