// <copyright file="DonorConfiguration.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Configurations;

using BSDSalzburg2024.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class DonorConfiguration
    : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.HasKey(e => e.Id).HasFillFactor(90);

        builder.ToTable("tblSpender");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("SpenderId");
        builder.Property(e => e.FamilyName)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("Nachname");
        builder.Property(e => e.GivenName)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("Vorname");
        builder.Property(e => e.DateOfBirth)
            .HasColumnType("smalldatetime")
            .HasColumnName("Geburtsdatum");
        builder.Property(e => e.Sex)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("Geschlecht");

        builder.Property(e => e.AenderungDatum).HasColumnType("smalldatetime");
        builder.Property(e => e.AenderungMitarbeiterId)
            .HasMaxLength(12)
            .IsUnicode(false);
        builder.Property(e => e.AenderungOrt)
            .HasMaxLength(20)
            .IsUnicode(false);
        builder.Property(e => e.AenderungTyp)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.AusweisLetzter).HasColumnType("smalldatetime");
        builder.Property(e => e.Blutgruppe)
            .HasMaxLength(2)
            .IsUnicode(false);
        builder.Property(e => e.EinladungNurSms).HasColumnName("EinladungNurSMS");
        builder.Property(e => e.EinladungSms).HasColumnName("EinladungSMS");
        builder.Property(e => e.Email)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("email");
        builder.Property(e => e.ExpZentraleDatum).HasColumnType("smalldatetime");
        builder.Property(e => e.Kommentar)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.KompanieFirma)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Land)
            .HasMaxLength(3)
            .IsUnicode(false);
        builder.Property(e => e.Ort)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Phaenotyp)
            .HasMaxLength(6)
            .IsUnicode(false);
        builder.Property(e => e.Plz)
            .HasMaxLength(8)
            .IsUnicode(false);
        builder.Property(e => e.ProgesaId).HasColumnName("ProgesaID");
        builder.Property(e => e.SpendenLetzte).HasColumnType("smalldatetime");
        builder.Property(e => e.Status)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.Strasse)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.TelBeruf)
            .HasMaxLength(25)
            .IsUnicode(false);
        builder.Property(e => e.TelHandy)
            .HasMaxLength(25)
            .IsUnicode(false);
        builder.Property(e => e.TelPrivat)
            .HasMaxLength(25)
            .IsUnicode(false);
        builder.Property(e => e.Titel)
            .HasMaxLength(30)
            .IsUnicode(false);
    }
}