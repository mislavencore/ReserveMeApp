using Application.Items.Dto;
using System.Collections.Generic;

namespace Application.Companies.Dto
{
    public class GetCompanyItemsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetItemDto> Items { get; set; }
    }
}