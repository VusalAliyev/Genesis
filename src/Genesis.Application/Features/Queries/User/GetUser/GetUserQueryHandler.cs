using AutoMapper;
using Genesis.Application.Dtos;
using Genesis.Infrastructure;
using MediatR;

namespace Genesis.Application.Features.Queries.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, TResponse<GetUserQueryResponse>>
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public GetUserQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TResponse<GetUserQueryResponse>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(p => p.FinCode == request.FinCode);
            if (user != null)
            {
                return TResponse<GetUserQueryResponse>.Success(new GetUserQueryResponse
                {
                    Id = user.Id,
                    Age = user.Age,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FinCode = user.FinCode,
                }, 200);
            }
            else
            {
                return TResponse<GetUserQueryResponse>.Fail("Fin kod tapılmadı", 404);
            }
        }
    }
}
