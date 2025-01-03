﻿// <copyright file="DeleteMunicipalityCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Requests.Municipalities;
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
        var entity = await this.context.Municipalities.FindAsync([request.Id], cancellationToken: cancellationToken);

        this.context.Municipalities.Remove(entity);

        await this.context.SaveChangesAsync(cancellationToken);
    }
}