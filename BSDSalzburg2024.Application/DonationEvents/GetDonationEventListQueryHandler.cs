﻿// <copyright file="GetDonationEventListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.DonationEvents;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Base;
using BSDSalzburg2024.Application.Requests.DonationEvents;
using BSDSalzburg2024.Data;
using Microsoft.EntityFrameworkCore;

public class GetDonationEventListQueryHandler
    : ListQueryHandler<GetDonationEventListQueryResultItem, int>
{
    public GetDonationEventListQueryHandler(BsdDatabaseContext context)
        : base(context)
    {
    }

    public override async Task<ListQueryResult<GetDonationEventListQueryResultItem, int>> Handle(ListQuery<GetDonationEventListQueryResultItem, int> request, CancellationToken cancellationToken)
    {
        var total = await this.Context.DonationEvents
            .CountAsync(cancellationToken);

        var entities = await this.Context.DonationEvents
            .OrderByDescending(x => x.ZeitVon)
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)
            .Select(x => new
            {
                x.Id,
                CanBeDeleted = true,
            })
            .ToListAsync(cancellationToken);

        var items = entities
            .Select((entity, index) => new GetDonationEventListQueryResultItem((request.PageSize * request.PageIndex) + index + 1, entity.Id, entity.CanBeDeleted))
            .ToList();

        return new ListQueryResult<GetDonationEventListQueryResultItem, int>
        {
            Items = items,
            ItemsTotal = total,
        };
    }
}