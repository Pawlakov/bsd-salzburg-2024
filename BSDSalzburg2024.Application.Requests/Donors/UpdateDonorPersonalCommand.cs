namespace BSDSalzburg2024.Application.Requests.Donors;

using System;
using MediatR;

public record UpdateDonorPersonalCommand
    : IRequest
{
    public UpdateDonorPersonalCommand(int id)
    {
        this.Id = id;
    }

    public int Id { get; }

    public string? FamilyName { get; set; }

    public string? GivenName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Sex { get; set; }
}
