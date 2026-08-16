// <copyright file="TblMitarbeiterConfiguration.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Configurations;

using System;

using BSDSalzburg2024.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
internal sealed class TblMitarbeiterConfiguration
    : IEntityTypeConfiguration<TblMitarbeiter>
{
    public void Configure(EntityTypeBuilder<TblMitarbeiter> builder)
    {
        builder.HasKey(e => e.MitarbeiterId).HasFillFactor(90);

        builder.ToTable("tblMitarbeiter");

        builder.Property(e => e.MitarbeiterId)
            .HasMaxLength(12)
            .IsUnicode(false);
        builder.Property(e => e.Bagwinid)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("BAGWINId");
        builder.Property(e => e.Email)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("email");
        builder.Property(e => e.Funktion)
            .HasMaxLength(30)
            .IsUnicode(false);
        builder.Property(e => e.Geburtsdatum).HasColumnType("smalldatetime");
        builder.Property(e => e.Geschlecht)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.Land)
            .HasMaxLength(3)
            .IsUnicode(false);
        builder.Property(e => e.Nachname)
            .HasMaxLength(40)
            .IsUnicode(false);
        builder.Property(e => e.Ort)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Plz)
            .HasMaxLength(5)
            .IsUnicode(false);
        builder.Property(e => e.Straße)
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
        builder.Property(e => e.Vorname)
            .HasMaxLength(40)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
