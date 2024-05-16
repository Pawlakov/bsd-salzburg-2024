// <copyright file="GetLocationListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetLocationListQuery;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetLocationListQueryHandler
    : IRequestHandler<GetLocationListQuery, GetLocationListQueryResult>
{
    private readonly BsdDatabaseContext context;

    public GetLocationListQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<GetLocationListQueryResult> Handle(GetLocationListQuery request, CancellationToken cancellationToken)
    {
        var total = await this.context.Locations
            .CountAsync(cancellationToken);

        var entities = await this.context.Locations
            .OrderBy(x => x.Name)
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)
            .Select(x => new
            {
                x.Id,
            })
            .ToListAsync(cancellationToken);

        var items = entities
            .Select((entity, index) => new GetLocationListQueryResultItem((request.PageSize * request.PageIndex) + index + 1, entity.Id))
            .ToList();

        return new GetLocationListQueryResult
        {
            Items = items,
            ItemsTotal = total,
        };
    }
}