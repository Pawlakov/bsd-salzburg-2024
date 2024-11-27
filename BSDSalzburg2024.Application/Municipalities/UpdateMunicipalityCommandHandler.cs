// <copyright file="UpdateMunicipalityCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Data;
using MediatR;

public class UpdateMunicipalityCommandHandler
    : IRequestHandler<UpdateMunicipalityCommand>
{
    private readonly BsdDatabaseContext context;

    public UpdateMunicipalityCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateMunicipalityCommand request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Municipalities.FindAsync([request.Id], cancellationToken: cancellationToken);

        entity.Name = request.Name;
        entity.Country = request.Country;
        entity.PostalCode = request.PostalCode;

        await this.context.SaveChangesAsync(cancellationToken);
    }
}