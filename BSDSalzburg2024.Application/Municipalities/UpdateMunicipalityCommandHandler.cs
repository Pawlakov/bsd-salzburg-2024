// <copyright file="UpdateMunicipalityCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Domain.Entities;

using Mediator;

public class UpdateMunicipalityCommandHandler
    : ICommandHandler<UpdateMunicipalityCommand>
{
    private readonly IBaseRepository<Municipality, int> context;

    public UpdateMunicipalityCommandHandler(IBaseRepository<Municipality, int> context)
    {
        this.context = context;
    }

    public async ValueTask<Unit> Handle(UpdateMunicipalityCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.FindAsync(request.Id, cancellationToken: cancellationToken);

        entity.Name = request.Name;
        entity.Country = request.Country;
        entity.PostalCode = request.PostalCode;

        await this.context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}