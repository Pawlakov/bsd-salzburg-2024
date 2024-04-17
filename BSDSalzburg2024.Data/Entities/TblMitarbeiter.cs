// <copyright file="TblMitarbeiter.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class TblMitarbeiter
{
    public string MitarbeiterId { get; set; }

    public string Vorname { get; set; }

    public string Nachname { get; set; }

    public string Titel { get; set; }

    public DateTime? Geburtsdatum { get; set; }

    public string Geschlecht { get; set; }

    public string Funktion { get; set; }

    public string Land { get; set; }

    public string Plz { get; set; }

    public string Ort { get; set; }

    public string Straße { get; set; }

    public string TelBeruf { get; set; }

    public string TelHandy { get; set; }

    public string TelPrivat { get; set; }

    public string Email { get; set; }

    public int? GemeindeId { get; set; }

    public string Bagwinid { get; set; }

    public bool Aktiv { get; set; }

    public bool AusAltdaten { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblMitarbeiter> entity)
    {
        entity.HasKey(e => e.MitarbeiterId).HasFillFactor(90);

        entity.ToTable("tblMitarbeiter");

        entity.Property(e => e.MitarbeiterId)
            .HasMaxLength(12)
            .IsUnicode(false);
        entity.Property(e => e.Bagwinid)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("BAGWINId");
        entity.Property(e => e.Email)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("email");
        entity.Property(e => e.Funktion)
            .HasMaxLength(30)
            .IsUnicode(false);
        entity.Property(e => e.Geburtsdatum).HasColumnType("smalldatetime");
        entity.Property(e => e.Geschlecht)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.Land)
            .HasMaxLength(3)
            .IsUnicode(false);
        entity.Property(e => e.Nachname)
            .HasMaxLength(40)
            .IsUnicode(false);
        entity.Property(e => e.Ort)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Plz)
            .HasMaxLength(5)
            .IsUnicode(false);
        entity.Property(e => e.Straße)
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
