// <copyright file="GetMunicipalityOptionsQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using MediatR;

public record GetMunicipalityOptionsQuery
    : IRequest<GetMunicipalityOptionsQueryResult>
{
}
