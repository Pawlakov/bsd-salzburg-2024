// <copyright file="CreateMunicipalityCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Domain;
using BSDSalzburg2024.Domain.Entities;

using Mediator;

public class CreateMunicipalityCommandHandler
    : ICommandHandler<CreateMunicipalityCommand, int>
{
    private readonly BsdDatabaseContext context;

    public CreateMunicipalityCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async ValueTask<int> Handle(CreateMunicipalityCommand request, CancellationToken cancellationToken)
    {
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