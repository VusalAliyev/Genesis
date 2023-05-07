using Genesis.Application.Dtos;
using MediatR;

namespace Genesis.Application.Features.Queries.User.GetUser
{
    public class GetUserQueryRequest : IRequest<TResponse<GetUserQueryResponse>>
    {
        public string FinCode { get; set; } = null!;
    }
}
