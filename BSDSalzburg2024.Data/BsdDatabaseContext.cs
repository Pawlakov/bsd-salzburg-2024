// <copyright file="BsdDatenContext.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data;

using BSDSalzburg2024.Data.Entities;
using Microsoft.EntityFrameworkCore;

public partial class BsdDatabaseContext 
    : DbContext
{
    public BsdDatabaseContext(DbContextOptions<BsdDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEhrung> TblEhrungs { get; set; }

    public virtual DbSet<Municipality> TblGemeindes { get; set; }

    public virtual DbSet<TblKrankheit> TblKrankheits { get; set; }

    public virtual DbSet<TblLaborwert> TblLaborwerts { get; set; }

    public virtual DbSet<TblLaborwertName> TblLaborwertNames { get; set; }

    public virtual DbSet<TblLogPgm> TblLogPgms { get; set; }

    public virtual DbSet<TblLogPgmDetail> TblLogPgmDetails { get; set; }

    public virtual DbSet<TblMitarbeiter> TblMitarbeiters { get; set; }

    public virtual DbSet<TblMitarbeiterSpendeaktion> TblMitarbeiterSpendeaktions { get; set; }

    public virtual DbSet<TblOrt> TblOrts { get; set; }

    public virtual DbSet<TblParameter> TblParameters { get; set; }

    public virtual DbSet<TblPostleitzahl> TblPostleitzahls { get; set; }

    public virtual DbSet<TblSpende> TblSpendes { get; set; }

    public virtual DbSet<TblSpendeHinderni> TblSpendeHindernis { get; set; }

    public virtual DbSet<TblSpendeaktion> TblSpendeaktions { get; set; }

    public virtual DbSet<TblSpendeaktionVerbrauch> TblSpendeaktionVerbrauches { get; set; }

    public virtual DbSet<TblSpender> TblSpenders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEhrung>(TblEhrung.EntityBuildAction);
        modelBuilder.Entity<Municipality>(Municipality.EntityBuildAction);
        modelBuilder.Entity<TblKrankheit>(TblKrankheit.EntityBuildAction);
        modelBuilder.Entity<TblLaborwert>(TblLaborwert.EntityBuildAction);
        modelBuilder.Entity<TblLaborwertName>(TblLaborwertName.EntityBuildAction);
        modelBuilder.Entity<TblLogPgm>(TblLogPgm.EntityBuildAction);
        modelBuilder.Entity<TblLogPgmDetail>(TblLogPgmDetail.EntityBuildAction);
        modelBuilder.Entity<TblMitarbeiter>(TblMitarbeiter.EntityBuildAction);
        modelBuilder.Entity<TblMitarbeiterSpendeaktion>(TblMitarbeiterSpendeaktion.EntityBuildAction);
        modelBuilder.Entity<TblOrt>(TblOrt.EntityBuildAction);
        modelBuilder.Entity<TblParameter>(TblParameter.EntityBuildAction);
        modelBuilder.Entity<TblPostleitzahl>(TblPostleitzahl.EntityBuildAction);
        modelBuilder.Entity<TblSpende>(TblSpende.EntityBuildAction);
        modelBuilder.Entity<TblSpendeHinderni>(TblSpendeHinderni.EntityBuildAction);
        modelBuilder.Entity<TblSpendeaktion>(TblSpendeaktion.EntityBuildAction);
        modelBuilder.Entity<TblSpendeaktionVerbrauch>(TblSpendeaktionVerbrauch.EntityBuildAction);
        modelBuilder.Entity<TblSpender>(TblSpender.EntityBuildAction);
    }
}
