// <copyright file="ApplicationHostBuilderExtensions.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.HostBuilders;

using System.Linq;
using BSDSalzburg2024.Application.Requests.Validation;
using BSDSalzburg2024.Application.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class ApplicationHostBuilderExtensions
{
    public static IServiceCollection AddRequests(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(ApplicationHostBuilderExtensions).Assembly);
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(ApplicationHostBuilderExtensions).Assembly);

        var inputValidatorInterfaceType = typeof(IInputValidator<>);
        var list = typeof(ApplicationHostBuilderExtensions).Assembly.GetTypes()
                .Where(mytype => mytype.GetInterface(inputValidatorInterfaceType.Name) != null && !mytype.IsInterface && !mytype.IsAbstract)
                .ToList();

        foreach (var item in list)
        {
            var interfaceType = item.GetInterface(inputValidatorInterfaceType.Name);

            services.TryAddEnumerable(new ServiceDescriptor(interfaceType!, item, ServiceLifetime.Scoped));
            services.TryAdd(new ServiceDescriptor(item, item, ServiceLifetime.Scoped));
        }

        return services;
    }
}