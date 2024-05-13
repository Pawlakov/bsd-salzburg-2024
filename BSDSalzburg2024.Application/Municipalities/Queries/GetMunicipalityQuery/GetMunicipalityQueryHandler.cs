// <copyright file="GetMunicipalityQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityQuery;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Models;
using BSDSalzburg2024.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetMunicipalityQueryHandler
    : IRequestHandler<GetMunicipalityQuery, GetMunicipalityQueryResult>
{
    private readonly BsdDatabaseContext context;

    public GetMunicipalityQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<GetMunicipalityQueryResult> Handle(GetMunicipalityQuery request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Municipalities
            .Where(x => x.Id == request.Id)
            .Select(x => new
            {
                x.Id,
                x.Country,
                x.PostalCode,
                x.Name,
            })
            .FirstOrDefaultAsync(cancellationToken);

        return new GetMunicipalityQueryResult
        {
            Item = entity == null ? null : new GetMunicipalityQueryResultItem(entity.Id, Country.GetFromIso(entity.Country), entity.PostalCode, entity.Name),
        };
    }
}