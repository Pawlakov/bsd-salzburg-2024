// <copyright file="TblSpende.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class TblSpende
{
    public int SpendeId { get; set; }

    public int? SpendeaktionId { get; set; }

    public int? SpenderId { get; set; }

    public string SpendeArt { get; set; }

    /// <summary>
    /// KonserveID 7-stellig
    /// </summary>
    public int? KonserveId { get; set; }

    /// <summary>
    /// KonserveID 16-stellig
    /// </summary>
    public string KonserveId2 { get; set; }

    public string AbnehmerId { get; set; }

    public string AnamneseId { get; set; }

    public string Selbstausschluss { get; set; }

    public DateTime? Datum { get; set; }

    public DateTime? AnamneseZeit { get; set; }

    public DateTime? Beginnzeit { get; set; }

    public DateTime? Endzeit { get; set; }

    public int? Menge { get; set; }

    public string BeutelAnz { get; set; }

    public string BeutelProdCode { get; set; }

    public short? BlutdruckSys { get; set; }

    public short? BlutdruckDia { get; set; }

    public float? Hb { get; set; }

    public float? Temperatur { get; set; }

    public short? Gewicht { get; set; }

    public int? AbgewId { get; set; }

    public string AbgewGrundId { get; set; }

    public string AbgewText { get; set; }

    public DateTime? AbgewSpHinBis { get; set; }

    public bool AbgewSpHinDauerhaft { get; set; }

    public DateTime? AscheinZeit { get; set; }

    public bool AscheinUngueltig { get; set; }

    public string AscheinKommentar { get; set; }

    public bool NichtLegitimiert { get; set; }

    public bool LabWertProvisorisch { get; set; }

    public bool ExpBlutbank { get; set; }

    public DateTime? ExpBlutbankDatum { get; set; }

    public bool ExpZentrale { get; set; }

    public DateTime? ExpZentraleDatum { get; set; }

    public string AenderungMitarbeiterId { get; set; }

    public DateTime? AenderungDatum { get; set; }

    public string AenderungTyp { get; set; }

    public string AenderungOrt { get; set; }

    public int? AenderungSpendeaktionId { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblSpende> entity)
    {
        entity.HasKey(e => e.SpendeId).HasFillFactor(90);

        entity.ToTable("tblSpende");

        entity.Property(e => e.SpendeId)
            .ValueGeneratedNever()
            .HasColumnName("SpendeID");
        entity.Property(e => e.AbgewGrundId)
            .HasMaxLength(3)
            .IsUnicode(false);
        entity.Property(e => e.AbgewSpHinBis).HasColumnType("smalldatetime");
        entity.Property(e => e.AbgewText)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.AbnehmerId)
            .HasMaxLength(12)
            .IsUnicode(false)
            .HasColumnName("AbnehmerID");
        entity.Property(e => e.AenderungDatum).HasColumnType("smalldatetime");
        entity.Property(e => e.AenderungMitarbeiterId).HasMaxLength(12);
        entity.Property(e => e.AenderungOrt)
            .HasMaxLength(20)
            .IsUnicode(false);
        entity.Property(e => e.AenderungTyp)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.AnamneseId)
            .HasMaxLength(12)
            .IsUnicode(false)
            .HasColumnName("AnamneseID");
        entity.Property(e => e.AnamneseZeit).HasColumnType("smalldatetime");
        entity.Property(e => e.AscheinKommentar)
            .HasMaxLength(50)
            .HasColumnName("AScheinKommentar");
        entity.Property(e => e.AscheinUngueltig).HasColumnName("AScheinUngueltig");
        entity.Property(e => e.AscheinZeit)
            .HasColumnType("smalldatetime")
            .HasColumnName("AScheinZeit");
        entity.Property(e => e.Beginnzeit).HasColumnType("smalldatetime");
        entity.Property(e => e.BeutelAnz)
            .HasMaxLength(2)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.BeutelProdCode)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Datum).HasColumnType("smalldatetime");
        entity.Property(e => e.Endzeit).HasColumnType("smalldatetime");
        entity.Property(e => e.ExpBlutbankDatum).HasColumnType("smalldatetime");
        entity.Property(e => e.ExpZentraleDatum).HasColumnType("smalldatetime");
        entity.Property(e => e.Hb).HasColumnName("HB");
        entity.Property(e => e.KonserveId)
            .HasComment("KonserveID 7-stellig")
            .HasColumnName("KonserveID");
        entity.Property(e => e.KonserveId2)
            .HasMaxLength(16)
            .IsUnicode(false)
            .IsFixedLength()
            .HasComment("KonserveID 16-stellig")
            .HasColumnName("KonserveID2");
        entity.Property(e => e.Selbstausschluss)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.SpendeArt)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.SpendeaktionId).HasColumnName("SpendeaktionID");
        entity.Property(e => e.SpenderId).HasColumnName("SpenderID");
    }
}
