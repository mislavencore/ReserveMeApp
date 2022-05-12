using Application.Items.Dto;
using Application.Reservations.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Queries
{
    public class CheckAvailableDatesQuery
    {
        public class Request : IRequest<List<Reservation>>
        {
            public CheckAvailableDatesDto Dates { get; set; }
            public Request(CheckAvailableDatesDto dates) => Dates = dates;
        }

        public class Handler : IRequestHandler<Request, List<Reservation>>
        {
            private readonly AppDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(AppDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<Reservation>> Handle(Request request, CancellationToken cancellationToken)
            {
                var datum = request.Dates.Date;
                var brojLjudi = request.Dates.NumberOfGuests;





                // zatrazit slobodne stolove za taj broj



                var reservationsOnSpecificDate = await _dbContext
                    .Set<Reservation>()
                    .Where(x => x.Date.Date == request.Dates.Date.Date)
                    .ToListAsync();

                /**
                 *uz pomoc settings varijabli treba generirati listu svihj 
                 *mogucih termina u tom danu
                 */


                /*
                 * iz te liste ukloniit one koji su zauseti
                 */


                /*
                 * vrati listu termina stolova
                 */


                return reservationsOnSpecificDate;

            }
        }
    }
}