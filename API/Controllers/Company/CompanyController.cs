using API.Controllers.Base;
using Application.Companies.Commands;
using Application.Companies.Dto;
using Application.Companies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Company
{
    public class CompanyController : BaseController
    {
        public CompanyController(IMediator mediator) : base(mediator) { }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create(CreateCompanyDto company) 
            => Ok(await Mediator.Send(new CreateCompanyCommand.Request(company)));

        [HttpPost(nameof(Update))]
        public async Task<IActionResult> Update(UpdateCompanyDto company) 
            => Ok(await Mediator.Send(new UpdateCompanyDetailsCommand.Request(company)));

        [HttpPost(nameof(GetAllUsers))]
        public async Task<IActionResult> GetAllUsers(int company) 
            => Ok(await Mediator.Send(new GetAllUsersByCompanyIdQuery.Request(company)));
        
        [HttpPost(nameof(GetAllItems))]
        public async Task<IActionResult> GetAllItems(int company) 
            => Ok(await Mediator.Send(new GetAllItemsByCompanyIdQuery.Request(company)));
    }
}