namespace BSDSalzburg2024.Application.Requests.Donors;

using System;
using BSDSalzburg2024.Application.Requests.Models;

public record GetDonorPersonalQueryResultItem(int Id, string FamilyName, string GivenName, DateTime DateOfBirth, Sex Sex);