// <copyright file="ApplicationHostBuilderExtensions.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.HostBuilders;

using BSDSalzburg2024.Application.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationHostBuilderExtensions
{
    public static IServiceCollection AddRequests(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(ApplicationHostBuilderExtensions).Assembly);
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ApplicationHostBuilderExtensions).Assembly);

        return services;
    }
}