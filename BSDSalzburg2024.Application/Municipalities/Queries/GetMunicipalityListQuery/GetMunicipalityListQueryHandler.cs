// <copyright file="GetMunicipalityListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Models;
using BSDSalzburg2024.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetMunicipalityListQueryHandler
    : IRequestHandler<GetMunicipalityListQuery, GetMunicipalityListQueryResult>
{
    private readonly BsdDatabaseContext context;

    public GetMunicipalityListQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<GetMunicipalityListQueryResult> Handle(GetMunicipalityListQuery request, CancellationToken cancellationToken)
    {
        var total = await this.context.Municipalities
            .CountAsync();

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
            .ToListAsync();

        var items = entities
            .Select((entity, index) => new MunicipalityListItem(entity.Id, (request.PageSize * request.PageIndex) + index + 1, Country.GetFromIso(entity.Country), entity.PostalCode, entity.Name, entity.CanBeDeleted))
            .ToList();

        return new GetMunicipalityListQueryResult
        {
            Items = items,
            ItemsTotal = total,
        };
    }
}