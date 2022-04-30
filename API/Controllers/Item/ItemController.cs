using API.Controllers.Base;
using Application.Items.Commands;
using Application.Items.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Item
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : BaseController
    {
        public ItemController(IMediator mediator) : base(mediator) { }

        [HttpGet(nameof(GetById))]
        public async Task<IActionResult> GetById(int id) 
            => Ok(await Mediator.Send(new GetItemByIdQuery.Request(id)));

        [HttpGet(nameof(Delete))]
        public async Task<IActionResult> Delete(int id) 
            => Ok(await Mediator.Send(new DeleteItemByIdCommand.Request(id)));

        // update
        // create
    }
}