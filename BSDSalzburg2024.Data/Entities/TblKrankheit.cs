// <copyright file="TblKrankheit.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class TblKrankheit
{
    public int KrankhId { get; set; }

    public int? SpenderId { get; set; }

    public string KrankhTyp { get; set; }

    public string KrankhText { get; set; }

    public DateTime? ErfassungsDat { get; set; }

    public string Anmerkung { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblKrankheit> entity)
    {
        entity.HasKey(e => e.KrankhId).HasFillFactor(90);

        entity.ToTable("tblKrankheit");

        entity.Property(e => e.Anmerkung)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.ErfassungsDat).HasColumnType("smalldatetime");
        entity.Property(e => e.KrankhText)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.KrankhTyp)
            .HasMaxLength(8)
            .IsUnicode(false);
    }
}
