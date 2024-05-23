// <copyright file="GetMunicipalityListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Base.Queries.ListQuery;
using BSDSalzburg2024.Application.Models;
using BSDSalzburg2024.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetMunicipalityListQueryHandler
    : IRequestHandler<ListQuery<GetMunicipalityListQueryResultItem, int>, ListQueryResult<GetMunicipalityListQueryResultItem, int>>
{
    private readonly BsdDatabaseContext context;

    public GetMunicipalityListQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<ListQueryResult<GetMunicipalityListQueryResultItem, int>> Handle(ListQuery<GetMunicipalityListQueryResultItem, int> request, CancellationToken cancellationToken)
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