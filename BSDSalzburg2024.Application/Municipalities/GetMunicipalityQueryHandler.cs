// <copyright file="GetMunicipalityQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Requests.Models;
using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Domain;

using Mediator;

using Microsoft.EntityFrameworkCore;

public class GetMunicipalityQueryHandler
    : IQueryHandler<GetMunicipalityQuery, GetMunicipalityQueryResult>
{
    private readonly BsdDatabaseContext context;

    public GetMunicipalityQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async ValueTask<GetMunicipalityQueryResult> Handle(GetMunicipalityQuery request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Municipalities
            .Where(x => x.Id == request.Id)
            .Select(x => new
            {
                x.Id,
                x.Country,
                x.PostalCode,
                x.Name,
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            return new GetMunicipalityQueryResult
            {
                Item = null,
            };
        }

        return new GetMunicipalityQueryResult
        {
            Item = new GetMunicipalityQueryResultItem()
            {
                Id = entity.Id,
                Country = Country.GetFromIso(entity.Country),
                PostalCode = entity.PostalCode,
                Name = entity.Name,
            },
        };
    }
}