using Genesis.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandRequest:IRequest<TResponse<CreateCustomerCommandResponse>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public float Salary { get; set; }
        public string HomeOwnership { get; set; } = null!; // ev sahibliyi 
        public float EmploymentTime { get; set; } // is vaxti 
        public int CreditDetailId { get; set; }
    }
}
