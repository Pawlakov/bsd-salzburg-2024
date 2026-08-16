// <copyright file="GetLocationQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using Mediator;

public record GetLocationQuery(string Id) : IQuery<GetLocationQueryResult>;