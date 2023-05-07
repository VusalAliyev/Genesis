using AutoMapper;
using Genesis.Application.Dtos;
using Genesis.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return TResponse<GetUserQueryResponse>.Success(_mapper.Map<GetUserQueryResponse>(user), 200);
            }
            else
            {
                return TResponse<GetUserQueryResponse>.Fail("Fin kod tapılmadı", 404);
            }
        }
    }
}
