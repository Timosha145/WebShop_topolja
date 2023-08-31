using Microsoft.EntityFrameworkCore;
using WebShop_topolja.Models;

namespace WebShop_topolja.Data.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
