// <copyright file="GetMunicipalityListQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

using BSDSalzburg2024.Application.Requests.Base;

public record GetMunicipalityListQuery() : ListQuery<GetMunicipalityListQueryResultItem, int>;