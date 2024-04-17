// <copyright file="TblLogPgmDetail.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
