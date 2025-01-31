namespace BSDSalzburg2024.Application.Requests.Donors;

using MediatR;

public record GetDonorPersonalQuery
: IRequest<GetDonorPersonalQueryResult>
{
    public GetDonorPersonalQuery(int id)
    {
        this.Id = id;
    }

    public int Id { get; set; }
}
