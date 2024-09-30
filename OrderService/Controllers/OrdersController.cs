using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Books_BusinessObjects.Model;
using OrderService.Infraestructure;
using OrderService.Interface;
using OrderService.Repository;
using OrderService.DTOs;

namespace OrderService.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _context;
        private readonly BookRepository _repository;

        public OrdersController(OrderDbContext context, BookRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();

            var booksFromOrder = await _repository.GetAllBooksAsync();

            return orders
                .Select(order =>
                {
                    var book = booksFromOrder.FirstOrDefault(b => b.Id == order.BookId);

                    return new OrderDTO
                    {
                        Id = order.Id,
                        Book = book,
                        Quantity = order.Quantity,   
                        Price = order.Price,
                    };
                })
                .ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            var bookFromOrder = await _repository.GetBookAsync(order.BookId);

            if (order == null)
            {
                return NotFound();
            }

            return new OrderDTO
            {
                Id = order.Id,
                Book = bookFromOrder,
                Quantity = order.Quantity,
                Price = order.Price
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
