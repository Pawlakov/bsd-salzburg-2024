// <copyright file="TblLogPgm.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
