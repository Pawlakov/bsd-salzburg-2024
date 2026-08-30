// <copyright file="GetMunicipalityListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Base;
using BSDSalzburg2024.Application.Requests.Models;
using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Domain.Entities;

public class GetMunicipalityListQueryHandler
    : ListQueryHandler<GetMunicipalityListQueryResultItem, int, Municipality>
{
    public GetMunicipalityListQueryHandler(IBaseRepository<Municipality, int> context)
        : base(context)
    {
    }

    public override ValueTask<ListQueryResult<GetMunicipalityListQueryResultItem, int>> Handle(ListQuery<GetMunicipalityListQueryResultItem, int> request, CancellationToken cancellationToken)
    {
        var total = this.Context.AsQueryable()
            .Count();

        var entities = this.Context.AsQueryable()
            .OrderBy(x => x.Name)
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)
            .Select(x => new
            {
                x.Id,
                x.Country,
                x.PostalCode,
                x.Name,
                CanBeDeleted = x.Locations == null || x.Locations.Count == 0,
            })
            .ToList();

        var items = entities
            .Select((entity, index) => new GetMunicipalityListQueryResultItem()
            {
                Index = request.PageSize * request.PageIndex + index + 1,
                Id = entity.Id,
                Country = Country.GetFromIso(entity.Country),
                PostalCode = entity.PostalCode,
                Name = entity.Name,
                CanBeDeleted = entity.CanBeDeleted,
            })
            .ToList();

        var result = new ListQueryResult<GetMunicipalityListQueryResultItem, int>
        {
            Items = items,
            ItemsTotal = total,
        };

        return ValueTask.FromResult(result);
    }
}