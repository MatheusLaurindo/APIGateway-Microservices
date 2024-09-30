using Books_BusinessObjects.Model;
using OrderService.Interface;
using Refit;

namespace OrderService.Repository
{
    public class BookRepository
    {
        private readonly IBookRepository _api;

        public BookRepository()
        {
            _api = RestService.For<IBookRepository>("http://localhost:5027/gateway");
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _api.GetAsync(id);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _api.GetAllBooksAsync();
        }
    }
}
