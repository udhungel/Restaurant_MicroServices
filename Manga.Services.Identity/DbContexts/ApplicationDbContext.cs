using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Mango.Services.ProductAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Manga.Services.Identity.Models;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }   

    }
}
