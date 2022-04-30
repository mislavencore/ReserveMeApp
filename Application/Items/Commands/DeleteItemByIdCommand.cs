using Application.Items.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Items.Commands
{
    public class DeleteItemByIdCommand
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
                var item = _dbContext.Set<Item>().SingleAsync(x => x.Id == request.ItemId).Result;

                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<GetItemDto>(item);
            }
        }
    }
}