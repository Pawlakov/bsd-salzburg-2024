// <copyright file="TblKrankheit.cs" company="Paweł Matusek">
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
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member