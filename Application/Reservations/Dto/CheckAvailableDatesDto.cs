using System;

namespace Application.Reservations.Dto
{
    public class CheckAvailableDatesDto
    {
        public DateTime Date { get; set; }
        public int NumberOfGuests { get; set; }
    }
}