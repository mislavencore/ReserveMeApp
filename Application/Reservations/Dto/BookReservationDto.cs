using System;

namespace Application.Reservations.Dto
{
    public class BookReservationDto
    {
        public DateTime Date { get; set; }
        public string ReservationHolderName { get; set; }
        public string ReservationHolderPhoneNumber { get; set; }
        public int NumberOfChildren { get; set; }
        public string SpecialRequest { get; set; }
        public int NumberOfGuests { get; set; }
        public string UserId { get; set; }
    }
}
