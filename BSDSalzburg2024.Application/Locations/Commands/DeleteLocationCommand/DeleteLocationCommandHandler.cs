// <copyright file="DeleteLocationCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.DeleteLocationCommand;

using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Data;
using MediatR;

public class DeleteLocationCommandHandler
    : IRequestHandler<DeleteLocationCommand>
{
    private readonly BsdDatabaseContext context;

    public DeleteLocationCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Locations.FindAsync([request.Id], cancellationToken: cancellationToken);

        this.context.Locations.Remove(entity);

        await this.context.SaveChangesAsync(cancellationToken);
    }
}
