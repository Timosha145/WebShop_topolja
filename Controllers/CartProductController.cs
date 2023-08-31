using Microsoft.AspNetCore.Mvc;
using WebShop_topolja.Data.ApplicationDbContext;
using WebShop_topolja.Models;

namespace WebShop_topolja.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CartProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<CartProduct> GetCartProducts()
        {
            var cartProducts = _context.CartProducts.ToList();
            return cartProducts;
        }

        [HttpPost]
        public List<CartProduct> PostCartProduct([FromBody] CartProduct CartProduct)
        {
            _context.CartProducts.Add(CartProduct);
            _context.SaveChanges();
            return _context.CartProducts.ToList();
        }

        [HttpDelete("/deleteCartProduct/{id}")]
        public IActionResult DeleteCartProduct(int id)
        {
            var CartProduct = _context.CartProducts.Find(id);

            if (CartProduct == null)
            {
                return NotFound();
            }

            _context.CartProducts.Remove(CartProduct);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<CartProduct> GetCartProduct(int id)
        {
            var CartProduct = _context.CartProducts.Find(id);

            if (CartProduct == null)
            {
                return NotFound();
            }

            return CartProduct;
        }

        [HttpPut("{id}")]
        public ActionResult<List<CartProduct>> PutCartProduct(int id, [FromBody] CartProduct updatedCartProduct)
        {
            var CartProduct = _context.CartProducts.Find(id);

            if (CartProduct == null)
            {
                return NotFound();
            }

            CartProduct.ProductId = updatedCartProduct.ProductId;
            CartProduct.Quantity = updatedCartProduct.Quantity;

            _context.CartProducts.Update(CartProduct);
            _context.SaveChanges();

            return Ok(_context.CartProducts);
        }
    }
}
