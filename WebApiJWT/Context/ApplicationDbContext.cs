using Microsoft.EntityFrameworkCore;
using WebApiJWT.Models;

namespace WebApiJWT.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Clients> clients { get; set; }

        public DbSet<Products> products { get; set; }

        public DbSet<User> users { get; set; }
    }
}
