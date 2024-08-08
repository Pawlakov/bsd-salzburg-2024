// <copyright file="TblSpender.cs" company="Paweł Matusek">
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
public partial class TblSpender
{
    public int SpenderId { get; set; }

    public string Vorname { get; set; }

    public string Nachname { get; set; }

    public string Titel { get; set; }

    public DateTime? Geburtsdatum { get; set; }

    public string Geschlecht { get; set; }

    public int? GemeindeId { get; set; }

    public string Strasse { get; set; }

    public string Land { get; set; }

    public string Plz { get; set; }

    public string Ort { get; set; }

    public string TelPrivat { get; set; }

    public string TelBeruf { get; set; }

    public string TelHandy { get; set; }

    public string Email { get; set; }

    public short? SpendenAnzahl { get; set; }

    public DateTime? SpendenLetzte { get; set; }

    public string Blutgruppe { get; set; }

    public string Phaenotyp { get; set; }

    public bool AusweisNoetig { get; set; }

    public DateTime? AusweisLetzter { get; set; }

    public bool EinladungBrief { get; set; }

    public bool EinladungEmail { get; set; }

    public bool EinladungSms { get; set; }

    public bool EinladungNurSms { get; set; }

    public bool EinladungKeine { get; set; }

    public string Kommentar { get; set; }

    public string KompanieFirma { get; set; }

    public string Status { get; set; }

    public bool ExpZentrale { get; set; }

    public DateTime? ExpZentraleDatum { get; set; }

    public string AenderungMitarbeiterId { get; set; }

    public DateTime? AenderungDatum { get; set; }

    public string AenderungTyp { get; set; }

    public string AenderungOrt { get; set; }

    public int? AenderungSpendeaktionId { get; set; }

    public int? ProgesaId { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblSpender> entity)
    {
        entity.HasKey(e => e.SpenderId).HasFillFactor(90);

        entity.ToTable("tblSpender");

        entity.Property(e => e.SpenderId).ValueGeneratedNever();
        entity.Property(e => e.AenderungDatum).HasColumnType("smalldatetime");
        entity.Property(e => e.AenderungMitarbeiterId)
            .HasMaxLength(12)
            .IsUnicode(false);
        entity.Property(e => e.AenderungOrt)
            .HasMaxLength(20)
            .IsUnicode(false);
        entity.Property(e => e.AenderungTyp)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.AusweisLetzter).HasColumnType("smalldatetime");
        entity.Property(e => e.Blutgruppe)
            .HasMaxLength(2)
            .IsUnicode(false);
        entity.Property(e => e.EinladungNurSms).HasColumnName("EinladungNurSMS");
        entity.Property(e => e.EinladungSms).HasColumnName("EinladungSMS");
        entity.Property(e => e.Email)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("email");
        entity.Property(e => e.ExpZentraleDatum).HasColumnType("smalldatetime");
        entity.Property(e => e.Geburtsdatum).HasColumnType("smalldatetime");
        entity.Property(e => e.Geschlecht)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.Kommentar)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.KompanieFirma)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Land)
            .HasMaxLength(3)
            .IsUnicode(false);
        entity.Property(e => e.Nachname)
            .HasMaxLength(40)
            .IsUnicode(false);
        entity.Property(e => e.Ort)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Phaenotyp)
            .HasMaxLength(6)
            .IsUnicode(false);
        entity.Property(e => e.Plz)
            .HasMaxLength(8)
            .IsUnicode(false);
        entity.Property(e => e.ProgesaId).HasColumnName("ProgesaID");
        entity.Property(e => e.SpendenLetzte).HasColumnType("smalldatetime");
        entity.Property(e => e.Status)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.Strasse)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.TelBeruf)
            .HasMaxLength(25)
            .IsUnicode(false);
        entity.Property(e => e.TelHandy)
            .HasMaxLength(25)
            .IsUnicode(false);
        entity.Property(e => e.TelPrivat)
            .HasMaxLength(25)
            .IsUnicode(false);
        entity.Property(e => e.Titel)
            .HasMaxLength(30)
            .IsUnicode(false);
        entity.Property(e => e.Vorname)
            .HasMaxLength(40)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
