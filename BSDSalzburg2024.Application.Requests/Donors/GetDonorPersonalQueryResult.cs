namespace BSDSalzburg2024.Application.Requests.Donors;

public record GetDonorPersonalQueryResult
{
    public GetDonorPersonalQueryResultItem? Item { get; init; }
}
