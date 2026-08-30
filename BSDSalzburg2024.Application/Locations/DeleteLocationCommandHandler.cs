// <copyright file="DeleteLocationCommandHandler.cs" company="Paweł Matusek">
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

public class DeleteLocationCommandHandler
    : ICommandHandler<DeleteLocationCommand>
{
    private readonly IBaseRepository<Location, string> context;

    public DeleteLocationCommandHandler(IBaseRepository<Location, string> context)
    {
        this.context = context;
    }

    public async ValueTask<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.FindAsync(request.Id, cancellationToken: cancellationToken);
        if (entity is not null)
        {
            this.context.Remove(entity);

            await this.context.SaveChangesAsync(cancellationToken);
        }

        return Unit.Value;
    }
}