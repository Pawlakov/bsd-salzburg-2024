namespace BSDSalzburg2024.Application.DonationEvents.Queries.GetDonationEventListQuery;

using BSDSalzburg2024.Application.Base.Queries.ListQuery;
using BSDSalzburg2024.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

public class GetDonationEventListQueryHandler
    : ListQueryHandler<GetDonationEventListQueryResultItem, int>
{
    public GetDonationEventListQueryHandler(BsdDatabaseContext context)
        : base(context)
    {
    }

    public override async Task<ListQueryResult<GetDonationEventListQueryResultItem, int>> Handle(ListQuery<GetDonationEventListQueryResultItem, int> request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}