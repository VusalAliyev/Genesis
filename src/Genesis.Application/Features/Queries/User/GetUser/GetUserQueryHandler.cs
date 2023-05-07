using Genesis.Infrastructure;
using MediatR;

namespace Genesis.Application.Features.Queries.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        private readonly AppDbContext _context;

        public GetUserQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user= _context.Users.FirstOrDefault(p=>p.FinCode==request.FinCode);

            return new GetUserQueryResponse()
            {
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    Age=user.Age,
                    FinCode=user.FinCode,
                    Id=user.Id
            };
        }
    }
}
