// <copyright file="TblSpendeHinderni.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
