using Application.Reservations.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Reservations
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<BookReservationDto, Reservation>();
        }
    }
}