using Microsoft.AspNetCore.Mvc;
using WebShop_topolja.Data.ApplicationDbContext;
using WebShop_topolja.Models;

namespace WebShop_topolja.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        [HttpPost]
        public List<Product> PostProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return _context.Products.ToList();
        }

        [HttpDelete("/deleteProduct/{id}")]
        public IActionResult DeleteProduct2(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Product>> PutProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Image = updatedProduct.Image;
            product.Active = updatedProduct.Active;
            product.Stock = updatedProduct.Stock;
            product.CategoryId = updatedProduct.CategoryId;

            _context.Products.Update(product);
            _context.SaveChanges();

            return Ok(_context.Products);
        }
    }
}
