using Application.Companies.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Companies.Queries
{
    public class GetAllItemsByCompanyIdQuery
    {
        public class Request : IRequest<GetCompanyItemsDto>
        {
            public int CompanyId { get; set; }
            public Request(int companyId) => CompanyId = companyId;
        }

        public class Handler : IRequestHandler<Request, GetCompanyItemsDto>
        {
            private readonly AppDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(AppDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<GetCompanyItemsDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var company = await _dbContext.Set<Company>()
                    .Include(x => x.Items)
                    .SingleAsync(x => x.Id == request.CompanyId);

                return _mapper.Map<GetCompanyItemsDto>(company);
            }
        }
    }
}