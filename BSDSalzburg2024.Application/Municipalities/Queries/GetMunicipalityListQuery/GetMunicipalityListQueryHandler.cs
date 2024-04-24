// <copyright file="GetMunicipalityListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Enums;
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
            .ToListAsync();

        var items = entities
            .Select((entity, index) => new MunicipalityListItem
            {
                Id = entity.Id,
                Index = (request.PageSize * request.PageIndex) + index + 1,
                Country = Country.GetFromIso(entity.Country),
                PostalCode = entity.PostalCode,
                Name = entity.Name,
            })
            .ToList();

        return new GetMunicipalityListQueryResult
        {
            Items = items,
            ItemsTotal = total,
        };
    }
}