using Application.Settings.Dto;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Settings.Queries
{
    public class GetSettingsByCompanyIdQuery
    {
        public class Request : IRequest<GetSettingsDto>
        {
            public int CompanyId { get; set; }
            public Request(int companyId) => CompanyId = companyId;
        }

        public class Handler : IRequestHandler<Request, GetSettingsDto>
        {
            private readonly AppDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(AppDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<GetSettingsDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var settings = await _dbContext.Set<Domain.Entities.Settings>()
                    .Include(x => x.Company)
                    .SingleAsync(x => x.CompanyId == request.CompanyId);

                return _mapper.Map<GetSettingsDto>(settings);
            }
        }
    }
}