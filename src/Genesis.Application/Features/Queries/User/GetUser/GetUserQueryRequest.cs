using MediatR;

namespace Genesis.Application.Features.Queries.User.GetUser
{
    public class GetUserQueryRequest : IRequest<GetUserQueryResponse>
    {
        public string FinCode { get; set; } = null!;
    }
}
