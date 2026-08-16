// <copyright file="UpdateLocationCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations;

using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Domain;

using Mediator;

public class UpdateLocationCommandHandler
    : ICommandHandler<UpdateLocationCommand>
{
    private readonly BsdDatabaseContext context;

    public UpdateLocationCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async ValueTask<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Locations.FindAsync([request.Id], cancellationToken: cancellationToken);

        entity.MunicipalityId = request.MunicipalityId;
        entity.PostalCode = request.PostalCode;
        entity.Name = request.Name;
        entity.Address = request.Address;
        entity.Hidden = request.Hidden;

        await this.context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}