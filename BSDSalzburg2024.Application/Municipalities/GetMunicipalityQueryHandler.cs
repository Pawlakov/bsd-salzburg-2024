// <copyright file="GetMunicipalityQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Models;
using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Domain.Entities;

using Mediator;

public class GetMunicipalityQueryHandler
    : IQueryHandler<GetMunicipalityQuery, GetMunicipalityQueryResult>
{
    private readonly IBaseRepository<Municipality, int> context;

    public GetMunicipalityQueryHandler(IBaseRepository<Municipality, int> context)
    {
        this.context = context;
    }

    public ValueTask<GetMunicipalityQueryResult> Handle(GetMunicipalityQuery request, CancellationToken cancellationToken)
    {
        var entity = this.context.AsQueryable()
            .Where(x => x.Id == request.Id)
            .Select(x => new
            {
                x.Id,
                x.Country,
                x.PostalCode,
                x.Name,
            })
            .FirstOrDefault();

        var result = new GetMunicipalityQueryResult
        {
            Item = entity switch
            {
                null => null,
                _ => new GetMunicipalityQueryResultItem()
                {
                    Id = entity.Id,
                    Country = Country.GetFromIso(entity.Country),
                    PostalCode = entity.PostalCode,
                    Name = entity.Name,
                },
            },
        };

        return ValueTask.FromResult(result);
    }
}