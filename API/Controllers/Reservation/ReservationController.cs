using API.Controllers.Base;
using Application.Reservations.Commands;
using Application.Reservations.Dto;
using Application.Reservations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Item
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : BaseController
    {
        public ReservationController(IMediator mediator) : base(mediator) { }

        [HttpPost(nameof(Book))]
        public async Task<IActionResult> Book(BookReservationDto reservation)
            => Ok(await Mediator.Send(new BookReservationCommand.Request(reservation)));


        [HttpPost(nameof(CheckDates))]
        public async Task<IActionResult> CheckDates(CheckAvailableDatesDto date)
            => Ok(await Mediator.Send(new CheckAvailableDatesQuery.Request(date)));
    }
}
