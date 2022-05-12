using Application.Authentication.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Users
{
    public class UserMappingConfiguration : Profile
    {
        public UserMappingConfiguration()
        {
            CreateMap<ApplicationUserDto, ApplicationUser>();
        }
    }
}
