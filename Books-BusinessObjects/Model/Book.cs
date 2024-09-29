using Books_BusinessObjects.Enums;
using System.ComponentModel.DataAnnotations;

namespace Books_BusinessObjects.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
    }
}
