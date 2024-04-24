// <copyright file="CreateMunicipalityCommandHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.CreateMunicipalityCommand;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Enums;
using BSDSalzburg2024.Data;
using BSDSalzburg2024.Data.Entities;
using MediatR;

public class CreateMunicipalityCommandHandler : IRequestHandler<CreateMunicipalityCommand, int>
{
    private readonly BsdDatabaseContext context;

    public CreateMunicipalityCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<int> Handle(CreateMunicipalityCommand request, CancellationToken cancellationToken)
    {
        if (request.PostalCode != null)
        {
            if (request.PostalCode.Length != 4 && request.PostalCode.Length != 5)
            {
                throw new ArgumentException("Incorrect length", nameof(request.PostalCode));
            }

            if (request.PostalCode.Any(x => !char.IsDigit(x)))
            {
                throw new ArgumentException("Non-digit character", nameof(request.PostalCode));
            }
        }

        if (request.Country != null)
        {
            if (Country.GetFromIso(request.Country) == null)
            {
                throw new ArgumentException("Unknown country code", nameof(request.Country));
            }
        }

        var entity = new Municipality
        {
            Name = request.Name,
            Country = request.Country,
            PostalCode = request.PostalCode,
        };

        this.context.Municipalities.Add(entity);
        await this.context.SaveChangesAsync();
        return entity.Id;
    }
}