using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> product { get; set; }

    }
}
