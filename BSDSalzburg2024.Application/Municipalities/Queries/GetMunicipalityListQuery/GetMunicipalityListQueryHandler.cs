// <copyright file="GetMunicipalityListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using BSDSalzburg2024.Application.Base.Queries.ListQuery;
using BSDSalzburg2024.Application.Models;
using BSDSalzburg2024.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetMunicipalityListQueryHandler
    : ListQueryHandler<GetMunicipalityListQueryResultItem, int>
{
    public GetMunicipalityListQueryHandler(BsdDatabaseContext context)
        : base(context)
    {
    }

    public override async Task<ListQueryResult<GetMunicipalityListQueryResultItem, int>> Handle(ListQuery<GetMunicipalityListQueryResultItem, int> request, CancellationToken cancellationToken)
    {
        var total = await this.context.Municipalities
            .CountAsync(cancellationToken);

        var entities = await this.context.Municipalities
            .OrderBy(x => x.Name)
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)
            .Select(x => new
            {
                x.Id,
                x.Country,
                x.PostalCode,
                x.Name,
                CanBeDeleted = x.Locations == null || x.Locations.Count == 0,
            })
            .ToListAsync(cancellationToken);

        var items = entities
            .Select((entity, index) => new GetMunicipalityListQueryResultItem((request.PageSize * request.PageIndex) + index + 1, entity.Id, Country.GetFromIso(entity.Country), entity.PostalCode, entity.Name, entity.CanBeDeleted))
            .ToList();

        return new ListQueryResult<GetMunicipalityListQueryResultItem, int>
        {
            Items = items,
            ItemsTotal = total,
        };
    }
}