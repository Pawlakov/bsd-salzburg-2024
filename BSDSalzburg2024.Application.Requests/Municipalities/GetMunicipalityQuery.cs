// <copyright file="GetMunicipalityQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

using Mediator;

public sealed record class GetMunicipalityQuery(int Id) : IQuery<GetMunicipalityQueryResult>;