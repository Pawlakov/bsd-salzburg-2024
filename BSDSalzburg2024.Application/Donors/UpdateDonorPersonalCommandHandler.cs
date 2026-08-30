namespace BSDSalzburg2024.Application.Donors;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Donors;
using BSDSalzburg2024.Domain.Entities;

using Mediator;

public class UpdateDonorPersonalCommandHandler
    : ICommandHandler<UpdateDonorPersonalCommand>
{
    private readonly IBaseRepository<Donor, int> context;

    public UpdateDonorPersonalCommandHandler(IBaseRepository<Donor, int> context)
    {
        this.context = context;
    }

    public async ValueTask<Unit> Handle(UpdateDonorPersonalCommand request, CancellationToken cancellationToken = default)
    {
        var dateOfBirth = request.DateOfBirth?.Date;
        var entity = await this.context.FindAsync(request.Id, cancellationToken);
        if (entity != null)
        {
            entity.FamilyName = request.FamilyName;
            entity.GivenName = request.GivenName;
            entity.DateOfBirth = dateOfBirth;
            entity.Sex = request.Sex;

            this.context.Update(entity);
            await this.context.SaveChangesAsync(cancellationToken);
        }

        return Unit.Value;
    }
}