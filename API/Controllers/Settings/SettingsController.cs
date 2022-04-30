using API.Controllers.Base;
using Application.Settings.Commands;
using Application.Settings.Dto;
using Application.Settings.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Settings
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : BaseController
    {
        public SettingsController(IMediator mediator) : base(mediator) { }

        [HttpGet(nameof(GetByCompanyId))]
        public async Task<IActionResult> GetByCompanyId(int companyId) 
            => Ok(await Mediator.Send(new GetSettingsByCompanyIdQuery.Request(companyId)));

        [HttpPost(nameof(UpdateByCompanyId))]
        public async Task<IActionResult> UpdateByCompanyId(UpdateSettingsDto settings) 
            => Ok(await Mediator.Send(new UpdateSettingsByCompanyIdCommand.Request(settings)));
    }
}