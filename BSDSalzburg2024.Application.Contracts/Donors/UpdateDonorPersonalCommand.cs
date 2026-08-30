namespace BSDSalzburg2024.Application.Requests.Donors;

using System;

using Mediator;

public sealed record class UpdateDonorPersonalCommand
    : ICommand
{
    public UpdateDonorPersonalCommand(int id, string? familyName, string? givenName, DateTime? dateOfBirth, string? sex)
    {
        this.Id = id;
        this.FamilyName = familyName;
        this.GivenName = givenName;
        this.DateOfBirth = dateOfBirth;
        this.Sex = sex;
    }

    public int Id { get; set; }

    public string? FamilyName { get; set; }

    public string? GivenName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Sex { get; set; }
}