// <copyright file="GetMunicipalityListQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using MediatR;

public class GetMunicipalityListQuery 
    : IRequest<GetMunicipalityListQueryResult>
{
    public int PageIndex{ get; init; }

    public int PageSize { get; init; }
}
