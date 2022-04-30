using Application.Items.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Items
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Item, GetItemDto>();
        }
    }
}