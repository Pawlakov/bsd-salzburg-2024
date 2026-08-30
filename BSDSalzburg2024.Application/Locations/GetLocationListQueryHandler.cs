// <copyright file="GetLocationListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Base;
using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Domain.Entities;

public class GetLocationListQueryHandler
    : ListQueryHandler<GetLocationListQueryResultItem, string, Location>
{
    public GetLocationListQueryHandler(IBaseRepository<Location, string> context)
        : base(context)
    {
    }

    public override ValueTask<ListQueryResult<GetLocationListQueryResultItem, string>> Handle(ListQuery<GetLocationListQueryResultItem, string> request, CancellationToken cancellationToken)
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
                x.Name,
                x.PostalCode,
                x.Address,
                x.Hidden,
                Municipality = x.Municipality.Name,
                CanBeDeleted = x.DonationEvents == null || x.DonationEvents.Count == 0,
            })
            .ToList();

        var items = entities
            .Select((entity, index) => new GetLocationListQueryResultItem()
            {
                Index = (request.PageSize * request.PageIndex) + index + 1,
                Id = entity.Id,
                Name = entity.Name,
                PostalCode = entity.PostalCode,
                Address = entity.Address,
                Municipality = entity.Municipality,
                Hidden = entity.Hidden,
                CanBeDeleted = entity.CanBeDeleted,
            })
            .ToList();

        var result = new ListQueryResult<GetLocationListQueryResultItem, string>
        {
            Items = items,
            ItemsTotal = total,
        };

        return ValueTask.FromResult(result);
    }
}