using Genesis.Application.Dtos;
using Genesis.Infrastructure;
using MediatR;

namespace Genesis.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, TResponse<CreateCustomerCommandResponse>>
    {
        private readonly AppDbContext _context;

        public CreateCustomerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TResponse<CreateCustomerCommandResponse>> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(new Domain.Entities.Customer
            {
                FirstName = request.Customer.FirstName,
                LastName = request.Customer.LastName,
                Age = request.Customer.Age,
                Salary = request.Customer.Salary,
                EmploymentTime = request.Customer.EmploymentTime,
                HomeOwnership = request.Customer.HomeOwnership,
                CreditDetail = request.Customer.CreditDetail
            });

            _context.SaveChanges();
            return TResponse<CreateCustomerCommandResponse>.Success(200);
        }
    }
}
