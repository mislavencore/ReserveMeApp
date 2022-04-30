using Application.Users.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Users
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<ApplicationUser, ApplicationUserDetailsDto>()
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.UserEmail, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.Company, o => o.MapFrom(s => s.Company));
        }
    }
}