using Microsoft.EntityFrameworkCore;
using Books_BusinessObjects.Model;

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
