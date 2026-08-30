// <copyright file="GetMunicipalityOptionsQueryHandler.cs" company="Paweł Matusek">
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

public class GetMunicipalityOptionsQueryHandler
    : IQueryHandler<GetMunicipalityOptionsQuery, GetMunicipalityOptionsQueryResult>
{
    private readonly IBaseRepository<Municipality, int> context;

    public GetMunicipalityOptionsQueryHandler(IBaseRepository<Municipality, int> context)
    {
        this.context = context;
    }

    public ValueTask<GetMunicipalityOptionsQueryResult> Handle(GetMunicipalityOptionsQuery request, CancellationToken cancellationToken)
    {
        var entities = this.context.AsQueryable()
            .OrderBy(x => x.Name)
            .Select(x => new
            {
                x.Id,
                x.Name,
            })
            .ToList();

        var items = entities
            .Select((entity, index) => new GetMunicipalityOptionsQueryResultItem()
            {
                Id = entity.Id,
                Label = entity.Name,
            })
            .ToList();

        var result = new GetMunicipalityOptionsQueryResult
        {
            Items = items,
        };

        return ValueTask.FromResult(result);
    }
}