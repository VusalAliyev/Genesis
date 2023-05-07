using Genesis.Application.Dtos;
using Genesis.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _context.Customers.AddAsync(new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Salary = request.Salary,
                CreditDetailId = request.CreditDetailId,
                EmploymentTime = request.EmploymentTime,
                HomeOwnership= request.HomeOwnership,
            });
            _context.SaveChanges();

            return TResponse<CreateCustomerCommandResponse>.Success("",200);
        }
    }
}
