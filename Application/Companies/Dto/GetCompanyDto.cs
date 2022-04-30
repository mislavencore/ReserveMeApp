using Application.Settings.Dto;

namespace Application.Companies.Dto
{
    public class GetCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GetSettingsDto Settings { get; set; }
    }
}