using Application.Companies.Dto;

namespace Application.Users.Dto
{
    public class ApplicationUserDetailsDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public GetCompanyDto Company { get; set; }
    }
}