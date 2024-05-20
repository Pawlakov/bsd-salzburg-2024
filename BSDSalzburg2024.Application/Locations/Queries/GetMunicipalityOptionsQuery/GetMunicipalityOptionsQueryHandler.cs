// <copyright file="GetMunicipalityOptionsQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetMunicipalityOptionsQuery;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetMunicipalityOptionsQueryHandler
    : IRequestHandler<GetMunicipalityOptionsQuery, GetMunicipalityOptionsQueryResult>
{
    private readonly BsdDatabaseContext context;

    public GetMunicipalityOptionsQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<GetMunicipalityOptionsQueryResult> Handle(GetMunicipalityOptionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await this.context.Municipalities
            .OrderBy(x => x.Name)
            .Select(x => new
            {
                x.Id,
                x.Name,
            })
            .ToListAsync(cancellationToken);

        var items = entities
            .Select((entity, index) => new GetMunicipalityOptionsQueryResultItem(entity.Id, entity.Name))
            .ToList();

        return new GetMunicipalityOptionsQueryResult
        {
            Items = items,
        };
    }
}