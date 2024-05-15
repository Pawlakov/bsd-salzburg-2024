// <copyright file="GetLocationQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetLocationQuery;

using MediatR;

public record GetLocationQuery
    : IRequest<GetLocationQueryResult>
{
    public GetLocationQuery(int id)
    {
        this.Id = id;
    }

    public int Id { get; set; }
}
