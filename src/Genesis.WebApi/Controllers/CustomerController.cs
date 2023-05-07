using Genesis.Application.Features.Commands.Customer.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommandRequest requestModel)
        {
            CreateCustomerCommandResponse customer=await _mediator.Send(requestModel);
            return Ok(customer);
        }
    }
}
