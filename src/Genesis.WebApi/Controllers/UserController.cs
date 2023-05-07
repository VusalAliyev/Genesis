using Genesis.Application.Dtos;
using Genesis.Application.Features.Queries.User.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] GetUserQueryRequest requestModel)
        {
            TResponse<GetUserQueryResponse> user = await _mediator.Send(requestModel);
            return Ok(user);
        }
    }
}
