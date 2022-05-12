namespace Application.Authentication.Dto
{
    public class TokenModelDto
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
