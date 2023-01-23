using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Mango.Services.ProductAPI.Models;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
         

        }

        public DbSet<MangoProduct> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MangoProduct>().HasData(new MangoProduct 
            {
                ProductId = 1,
                Name= "Samosa",
                Price = 15,
                Description = "Tasty snack food for Appetizer",
                ImageUrl="",
                CategoryName = "Appetizer"
                
            });
            modelBuilder.Entity<MangoProduct>().HasData(new MangoProduct
            {
                ProductId = 2,
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = "Test meal for 2 ",
                ImageUrl = "",
                CategoryName = "Appetizer"

            });
            modelBuilder.Entity<MangoProduct>().HasData(new MangoProduct
            {
                ProductId = 3,
                Name = "Sweet Pie",
                Price = 10.99,
                Description = "Dessert meal for 2 ",
                ImageUrl = "",
                CategoryName = "Dessert"

            });
            modelBuilder.Entity<MangoProduct>().HasData(new MangoProduct
            {
                ProductId = 4,
                Name = "Pav Bhaji",
                Price = 15,
                Description = "Entree meal for 2 ",
                ImageUrl = "",
                CategoryName = "Entree"

            });
        }


    }
}
