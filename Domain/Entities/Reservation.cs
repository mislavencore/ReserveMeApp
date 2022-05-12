using System;

namespace Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string ReservationHolderName { get; set; }
        public string ReservationHolderPhoneNumber { get; set; }
        public int NumberOfChildren { get; set; }
        public string SpecialRequest { get; set; }


        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
