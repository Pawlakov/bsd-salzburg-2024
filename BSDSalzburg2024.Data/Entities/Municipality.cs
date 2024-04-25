// <copyright file="Municipality.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// DB entity representing a municipality (Gemeinde).
/// </summary>
public class Municipality
{
    /// <summary>
    /// Gets or sets the ID of the municipality assigned according to the offical ID of the municipality.
    /// A collision between the ID of an Austrian and a German municipality is possible.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the country where the munipality is located as a 2-character country code according to ISO 3166.
    /// </summary>
    public required string Country { get; set; }

    /// <summary>
    /// Gets or sets the postal code of the municipality.
    /// If the municipality is split between multiple postal codes, then it's the postal code where the seat of the municipality is located.
    /// 5 characters for Germany, 4 characters for Austria.
    /// </summary>
    public required string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the name of the municipality. Up to 50 characters.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the navigation property, linking to the locations located in this municipality.
    /// </summary>
    public virtual ICollection<Location>? Locations { get; set; }

    /// <summary>
    /// Declarative mapping between this entity class and the DB table.
    /// </summary>
    /// <param name="entity">The builder.</param>
    internal static void EntityBuildAction(EntityTypeBuilder<Municipality> entity)
    {
        entity.HasKey(e => e.Id).HasFillFactor(90);

        entity.ToTable("tblGemeinde");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("GemeindeID");
        entity.Property(e => e.Country)
            .IsRequired()
            .HasMaxLength(3)
            .IsUnicode(false)
            .HasColumnName("GemeindeLand");
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("GemeindeName");
        entity.Property(e => e.PostalCode)
            .IsRequired()
            .HasMaxLength(5)
            .IsUnicode(false)
            .HasColumnName("GemeindePLZ");

        entity.HasMany(e => e.Locations)
            .WithOne(e => e.Municipality)
            .HasForeignKey(e => e.MunicipalityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
