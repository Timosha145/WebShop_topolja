using Microsoft.AspNetCore.Mvc;
using WebShop_topolja.Data.ApplicationDbContext;
using WebShop_topolja.Models;

namespace WebShop_topolja.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Order> GetOrders()
        {
            var orders = _context.Orders.ToList();
            return orders;
        }

        [HttpPost]
        public List<Order> PostOrder([FromBody] Order Order)
        {
            _context.Orders.Add(Order);
            _context.SaveChanges();
            return _context.Orders.ToList();
        }

        [HttpDelete("/deleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var Order = _context.Orders.Find(id);

            if (Order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(Order);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var Order = _context.Orders.Find(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Order>> PutOrder(int id, [FromBody] Order updatedOrder)
        {
            var Order = _context.Orders.Find(id);

            if (Order == null)
            {
                return NotFound();
            }

            Order.TotalSum = updatedOrder.TotalSum;
            Order.Paid = updatedOrder.Paid;
            Order.CartProduct = updatedOrder.CartProduct;
            Order.PersonId = updatedOrder.PersonId;

            _context.Orders.Update(Order);
            _context.SaveChanges();

            return Ok(_context.Orders);
        }
    }
}
