﻿// <copyright file="GetLocationListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Base;
using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Data;
using Microsoft.EntityFrameworkCore;

public class GetLocationListQueryHandler
    : ListQueryHandler<GetLocationListQueryResultItem, string>
{
    public GetLocationListQueryHandler(BsdDatabaseContext context)
        : base(context)
    {
    }

    public override async Task<ListQueryResult<GetLocationListQueryResultItem, string>> Handle(ListQuery<GetLocationListQueryResultItem, string> request, CancellationToken cancellationToken)
    {
        var total = await this.Context.Locations
            .CountAsync(cancellationToken);

        var entities = await this.Context.Locations
            .OrderBy(x => x.Name)
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)
            .Select(x => new
            {
                x.Id,
                x.Name,
                x.PostalCode,
                x.Address,
                x.Hidden,
                Municipality = x.Municipality.Name,
                CanBeDeleted = x.DonationEvents == null || x.DonationEvents.Count == 0,
            })
            .ToListAsync(cancellationToken);

        var items = entities
            .Select((entity, index) => new GetLocationListQueryResultItem(request.PageSize * request.PageIndex + index + 1, entity.Id, entity.Name, entity.PostalCode, entity.Address, entity.Municipality, entity.Hidden, entity.CanBeDeleted))
            .ToList();

        return new ListQueryResult<GetLocationListQueryResultItem, string>
        {
            Items = items,
            ItemsTotal = total,
        };
    }
}