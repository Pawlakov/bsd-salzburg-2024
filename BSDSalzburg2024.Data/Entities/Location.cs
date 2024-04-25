// <copyright file="Location.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// DB entity representing a location.
/// </summary>
public partial class Location
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
    public virtual Municipality? Municipality { get; set; }

    /// <summary>
    /// Declarative mapping between this entity class and the DB table.
    /// </summary>
    /// <param name="entity">The builder.</param>
    internal static void EntityBuildAction(EntityTypeBuilder<Location> entity)
    {
        entity.HasKey(e => e.Id).HasFillFactor(90);

        entity.ToTable("tblOrt");

        entity.Property(e => e.Id)
            .HasMaxLength(8)
            .IsUnicode(false)
            .HasColumnName("OrtID");
        entity.Property(e => e.MunicipalityId)
            .HasColumnName("GemeindeID");
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(30)
            .IsUnicode(false)
            .HasColumnName("OrtName");
        entity.Property(e => e.PostalCode)
            .IsRequired()
            .HasMaxLength(5)
            .IsUnicode(false)
            .HasColumnName("OrtPlz");
        entity.Property(e => e.Address)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("OrtStrasse");
        entity.Property(e => e.Hidden)
            .HasColumnName("Unsichtbar");
    }
}
