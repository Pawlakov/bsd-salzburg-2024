namespace BSDSalzburg2024.Application.Donors;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Requests.Donors;
using BSDSalzburg2024.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class UpdateDonorPersonalCommandHandler
    : IRequestHandler<UpdateDonorPersonalCommand>
{
    private readonly BsdDatabaseContext context;

    public UpdateDonorPersonalCommandHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateDonorPersonalCommand request, CancellationToken cancellationToken)
    {
        await this.context.Donors
            .Where(x => x.Id == request.Id)
            .ExecuteUpdateAsync(x => x.SetProperty(y => y.FamilyName, request.FamilyName).SetProperty(y => y.GivenName, request.GivenName), cancellationToken);
    }
}
