// <copyright file="TblSpendeaktion.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class TblSpendeaktion
{
    public int SpendeaktionId { get; set; }

    public string OrtId { get; set; }

    public string OrtDetail { get; set; }

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

    internal static void EntityBuildAction(EntityTypeBuilder<TblSpendeaktion> entity)
    {
        entity.HasKey(e => e.SpendeaktionId).HasFillFactor(90);

        entity.ToTable("tblSpendeaktion");

        entity.Property(e => e.SpendeaktionId).ValueGeneratedNever();
        entity.Property(e => e.Datum).HasColumnType("smalldatetime");
        entity.Property(e => e.Kommentar)
            .HasMaxLength(120)
            .IsUnicode(false);
        entity.Property(e => e.OrtDetail)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.OrtId)
            .HasMaxLength(8)
            .IsUnicode(false);
        entity.Property(e => e.Typ)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.ZeitAbfahrt).HasColumnType("smalldatetime");
        entity.Property(e => e.ZeitBeginn).HasColumnType("smalldatetime");
        entity.Property(e => e.ZeitBis).HasColumnType("smalldatetime");
        entity.Property(e => e.ZeitEnde).HasColumnType("smalldatetime");
        entity.Property(e => e.ZeitRueckkehr).HasColumnType("smalldatetime");
        entity.Property(e => e.ZeitVon).HasColumnType("smalldatetime");
    }
}
