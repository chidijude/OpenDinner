using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenDinner.Application.Menus.Commands.CreateMenu;
using OpenDinner.Contracts.Menus;

namespace OpenDinner.Api.Controllers
{
    [Route("hosts/{hostId}/[controller]")]
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public MenusController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));

            var creatMenuResult = await _mediator.Send(command);
            return creatMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));
        }
    }
}
