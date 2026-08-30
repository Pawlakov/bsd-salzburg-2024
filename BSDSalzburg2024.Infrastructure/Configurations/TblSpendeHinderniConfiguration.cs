// <copyright file="TblSpendeHinderniConfiguration.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Infrastructure.Configurations;

using BSDSalzburg2024.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
internal sealed class TblSpendeHinderniConfiguration
    : IEntityTypeConfiguration<TblSpendeHinderni>
{
    public void Configure(EntityTypeBuilder<TblSpendeHinderni> builder)
    {
        builder.HasKey(e => e.SpendeHindernisId).HasFillFactor(90);

        builder.ToTable("tblSpendeHindernis");

        builder.Property(e => e.SpendeHindernisId).HasColumnName("SpendeHindernisID");
        builder.Property(e => e.AenderungDatum).HasColumnType("smalldatetime");
        builder.Property(e => e.AenderungMitarbeiterId)
            .HasMaxLength(12)
            .IsUnicode(false);
        builder.Property(e => e.AenderungTyp)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.Anmerkung)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.DatumBis).HasColumnType("smalldatetime");
        builder.Property(e => e.DatumVon).HasColumnType("smalldatetime");
        builder.Property(e => e.ErfassungsDat).HasColumnType("smalldatetime");
        builder.Property(e => e.SpendeHinNrAs400).HasColumnName("SpendeHinNrAS400");
        builder.Property(e => e.SpendeHindernisText)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.SpendeHindernisTyp)
            .HasMaxLength(8)
            .IsUnicode(false);
        builder.Property(e => e.SpenderId).HasColumnName("SpenderID");
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
