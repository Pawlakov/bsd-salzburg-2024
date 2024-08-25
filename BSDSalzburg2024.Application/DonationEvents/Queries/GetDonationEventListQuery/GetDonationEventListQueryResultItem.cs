namespace BSDSalzburg2024.Application.DonationEvents.Queries.GetDonationEventListQuery;

using BSDSalzburg2024.Application.Base.Queries.ListQuery;

public record class GetDonationEventListQueryResultItem(int Index, int Id, bool CanBeDeleted) : IListQueryResultItem<int>;