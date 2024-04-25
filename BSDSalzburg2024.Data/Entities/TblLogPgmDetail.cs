// <copyright file="TblLogPgmDetail.cs" company="Paweł Matusek">
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
public partial class TblLogPgmDetail
{
    public int LogPgmDetailId { get; set; }

    public DateTime? LogPgmDetailDatZeit { get; set; }

    public int? LogPgmId { get; set; }

    public string LogPgmDetailTyp { get; set; }

    public string LogPgmDetailText { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblLogPgmDetail> entity)
    {
        entity.HasKey(e => e.LogPgmDetailId).HasFillFactor(90);

        entity.ToTable("tblLogPgmDetail");

        entity.Property(e => e.LogPgmDetailDatZeit).HasColumnType("smalldatetime");
        entity.Property(e => e.LogPgmDetailText).HasColumnType("text");
        entity.Property(e => e.LogPgmDetailTyp)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
