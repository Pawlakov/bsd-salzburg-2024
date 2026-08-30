// <copyright file="Municipality.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Domain.Entities;

using System.Collections.Generic;

/// <summary>
/// DB entity representing a municipality (Gemeinde).
/// </summary>
public class Municipality
    : IKeyedEntity<int>
{
    /// <summary>
    /// Gets or sets the ID of the municipality assigned according to the offical ID of the municipality.
    /// A collision between the ID of an Austrian and a German municipality is possible.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the country where the munipality is located as a 2-character country code according to ISO 3166.
    /// </summary>
    required public string Country { get; set; }

    /// <summary>
    /// Gets or sets the postal code of the municipality.
    /// If the municipality is split between multiple postal codes, then it's the postal code where the seat of the municipality is located.
    /// 5 characters for Germany, 4 characters for Austria.
    /// </summary>
    required public string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the name of the municipality. Up to 50 characters.
    /// </summary>
    required public string Name { get; set; }

    /// <summary>
    /// Gets or sets the navigation property, linking to the locations located in this municipality.
    /// </summary>
    public ICollection<Location>? Locations { get; set; }
}