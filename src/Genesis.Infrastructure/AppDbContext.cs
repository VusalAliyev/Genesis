using Genesis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Genesis.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CreditDetail> CreditDetails { get; set; }
    }
}
