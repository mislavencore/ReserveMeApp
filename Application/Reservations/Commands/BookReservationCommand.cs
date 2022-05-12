using Application.Reservations.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands
{
    public class BookReservationCommand
    {
        public class Request : IRequest<BookReservationDto>
        {
            public BookReservationDto Reservation { get; set; }
            public Request(BookReservationDto reservation) => Reservation = reservation;
        }

        public class Handler : IRequestHandler<Request, BookReservationDto>
        {
            private readonly AppDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(AppDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<BookReservationDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var data = _mapper.Map<Reservation>(request.Reservation);

                // ispitaj koji sve stolovi su slobodni u to vrime
                // a da mogu primit jednak ili veci broj od uzvanika
                
                // ovoj rezervaciji dodaj stol sa optimalnim brojem
                data.ItemId = 4;
                _dbContext.Add(data);
                await _dbContext.SaveChangesAsync();

                return request.Reservation;
            }
        }
    }
}