namespace BSDSalzburg2024.Application.Requests.Donors;

using Mediator;

public sealed record class GetDonorPersonalQuery(int Id) : IQuery<GetDonorPersonalQueryResult>;