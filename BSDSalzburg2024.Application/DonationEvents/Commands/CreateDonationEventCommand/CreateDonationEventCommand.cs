namespace BSDSalzburg2024.Application.DonationEvents.Commands.CreateDonationEventCommand;

using MediatR;

public class CreateDonationEventCommand
    : IRequest<int>
{
    public CreateDonationEventCommand()
    {
        this.Id = 0;
    }

    public int Id { get; set; }
}