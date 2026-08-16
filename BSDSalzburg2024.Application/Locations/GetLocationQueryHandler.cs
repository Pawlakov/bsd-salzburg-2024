// <copyright file="GetLocationQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Domain;

using Mediator;

using Microsoft.EntityFrameworkCore;

public class GetLocationQueryHandler
    : IQueryHandler<GetLocationQuery, GetLocationQueryResult>
{
    private readonly BsdDatabaseContext context;

    public GetLocationQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async ValueTask<GetLocationQueryResult> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Locations
            .Where(x => x.Id == request.Id)
            .Select(x => new
            {
                x.Id,
                x.MunicipalityId,
                x.Name,
                x.PostalCode,
                x.Address,
                x.Hidden,
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            return new GetLocationQueryResult
            {
                Item = null,
            };
        }

        return new GetLocationQueryResult
        {
            Item = new GetLocationQueryResultItem()
            {
                Id = entity.Id,
                MunicipalityId = entity.MunicipalityId,
                Name = entity.Name,
                PostalCode = entity.PostalCode,
                Address = entity.Address,
                Hidden = entity.Hidden,
            },
        };
    }
}