using Microsoft.AspNetCore.Mvc;
using WebShop_topolja.Data.ApplicationDbContext;
using WebShop_topolja.Models;

namespace WebShop_topolja.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CategoryController : Controller
    {       
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Category> GetCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        [HttpPost]
        public List<Category> PostCategory([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return _context.Categories.ToList();
        }

        [HttpDelete("/deleteCategory/{id}")]
        public IActionResult DeleteCategory2(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPut("{id}")]
        public ActionResult<List<Category>> PutCategory(int id, [FromBody] Category updatedcategory)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = updatedcategory.Name;

            _context.Categories.Update(category);
            _context.SaveChanges();

            return Ok(_context.Categories);
        }
    }
}
