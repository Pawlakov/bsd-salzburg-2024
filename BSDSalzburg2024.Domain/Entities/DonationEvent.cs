// <copyright file="DonationEvent.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Domain.Entities;

using System;

/// <summary>
/// DB entity representing a blood donation event.
/// </summary>
public class DonationEvent
{
    /// <summary>
    /// Gets or sets the ID of the donation event.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the location where the event takes place. A foreign key.
    /// </summary>
    public string? LocationId { get; set; }

    public string? OrtDetail { get; set; }

    public DateTime? Datum { get; set; }

    public DateTime? ZeitVon { get; set; }

    public DateTime? ZeitBis { get; set; }

    public DateTime? ZeitAbfahrt { get; set; }

    public DateTime? ZeitRueckkehr { get; set; }

    public DateTime? ZeitBeginn { get; set; }

    public DateTime? ZeitEnde { get; set; }

    public string Typ { get; set; }

    public int? AnzKons { get; set; }

    public int? AnzBlGr { get; set; }

    public int? AnzWeg { get; set; }

    public string Kommentar { get; set; }

    /// <summary>
    /// Gets or sets the navigation property linking to the location where the event takes place.
    /// </summary>
    public Location? Location { get; set; }
}