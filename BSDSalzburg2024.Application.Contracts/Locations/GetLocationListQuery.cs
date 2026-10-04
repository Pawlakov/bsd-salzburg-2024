// <copyright file="GetLocationListQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using BSDSalzburg2024.Application.Requests.Base;

public record GetLocationListQuery() : ListQuery<GetLocationListQueryResultItem, string>;