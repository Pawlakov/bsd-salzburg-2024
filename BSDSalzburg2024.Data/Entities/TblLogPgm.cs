// <copyright file="TblLogPgm.cs" company="Paweł Matusek">
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
public partial class TblLogPgm
{
    public int LogPgmId { get; set; }

    public DateTime? LogPgmDatZeit { get; set; }

    public string MitarbeiterId { get; set; }

    public string LogPgmText { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblLogPgm> entity)
    {
        entity.HasKey(e => e.LogPgmId).HasFillFactor(90);

        entity.ToTable("tblLogPgm");

        entity.Property(e => e.LogPgmId).ValueGeneratedNever();
        entity.Property(e => e.LogPgmDatZeit).HasColumnType("smalldatetime");
        entity.Property(e => e.LogPgmText)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.MitarbeiterId)
            .HasMaxLength(12)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
