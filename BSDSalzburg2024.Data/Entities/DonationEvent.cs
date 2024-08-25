// <copyright file="DonationEvent.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

/// <summary>
/// DB entity representing a blood donation event.
/// </summary>
public partial class DonationEvent
{
    /// <summary>
    /// Gets or sets the ID of the donation event.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the location where the event takes place. A foreign key.
    /// </summary>
    public required string? LocationId { get; set; }

    public string? OrtDetail { get; set; }

    public DateTime? Datum { get; set; }

    public DateTime? ZeitVon { get; set; }

    public DateTime? ZeitBis { get; set; }

    public DateTime? ZeitAbfahrt { get; set; }

    public DateTime? ZeitRueckkehr { get; set; }

    public DateTime? ZeitBeginn { get; set; }

    public DateTime? ZeitEnde { get; set; }

    public string Typ { get; set; }

    public int? AnzKons { get; set; }

    public int? AnzBlGr { get; set; }

    public int? AnzWeg { get; set; }

    public string Kommentar { get; set; }

    /// <summary>
    /// Gets or sets the navigation property linking to the location where the event takes place.
    /// </summary>
    public virtual Location? Location { get; set; }

    /// <summary>
    /// Declarative mapping between this entity class and the DB table.
    /// </summary>
    /// <param name="entity">The builder.</param>
    internal static void EntityBuildAction(EntityTypeBuilder<DonationEvent> entity)
    {
        entity.HasKey(e => e.Id).HasFillFactor(90);

        entity.ToTable("tblSpendeaktion");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("SpendeaktionId");
        entity.Property(e => e.LocationId)
            .HasMaxLength(8)
            .IsUnicode(false)
            .HasColumnName("OrtId");
        entity.Property(e => e.OrtDetail)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("OrtDetail");
        entity.Property(e => e.Datum)
            .HasColumnType("smalldatetime")
            .HasColumnName("Datum");
        entity.Property(e => e.ZeitVon)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitVon");
        entity.Property(e => e.ZeitBis)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitBis");
        entity.Property(e => e.ZeitAbfahrt)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitAbfahrt");
        entity.Property(e => e.ZeitRueckkehr)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitRueckkehr");
        entity.Property(e => e.ZeitBeginn)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitBeginn");
        entity.Property(e => e.ZeitEnde)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitEnde");
        entity.Property(e => e.Typ)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("Typ");
        entity.Property(e => e.AnzKons)
            .HasColumnName("AnzKons");
        entity.Property(e => e.AnzBlGr)
            .HasColumnName("AnzBlGr");
        entity.Property(e => e.AnzWeg)
            .HasColumnName("AnzWeg");
        entity.Property(e => e.Kommentar)
            .HasMaxLength(120)
            .IsUnicode(false)
            .HasColumnName("Kommentar");
    }
}