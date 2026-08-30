// <copyright file="TblLaborwertNameConfiguration.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Infrastructure.Configurations;

using BSDSalzburg2024.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
internal sealed class TblLaborwertNameConfiguration
    : IEntityTypeConfiguration<TblLaborwertName>
{
    public void Configure(EntityTypeBuilder<TblLaborwertName> builder)
    {
        builder.HasKey(e => e.LaborwertNameId).HasFillFactor(90);

        builder.ToTable("tblLaborwertName");

        builder.Property(e => e.LaborwertNameId)
            .HasMaxLength(16)
            .IsUnicode(false)
            .HasColumnName("LaborwertNameID");
        builder.Property(e => e.Kommentar)
            .HasMaxLength(30)
            .IsUnicode(false);
        builder.Property(e => e.LaborWertTyp)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Normalwertbis)
            .HasMaxLength(20)
            .IsUnicode(false);
        builder.Property(e => e.Normalwertvon)
            .HasMaxLength(20)
            .IsUnicode(false);
        builder.Property(e => e.SphinBedingung)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.SphinDauer)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.SphinKurztext)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.SphinLangtext)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.WerteListe)
            .HasMaxLength(150)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
