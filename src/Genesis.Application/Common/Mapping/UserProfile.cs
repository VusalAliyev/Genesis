using AutoMapper;
using Genesis.Application.Features.Queries.User.GetUser;
using Genesis.Domain.Entities;

namespace Genesis.Application.Common.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserQueryResponse>().ReverseMap();
        }
    }
}
