using Genesis.Application.Dtos;
using Genesis.Infrastructure;
using Genesis.Infrastructure.Services;
using MediatR;
using System.Net.Http.Json;
using System.Text.Json;

namespace Genesis.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, TResponse<CreateCustomerCommandResponse>>
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
        public CreateCustomerCommandHandler(AppDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<TResponse<CreateCustomerCommandResponse>> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var data = new Domain.Entities.Customer
            {
                FirstName = request.Customer.FirstName,
                LastName = request.Customer.LastName,
                Age = request.Customer.Age,
                Salary = request.Customer.Salary,
                EmploymentTime = request.Customer.EmploymentTime,
                HomeOwnership = request.Customer.HomeOwnership,
                CreditDetail = request.Customer.CreditDetail
            };

            var json = JsonSerializer.Serialize(data);

            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"data",json }
            };
            var result = await _httpClient.PostAsJsonAsync($"91.102.161.166:5000/predict?data={dict["data"]}", "");
            var resultString = await result.Content.ReadAsStringAsync();
            var responseSuccess = JsonSerializer.Deserialize<int>(resultString);
            if (responseSuccess == 1)
            {
                EmailService.SendEmail("huseynma@code.edu.az", "<h4>Təbriklər siz kredit üçün müraciətiniz qeydə alındı.</h4>");
                await _context.Customers.AddAsync(data);
                _context.SaveChanges();
                return TResponse<CreateCustomerCommandResponse>.Success(200);
            }
            else
            {
                EmailService.SendEmail("huseynma@code.edu.az", "<h4>Təəssüfki siz kredit götürə bilməssiniz</h4>");
                return TResponse<CreateCustomerCommandResponse>.Fail("Kredit şərtlərinə uyğun deyilsiz", 400);
            }
        }
    }
}
