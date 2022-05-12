using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}