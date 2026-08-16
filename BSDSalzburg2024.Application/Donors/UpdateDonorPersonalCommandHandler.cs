namespace BSDSalzburg2024.Application.Donors;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Requests.Donors;
using BSDSalzburg2024.Domain;

using Mediator;

using Microsoft.EntityFrameworkCore;

public class UpdateDonorPersonalCommandHandler
    : ICommandHandler<UpdateDonorPersonalCommand>
{
    private readonly BsdDatabaseContext context;

    public UpdateDonorPersonalCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async ValueTask<Unit> Handle(UpdateDonorPersonalCommand request, CancellationToken cancellationToken)
    {
        var dateOfBirth = request.DateOfBirth?.Date;

        await this.context.Donors
            .Where(x => x.Id == request.Id)
            .ExecuteUpdateAsync(
            x => x
                .SetProperty(y => y.FamilyName, request.FamilyName)
                .SetProperty(y => y.GivenName, request.GivenName)
                .SetProperty(y => y.DateOfBirth, dateOfBirth)
                .SetProperty(y => y.Sex, request.Sex),
            cancellationToken);

        return Unit.Value;
    }
}