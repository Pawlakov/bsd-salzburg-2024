// <copyright file="Donor.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// DB entity representing a donor.
/// </summary>
public class Donor
{
    /// <summary>
    /// Gets or sets the ID of the donor.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the family name (last name) of the donor. Up to 40 characters.
    /// </summary>
    public string? FamilyName { get; set; }

    /// <summary>
    /// Gets or sets the given name (first name) of the donor. Up to 40 characters.
    /// </summary>
    public string? GivenName { get; set; }

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

    internal static void EntityBuildAction(EntityTypeBuilder<Donor> entity)
    {
        entity.HasKey(e => e.Id).HasFillFactor(90);

        entity.ToTable("tblSpender");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("SpenderId");
        entity.Property(e => e.FamilyName)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("Nachname");
        entity.Property(e => e.GivenName)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("Vorname");

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
    }
}