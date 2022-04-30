using Application.Settings.Dto;

namespace Application.Companies.Dto
{
    public class CreateCompanyDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public CreateSettingsDto Settings { get; set; }
    }
}