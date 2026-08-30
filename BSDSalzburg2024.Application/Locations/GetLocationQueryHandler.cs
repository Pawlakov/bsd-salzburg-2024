// <copyright file="GetLocationQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Domain.Entities;

using Mediator;

public class GetLocationQueryHandler
    : IQueryHandler<GetLocationQuery, GetLocationQueryResult>
{
    private readonly IBaseRepository<Location, string> context;

    public GetLocationQueryHandler(IBaseRepository<Location, string> context)
    {
        this.context = context;
    }

    public ValueTask<GetLocationQueryResult> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var entity = this.context.AsQueryable()
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
            .FirstOrDefault();

        var result = new GetLocationQueryResult
        {
            Item = entity switch
            {
                null => null,
                not null => new GetLocationQueryResultItem()
                {
                    Id = entity.Id,
                    MunicipalityId = entity.MunicipalityId,
                    Name = entity.Name,
                    PostalCode = entity.PostalCode,
                    Address = entity.Address,
                    Hidden = entity.Hidden,
                },
            },
        };

        return ValueTask.FromResult(result);
    }
}