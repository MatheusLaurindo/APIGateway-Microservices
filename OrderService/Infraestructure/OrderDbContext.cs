using Books_BusinessObjects.Model;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Infraestructure
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
