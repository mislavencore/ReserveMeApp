using Application.Companies.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Companies
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<Company, GetCompanyDto>();
            CreateMap<Company, UpdateCompanyDto>();
            CreateMap<Company, GetCompanyUsersDto>();
            CreateMap<Company, GetCompanyItemsDto>();
        }
    }
}