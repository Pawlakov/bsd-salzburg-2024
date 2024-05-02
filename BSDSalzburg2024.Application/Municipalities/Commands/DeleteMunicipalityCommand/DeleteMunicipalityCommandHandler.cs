// <copyright file="DeleteMunicipalityCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.DeleteMunicipalityCommand;

using System;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Data;
using MediatR;

public class DeleteMunicipalityCommandHandler
    : IRequestHandler<DeleteMunicipalityCommand>
{
    private readonly BsdDatabaseContext context;

    public DeleteMunicipalityCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteMunicipalityCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Municipalities.FindAsync(request.Id, cancellationToken);
        if (entity == null)
        {
            throw new ArgumentException("Entity not found", nameof(request.Id));
        }

        this.context.Municipalities.Remove(entity);

        await this.context.SaveChangesAsync(cancellationToken);
    }
}