namespace BSDSalzburg2024.Application.Donors;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Requests.Donors;
using BSDSalzburg2024.Application.Requests.Models;
using BSDSalzburg2024.Domain;

using Mediator;

using Microsoft.EntityFrameworkCore;

public class GetDonorPersonalQueryHandler
    : IQueryHandler<GetDonorPersonalQuery, GetDonorPersonalQueryResult>
{
    private readonly BsdDatabaseContext context;

    public GetDonorPersonalQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async ValueTask<GetDonorPersonalQueryResult> Handle(GetDonorPersonalQuery request, CancellationToken cancellationToken)
    {
        var entity = await this.context.Donors
            .Where(x => x.Id == request.Id)
            .Select(x => new
            {
                x.Id,
                x.FamilyName,
                x.GivenName,
                x.DateOfBirth,
                x.Sex,
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            return new GetDonorPersonalQueryResult
            {
                Item = null,
            };
        }

        return new GetDonorPersonalQueryResult
        {
            Item = new GetDonorPersonalQueryResultItem()
            {
                Id = entity.Id,
                FamilyName = entity.FamilyName,
                GivenName = entity.GivenName,
                DateOfBirth = entity.DateOfBirth,
                Sex = Sex.GetFromChar(entity.Sex),
            },
        };
    }
}