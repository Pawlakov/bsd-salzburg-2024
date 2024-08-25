// <copyright file="BsdDatabaseContext.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data;

using BSDSalzburg2024.Data.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// The context providing access to the DB of BSD.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BsdDatabaseContext"/> class.
/// </remarks>
/// <param name="options">The configuration of the DB.</param>
public partial class BsdDatabaseContext(DbContextOptions<BsdDatabaseContext> options)
        : DbContext(options)
{
    /// <summary>
    /// Gets or sets the table of municipalities in the DB.
    /// </summary>
    public virtual DbSet<Municipality> Municipalities { get; set; }

    /// <summary>
    /// Gets or sets the table of locations in the DB.
    /// </summary>
    public virtual DbSet<Location> Locations { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements should be documented
    public virtual DbSet<TblEhrung> TblEhrungs { get; set; }

    public virtual DbSet<TblKrankheit> TblKrankheits { get; set; }

    public virtual DbSet<TblLaborwert> TblLaborwerts { get; set; }

    public virtual DbSet<TblLaborwertName> TblLaborwertNames { get; set; }

    public virtual DbSet<TblLogPgm> TblLogPgms { get; set; }

    public virtual DbSet<TblLogPgmDetail> TblLogPgmDetails { get; set; }

    public virtual DbSet<TblMitarbeiter> TblMitarbeiters { get; set; }

    public virtual DbSet<TblMitarbeiterSpendeaktion> TblMitarbeiterSpendeaktions { get; set; }

    public virtual DbSet<TblParameter> TblParameters { get; set; }

    public virtual DbSet<TblPostleitzahl> TblPostleitzahls { get; set; }

    public virtual DbSet<TblSpende> TblSpendes { get; set; }

    public virtual DbSet<TblSpendeHinderni> TblSpendeHindernis { get; set; }

    public virtual DbSet<DonationEvent> TblSpendeaktions { get; set; }

    public virtual DbSet<TblSpendeaktionVerbrauch> TblSpendeaktionVerbrauches { get; set; }

    public virtual DbSet<TblSpender> TblSpenders { get; set; }
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <inheritdoc/>
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
        modelBuilder.Entity<Location>(Location.EntityBuildAction);
        modelBuilder.Entity<TblParameter>(TblParameter.EntityBuildAction);
        modelBuilder.Entity<TblPostleitzahl>(TblPostleitzahl.EntityBuildAction);
        modelBuilder.Entity<TblSpende>(TblSpende.EntityBuildAction);
        modelBuilder.Entity<TblSpendeHinderni>(TblSpendeHinderni.EntityBuildAction);
        modelBuilder.Entity<DonationEvent>(DonationEvent.EntityBuildAction);
        modelBuilder.Entity<TblSpendeaktionVerbrauch>(TblSpendeaktionVerbrauch.EntityBuildAction);
        modelBuilder.Entity<TblSpender>(TblSpender.EntityBuildAction);
    }
}