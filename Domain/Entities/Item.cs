using System.Collections.Generic;

namespace Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfGuests { get; set; }


        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}