// <copyright file="CreateMunicipalityCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.CreateMunicipalityCommand;

using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Data;
using BSDSalzburg2024.Data.Entities;
using FluentValidation;
using MediatR;

public class CreateMunicipalityCommandHandler
    : IRequestHandler<CreateMunicipalityCommand, int>
{
    private readonly BsdDatabaseContext context;
    private readonly IValidator<CreateMunicipalityCommand> validator;

    public CreateMunicipalityCommandHandler(BsdDatabaseContext context, IValidator<CreateMunicipalityCommand> validator)
    {
        this.context = context;
        this.validator = validator;
    }

    public async Task<int> Handle(CreateMunicipalityCommand request, CancellationToken cancellationToken)
    {
        /*this.validator.ValidateAndThrow(request);*/

        var entity = new Municipality
        {
            Id = request.Id,
            Name = request.Name,
            Country = request.Country,
            PostalCode = request.PostalCode,
        };

        this.context.Municipalities.Add(entity);
        await this.context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}