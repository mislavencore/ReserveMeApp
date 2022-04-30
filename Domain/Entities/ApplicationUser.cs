using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}