using Application.Companies.Dto;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Companies.Commands
{
    public class UpdateCompanyDetailsCommand
    {
        public class Request : IRequest<UpdateCompanyDto>
        {
            public UpdateCompanyDto Company { get; set; }
            public Request(UpdateCompanyDto company) => Company = company;
        }

        public class Handler : IRequestHandler<Request, UpdateCompanyDto>
        {
            private readonly AppDbContext _dbContext;

            public Handler(AppDbContext dbContext) => _dbContext = dbContext;

            public async Task<UpdateCompanyDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var company = _dbContext.Set<Company>().SingleAsync(x => x.Id == request.Company.Id).Result;

                company.Name = request.Company.NewName;
                company.Email = request.Company.NewEmail;

                _dbContext.Update(company);
                await _dbContext.SaveChangesAsync();

                return request.Company;
            }
        }
    }
}