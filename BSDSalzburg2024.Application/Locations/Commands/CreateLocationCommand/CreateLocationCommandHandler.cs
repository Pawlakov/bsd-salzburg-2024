// <copyright file="CreateLocationCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.CreateLocationCommand;

using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Data;
using BSDSalzburg2024.Data.Entities;
using MediatR;

public class CreateLocationCommandHandler
    : IRequestHandler<CreateLocationCommand, string>
{
    private readonly BsdDatabaseContext context;

    public CreateLocationCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<string> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = new Location
        {
            Id = request.Id,
            MunicipalityId = request.MunicipalityId,
            PostalCode = request.PostalCode,
            Name = request.Name,
            Address = request.Address,
            Hidden = request.Hidden,
        };

        this.context.Locations.Add(entity);
        await this.context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
