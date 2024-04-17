using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace BSDSalzburg2024.Data.Entities;

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
