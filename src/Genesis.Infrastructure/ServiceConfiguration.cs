using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Genesis.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            return services;
        }
    }
}
