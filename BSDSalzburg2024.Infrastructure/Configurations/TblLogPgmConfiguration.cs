// <copyright file="TblLogPgmConfiguration.cs" company="Paweł Matusek">
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
internal sealed class TblLogPgmConfiguration
    : IEntityTypeConfiguration<TblLogPgm>
{
    public void Configure(EntityTypeBuilder<TblLogPgm> builder)
    {
        builder.HasKey(e => e.LogPgmId).HasFillFactor(90);

        builder.ToTable("tblLogPgm");

        builder.Property(e => e.LogPgmId).ValueGeneratedNever();
        builder.Property(e => e.LogPgmDatZeit).HasColumnType("smalldatetime");
        builder.Property(e => e.LogPgmText)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.MitarbeiterId)
            .HasMaxLength(12)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
