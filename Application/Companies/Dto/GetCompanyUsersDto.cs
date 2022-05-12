using Application.Authentication.Dto;
using System.Collections.Generic;

namespace Application.Companies.Dto
{
    public class GetCompanyUsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ApplicationUserDto> Users { get; set; }
    }
}