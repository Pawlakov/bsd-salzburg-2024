// <copyright file="DeleteMunicipalityCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Domain;
using BSDSalzburg2024.Domain.Entities;

using Mediator;

public class DeleteMunicipalityCommandHandler
    : ICommandHandler<DeleteMunicipalityCommand>
{
    private readonly IBaseRepository<Municipality, int> context;

    public DeleteMunicipalityCommandHandler(IBaseRepository<Municipality, int> context)
    {
        this.context = context;
    }

    public async ValueTask<Unit> Handle(DeleteMunicipalityCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.FindAsync(request.Id, cancellationToken: cancellationToken);

        this.context.Remove(entity);

        await this.context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}