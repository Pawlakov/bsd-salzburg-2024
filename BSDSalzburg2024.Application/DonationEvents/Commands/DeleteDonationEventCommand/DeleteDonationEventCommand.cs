namespace BSDSalzburg2024.Application.DonationEvents.Commands.DeleteDonationEventCommand;

using MediatR;

public class DeleteDonationEventCommand
    : IRequest
{
    public DeleteDonationEventCommand(int id)
    {
        this.Id = id;
    }

    public int Id { get; }
}