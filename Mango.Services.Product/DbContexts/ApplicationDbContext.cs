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


    }
}
