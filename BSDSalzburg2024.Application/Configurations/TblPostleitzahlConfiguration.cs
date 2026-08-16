// <copyright file="TblPostleitzahlConfiguration.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Configurations;

using BSDSalzburg2024.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
internal sealed class TblPostleitzahlConfiguration
    : IEntityTypeConfiguration<TblPostleitzahl>
{
    public void Configure(EntityTypeBuilder<TblPostleitzahl> builder)
    {
        builder.HasKey(e => e.Plz).HasFillFactor(90);

        builder.ToTable("tblPostleitzahl");

        builder.Property(e => e.Plz)
            .HasMaxLength(8)
            .IsUnicode(false);
        builder.Property(e => e.Land)
            .HasMaxLength(3)
            .IsUnicode(false);
        builder.Property(e => e.Ort)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
