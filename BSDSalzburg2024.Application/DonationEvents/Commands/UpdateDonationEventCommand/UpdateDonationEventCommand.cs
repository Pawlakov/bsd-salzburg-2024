namespace BSDSalzburg2024.Application.DonationEvents.Commands.UpdateDonationEventCommand;

using MediatR;

public class UpdateDonationEventCommand
    : IRequest
{
    public UpdateDonationEventCommand(int id)
    {
        this.Id = id;
    }

    public int Id { get; }
}