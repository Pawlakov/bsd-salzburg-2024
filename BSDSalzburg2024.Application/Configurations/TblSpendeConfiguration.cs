// <copyright file="TblSpendeConfiguration.cs" company="Paweł Matusek">
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
internal sealed class TblSpendeConfiguration
    : IEntityTypeConfiguration<TblSpende>
{
    public void Configure(EntityTypeBuilder<TblSpende> builder)
    {
        builder.HasKey(e => e.SpendeId).HasFillFactor(90);

        builder.ToTable("tblSpende");

        builder.Property(e => e.SpendeId)
            .ValueGeneratedNever()
            .HasColumnName("SpendeID");
        builder.Property(e => e.AbgewGrundId)
            .HasMaxLength(3)
            .IsUnicode(false);
        builder.Property(e => e.AbgewSpHinBis).HasColumnType("smalldatetime");
        builder.Property(e => e.AbgewText)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.AbnehmerId)
            .HasMaxLength(12)
            .IsUnicode(false)
            .HasColumnName("AbnehmerID");
        builder.Property(e => e.AenderungDatum).HasColumnType("smalldatetime");
        builder.Property(e => e.AenderungMitarbeiterId).HasMaxLength(12);
        builder.Property(e => e.AenderungOrt)
            .HasMaxLength(20)
            .IsUnicode(false);
        builder.Property(e => e.AenderungTyp)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.AnamneseId)
            .HasMaxLength(12)
            .IsUnicode(false)
            .HasColumnName("AnamneseID");
        builder.Property(e => e.AnamneseZeit).HasColumnType("smalldatetime");
        builder.Property(e => e.AscheinKommentar)
            .HasMaxLength(50)
            .HasColumnName("AScheinKommentar");
        builder.Property(e => e.AscheinUngueltig).HasColumnName("AScheinUngueltig");
        builder.Property(e => e.AscheinZeit)
            .HasColumnType("smalldatetime")
            .HasColumnName("AScheinZeit");
        builder.Property(e => e.Beginnzeit).HasColumnType("smalldatetime");
        builder.Property(e => e.BeutelAnz)
            .HasMaxLength(2)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.BeutelProdCode)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Datum).HasColumnType("smalldatetime");
        builder.Property(e => e.Endzeit).HasColumnType("smalldatetime");
        builder.Property(e => e.ExpBlutbankDatum).HasColumnType("smalldatetime");
        builder.Property(e => e.ExpZentraleDatum).HasColumnType("smalldatetime");
        builder.Property(e => e.Hb).HasColumnName("HB");
        builder.Property(e => e.KonserveId)
            .HasComment("KonserveID 7-stellig")
            .HasColumnName("KonserveID");
        builder.Property(e => e.KonserveId2)
            .HasMaxLength(16)
            .IsUnicode(false)
            .IsFixedLength()
            .HasComment("KonserveID 16-stellig")
            .HasColumnName("KonserveID2");
        builder.Property(e => e.Selbstausschluss)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.SpendeArt)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.SpendeaktionId).HasColumnName("SpendeaktionID");
        builder.Property(e => e.SpenderId).HasColumnName("SpenderID");
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
