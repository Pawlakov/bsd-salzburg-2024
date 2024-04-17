// <copyright file="TblEhrung.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class TblEhrung
{
    public int SpenderId { get; set; }

    public string EhrungsId { get; set; }

    public DateTime? DatumGeschenk { get; set; }

    public bool? BesuchFeier { get; set; }

    public DateTime? DatumFeier { get; set; }

    public bool? FeierBesucht { get; set; }

    public string Anmerkung { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblEhrung> entity)
    {
        entity.HasKey(e => new { e.SpenderId, e.EhrungsId }).HasFillFactor(90);

        entity.ToTable("tblEhrung");

        entity.Property(e => e.EhrungsId)
            .HasMaxLength(8)
            .IsUnicode(false);
        entity.Property(e => e.Anmerkung)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.DatumFeier).HasColumnType("smalldatetime");
        entity.Property(e => e.DatumGeschenk).HasColumnType("smalldatetime");
    }
}