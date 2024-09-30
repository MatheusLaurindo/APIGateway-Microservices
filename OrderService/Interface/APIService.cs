using Books_BusinessObjects.Model;
using Refit;

namespace OrderService.Interface
{
    public interface IBookRepository
    {
        [Get("/books/{id}")]
        Task<Book> GetAsync(int id);

        [Get("/books")]
        Task<List<Book>> GetAllBooksAsync();
    }
}
