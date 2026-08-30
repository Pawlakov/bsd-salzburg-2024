// <copyright file="GetMunicipalityOptionsQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

public class GetMunicipalityOptionsQueryResultItem
{
    required public int Id { get; set; }

    required public string Label { get; set; }
}