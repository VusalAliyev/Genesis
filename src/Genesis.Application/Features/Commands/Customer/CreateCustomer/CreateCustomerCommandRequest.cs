using Genesis.Application.Dtos;
using MediatR;

namespace Genesis.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandRequest : IRequest<TResponse<CreateCustomerCommandResponse>>
    {
        public Genesis.Domain.Entities.Customer Customer { get; set; }
    }
}
