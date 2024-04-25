// <copyright file="TblSpendeHinderni.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
public partial class TblSpendeHinderni
{
    public int SpendeHindernisId { get; set; }

    public int? SpenderId { get; set; }

    public DateTime? DatumVon { get; set; }

    public DateTime? DatumBis { get; set; }

    public bool Dauerhaft { get; set; }

    public string SpendeHindernisTyp { get; set; }

    public string SpendeHindernisText { get; set; }

    public DateTime? ErfassungsDat { get; set; }

    public string Anmerkung { get; set; }

    public int? AbgewId { get; set; }

    public int? SpendeHinNrAs400 { get; set; }

    public string AenderungMitarbeiterId { get; set; }

    public DateTime? AenderungDatum { get; set; }

    public string AenderungTyp { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblSpendeHinderni> entity)
    {
        entity.HasKey(e => e.SpendeHindernisId).HasFillFactor(90);

        entity.ToTable("tblSpendeHindernis");

        entity.Property(e => e.SpendeHindernisId).HasColumnName("SpendeHindernisID");
        entity.Property(e => e.AenderungDatum).HasColumnType("smalldatetime");
        entity.Property(e => e.AenderungMitarbeiterId)
            .HasMaxLength(12)
            .IsUnicode(false);
        entity.Property(e => e.AenderungTyp)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.Anmerkung)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.DatumBis).HasColumnType("smalldatetime");
        entity.Property(e => e.DatumVon).HasColumnType("smalldatetime");
        entity.Property(e => e.ErfassungsDat).HasColumnType("smalldatetime");
        entity.Property(e => e.SpendeHinNrAs400).HasColumnName("SpendeHinNrAS400");
        entity.Property(e => e.SpendeHindernisText)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.SpendeHindernisTyp)
            .HasMaxLength(8)
            .IsUnicode(false);
        entity.Property(e => e.SpenderId).HasColumnName("SpenderID");
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
