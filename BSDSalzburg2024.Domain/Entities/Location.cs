// <copyright file="Location.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Domain.Entities;

using System.Collections.Generic;

/// <summary>
/// DB entity representing a location.
/// </summary>
public class Location
{
    /// <summary>
    /// Gets or sets the ID of the location. Up to 8 characters, chosen by the user.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the municipality where the location is located. A foreign key.
    /// </summary>
    public int MunicipalityId { get; set; }

    /// <summary>
    /// Gets or sets the postal code of the location.
    /// It can be different than the postal code of the municipality.
    /// </summary>
    public required string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the name of the location. Up to 30 characters.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the full address of the location. Up to 50 characters.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this location should be hidden from the UI.
    /// </summary>
    public bool Hidden { get; set; }

    /// <summary>
    /// Gets or sets the navigation property linking to the municipality containing this location.
    /// </summary>
    public Municipality? Municipality { get; set; }

    /// <summary>
    /// Gets or sets the navigation property, linking to the events taking place in this location.
    /// </summary>
    public ICollection<DonationEvent>? DonationEvents { get; set; }
}