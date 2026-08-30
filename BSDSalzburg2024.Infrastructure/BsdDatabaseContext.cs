// <copyright file="BsdDatabaseContext.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Infrastructure;

using BSDSalzburg2024.Domain.Entities;
using BSDSalzburg2024.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// The context providing access to the DB of BSD.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BsdDatabaseContext"/> class.
/// </remarks>
/// <param name="options">The configuration of the DB.</param>
public class BsdDatabaseContext(DbContextOptions<BsdDatabaseContext> options)
        : DbContext(options)
{
    /// <summary>
    /// Gets or sets the table of municipalities in the DB.
    /// </summary>
    internal DbSet<Municipality> Municipalities { get; set; }

    /// <summary>
    /// Gets or sets the table of locations in the DB.
    /// </summary>
    internal DbSet<Location> Locations { get; set; }

    /// <summary>
    /// Gets or sets the table of donation events in the DB.
    /// </summary>
    internal DbSet<DonationEvent> DonationEvents { get; set; }

    /// <summary>
    /// Gets or sets the table of donors in the DB.
    /// </summary>
    internal DbSet<Donor> Donors { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements should be documented
    internal DbSet<TblEhrung> TblEhrungs { get; set; }

    internal DbSet<TblKrankheit> TblKrankheits { get; set; }

    internal DbSet<TblLaborwert> TblLaborwerts { get; set; }

    internal DbSet<TblLaborwertName> TblLaborwertNames { get; set; }

    internal DbSet<TblLogPgm> TblLogPgms { get; set; }

    internal DbSet<TblLogPgmDetail> TblLogPgmDetails { get; set; }

    internal DbSet<TblMitarbeiter> TblMitarbeiters { get; set; }

    internal DbSet<TblMitarbeiterSpendeaktion> TblMitarbeiterSpendeaktions { get; set; }

    internal DbSet<TblParameter> TblParameters { get; set; }

    internal DbSet<TblPostleitzahl> TblPostleitzahls { get; set; }

    internal DbSet<TblSpende> TblSpendes { get; set; }

    internal DbSet<TblSpendeHinderni> TblSpendeHindernis { get; set; }

    internal DbSet<TblSpendeaktionVerbrauch> TblSpendeaktionVerbrauches { get; set; }
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DonationEventConfiguration).Assembly);
    }
}