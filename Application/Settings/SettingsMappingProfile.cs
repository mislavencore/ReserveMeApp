using Application.Settings.Dto;
using AutoMapper;

namespace Application.Settings
{
    public class SettingsMappingProfile : Profile
    {
        public SettingsMappingProfile()
        {
            CreateMap<Domain.Entities.Settings, GetSettingsDto>()
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.Name));

            CreateMap<UpdateSettingsDto, Domain.Entities.Settings>();
            CreateMap<CreateSettingsDto, Domain.Entities.Settings>();
        }
    }
}