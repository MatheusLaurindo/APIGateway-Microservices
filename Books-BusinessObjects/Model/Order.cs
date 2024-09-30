using System.ComponentModel.DataAnnotations;

namespace Books_BusinessObjects.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
