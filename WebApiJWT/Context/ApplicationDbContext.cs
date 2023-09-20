using Microsoft.EntityFrameworkCore;
using WebApiJWT.Models;

namespace WebApiJWT.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> clients { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<User> users { get; set; }
    }
}
