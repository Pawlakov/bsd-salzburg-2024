namespace BSDSalzburg2024.Application.Requests.Donors;

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
}
