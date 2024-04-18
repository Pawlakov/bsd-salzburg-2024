// <copyright file="GetMunicipalityListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using BSDSalzburg2024.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetMunicipalityListQueryHandler
    : IRequestHandler<GetMunicipalityListQuery, List<MunicipalityListItem>>
{
    private readonly BsdDatabaseContext context;

    public GetMunicipalityListQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<List<MunicipalityListItem>> Handle(GetMunicipalityListQuery request, CancellationToken cancellationToken)
    {
        var entities = await this.context.TblGemeindes
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)
            .ToListAsync();

        return entities
            .Select(x => new MunicipalityListItem(x))
            .ToList();
    }
}