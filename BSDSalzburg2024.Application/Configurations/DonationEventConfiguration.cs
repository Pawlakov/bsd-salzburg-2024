// <copyright file="DonationEventConfiguration.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Configurations;

using BSDSalzburg2024.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class DonationEventConfiguration
    : IEntityTypeConfiguration<DonationEvent>
{
    public void Configure(EntityTypeBuilder<DonationEvent> builder)
    {
        builder.HasKey(e => e.Id).HasFillFactor(90);

        builder.ToTable("tblSpendeaktion");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("SpendeaktionId");
        builder.Property(e => e.LocationId)
            .HasMaxLength(8)
            .IsUnicode(false)
            .HasColumnName("OrtId");
        builder.Property(e => e.OrtDetail)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("OrtDetail");
        builder.Property(e => e.Datum)
            .HasColumnType("smalldatetime")
            .HasColumnName("Datum");
        builder.Property(e => e.ZeitVon)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitVon");
        builder.Property(e => e.ZeitBis)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitBis");
        builder.Property(e => e.ZeitAbfahrt)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitAbfahrt");
        builder.Property(e => e.ZeitRueckkehr)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitRueckkehr");
        builder.Property(e => e.ZeitBeginn)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitBeginn");
        builder.Property(e => e.ZeitEnde)
            .HasColumnType("smalldatetime")
            .HasColumnName("ZeitEnde");
        builder.Property(e => e.Typ)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("Typ");
        builder.Property(e => e.AnzKons)
            .HasColumnName("AnzKons");
        builder.Property(e => e.AnzBlGr)
            .HasColumnName("AnzBlGr");
        builder.Property(e => e.AnzWeg)
            .HasColumnName("AnzWeg");
        builder.Property(e => e.Kommentar)
            .HasMaxLength(120)
            .IsUnicode(false)
            .HasColumnName("Kommentar");
    }
}