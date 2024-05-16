// <copyright file="GetLocationQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetLocationQuery;

using MediatR;

public record GetLocationQuery
    : IRequest<GetLocationQueryResult>
{
    public GetLocationQuery(string id)
    {
        this.Id = id;
    }

    public string Id { get; set; }
}
