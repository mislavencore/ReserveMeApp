using Application.Companies.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Companies.Commands
{
    public class CreateCompanyCommand
    {
        public class Request : IRequest<CreateCompanyDto>
        {
            public CreateCompanyDto Company { get; set; }
            public Request(CreateCompanyDto company) => Company = company;
        }

        public class Handler : IRequestHandler<Request, CreateCompanyDto>
        {
            private readonly AppDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(AppDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<CreateCompanyDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var company = _mapper.Map<Company>(request.Company);

                _dbContext.Add(company);
                await _dbContext.SaveChangesAsync();

                return request.Company;
            }
        }
    }
}