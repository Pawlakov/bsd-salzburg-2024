// <copyright file="CreateLocationCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations;

using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Domain;
using BSDSalzburg2024.Domain.Entities;

using Mediator;

public class CreateLocationCommandHandler
    : ICommandHandler<CreateLocationCommand, string>
{
    private readonly IBaseRepository<Location, string> context;

    public CreateLocationCommandHandler(IBaseRepository<Location, string> context)
    {
        this.context = context;
    }

    public async ValueTask<string> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
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

        this.context.Add(entity);
        await this.context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}