// <copyright file="GetMunicipalityOptionsQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetMunicipalityOptionsQuery;

using MediatR;

public record GetMunicipalityOptionsQuery
    : IRequest<GetMunicipalityOptionsQueryResult>
{
}
