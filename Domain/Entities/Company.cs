using System.Collections.Generic;

namespace Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
        public Settings Settings { get; set; }

    }
}