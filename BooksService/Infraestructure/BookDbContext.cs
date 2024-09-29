using Books_BusinessObjects.Model;
using Microsoft.EntityFrameworkCore;

namespace BooksService.Infraestructure
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
