// <copyright file="GetLocationListQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetLocationListQuery;

using MediatR;

public record GetLocationListQuery
    : IRequest<GetLocationListQueryResult>
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}
