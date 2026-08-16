// <copyright file="HostBuilderExtensions.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.HostBuilders;

using BSDSalzburg2024.Application;
using BSDSalzburg2024.Application.Municipalities;
using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Application.Validation;

using FluentValidation;

using Mediator;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class HostBuilderExtensions
{
    public static IServiceCollection AddRequests(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.Assemblies =
            [
                typeof(CreateMunicipalityCommand).Assembly,
                typeof(CreateMunicipalityCommandHandler).Assembly,
            ];
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        return services;
    }
}