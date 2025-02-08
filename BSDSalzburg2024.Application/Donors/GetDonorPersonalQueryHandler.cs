namespace BSDSalzburg2024.Application.Donors;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Requests.Donors;
using BSDSalzburg2024.Application.Requests.Models;
using BSDSalzburg2024.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetDonorPersonalQueryHandler
    : IRequestHandler<GetDonorPersonalQuery, GetDonorPersonalQueryResult>
{
    private readonly BsdDatabaseContext context;

    public GetDonorPersonalQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public async Task<GetDonorPersonalQueryResult> Handle(GetDonorPersonalQuery request, CancellationToken cancellationToken)
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

        return new GetDonorPersonalQueryResult
        {
            Item = entity == null ? null : new GetDonorPersonalQueryResultItem(entity.Id, entity.FamilyName, entity.GivenName, entity.DateOfBirth, Sex.GetFromChar(entity.Sex)),
        };
    }
}
