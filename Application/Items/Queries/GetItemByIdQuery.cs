using Application.Items.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Items.Queries
{
    public class GetItemByIdQuery
    {
        public class Request : IRequest<GetItemDto>
        {
            public int ItemId { get; set; }
            public Request(int itemId) => ItemId = itemId;
        }

        public class Handler : IRequestHandler<Request, GetItemDto>
        {
            private readonly AppDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(AppDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<GetItemDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var item = await _dbContext.Set<Item>().SingleOrDefaultAsync(x => x.Id == request.ItemId);

                return _mapper.Map<GetItemDto>(item);
            }
        }
    }
}