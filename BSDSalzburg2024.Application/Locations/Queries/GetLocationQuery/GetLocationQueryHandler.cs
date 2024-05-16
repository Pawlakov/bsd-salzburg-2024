﻿// <copyright file="GetLocationQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetLocationQuery;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetLocationQueryHandler
    : IRequestHandler<GetLocationQuery, GetLocationQueryResult>
{
    private readonly BsdDatabaseContext context;

    public GetLocationQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<GetLocationQueryResult> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Locations
            .Where(x => x.Id == request.Id)
            .Select(x => new
            {
                x.Id,
            })
            .FirstOrDefaultAsync(cancellationToken);

        return new GetLocationQueryResult
        {
            Item = entity == null ? null : new GetLocationQueryResultItem(entity.Id),
        };
    }
}