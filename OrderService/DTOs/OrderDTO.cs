using Books_BusinessObjects.Model;

namespace OrderService.DTOs
{
    public sealed class OrderDTO
    {
        public int Id { get; set; }
        public Book? Book { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
