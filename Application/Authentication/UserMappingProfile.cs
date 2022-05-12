using Application.Authentication.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Authentication
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();
        }
    }
}