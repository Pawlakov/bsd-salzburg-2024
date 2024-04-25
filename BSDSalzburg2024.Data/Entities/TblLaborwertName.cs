// <copyright file="TblLaborwertName.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
public partial class TblLaborwertName
{
    public string LaborwertNameId { get; set; }

    public string Name { get; set; }

    public string Normalwertvon { get; set; }

    public string Normalwertbis { get; set; }

    public string Kommentar { get; set; }

    public string LaborWertTyp { get; set; }

    public string WerteListe { get; set; }

    public bool NurWerteAusListe { get; set; }

    public string SphinBedingung { get; set; }

    public string SphinKurztext { get; set; }

    public string SphinLangtext { get; set; }

    public string SphinDauer { get; set; }

    public bool Aktiv { get; set; }

    public int? Reihung { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblLaborwertName> entity)
    {
        entity.HasKey(e => e.LaborwertNameId).HasFillFactor(90);

        entity.ToTable("tblLaborwertName");

        entity.Property(e => e.LaborwertNameId)
            .HasMaxLength(16)
            .IsUnicode(false)
            .HasColumnName("LaborwertNameID");
        entity.Property(e => e.Kommentar)
            .HasMaxLength(30)
            .IsUnicode(false);
        entity.Property(e => e.LaborWertTyp)
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.Normalwertbis)
            .HasMaxLength(20)
            .IsUnicode(false);
        entity.Property(e => e.Normalwertvon)
            .HasMaxLength(20)
            .IsUnicode(false);
        entity.Property(e => e.SphinBedingung)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.SphinDauer)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.SphinKurztext)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.SphinLangtext)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.WerteListe)
            .HasMaxLength(150)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
