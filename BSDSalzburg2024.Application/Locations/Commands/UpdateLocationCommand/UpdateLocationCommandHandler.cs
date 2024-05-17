// <copyright file="UpdateLocationCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.UpdateLocationCommand;

using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Data;
using MediatR;

public class UpdateLocationCommandHandler
    : IRequestHandler<UpdateLocationCommand>
{
    private readonly BsdDatabaseContext context;

    public UpdateLocationCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Locations.FindAsync([request.Id], cancellationToken: cancellationToken);

        await this.context.SaveChangesAsync(cancellationToken);
    }
}