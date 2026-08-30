namespace BSDSalzburg2024.Application.Donors;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Donors;
using BSDSalzburg2024.Application.Requests.Models;
using BSDSalzburg2024.Domain.Entities;

using Mediator;

public class GetDonorPersonalQueryHandler
    : IQueryHandler<GetDonorPersonalQuery, GetDonorPersonalQueryResult>
{
    private readonly IBaseRepository<Donor, int> context;

    public GetDonorPersonalQueryHandler(IBaseRepository<Donor, int> context)
    {
        this.context = context;
    }

    public ValueTask<GetDonorPersonalQueryResult> Handle(GetDonorPersonalQuery request, CancellationToken cancellationToken)
    {
        var entity = this.context.AsQueryable()
            .Where(x => x.Id == request.Id)
            .Select(x => new
            {
                x.Id,
                x.FamilyName,
                x.GivenName,
                x.DateOfBirth,
                x.Sex,
            })
            .FirstOrDefault();

        var result = new GetDonorPersonalQueryResult
        {
            Item = entity switch
            {
                null => null,
                not null => new GetDonorPersonalQueryResultItem()
                {
                    Id = entity.Id,
                    FamilyName = entity.FamilyName,
                    GivenName = entity.GivenName,
                    DateOfBirth = entity.DateOfBirth,
                    Sex = Sex.GetFromChar(entity.Sex),
                },
            },
        };

        return ValueTask.FromResult(result);
    }
}