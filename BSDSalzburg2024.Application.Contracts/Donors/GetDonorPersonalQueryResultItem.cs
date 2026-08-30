namespace BSDSalzburg2024.Application.Requests.Donors;

using System;

using BSDSalzburg2024.Application.Requests.Models;

public class GetDonorPersonalQueryResultItem
{
    required public int Id { get; set; }

    required public string? FamilyName { get; set; }

    required public string? GivenName { get; set; }

    required public DateTime? DateOfBirth { get; set; }

    required public Sex? Sex { get; set; }
}