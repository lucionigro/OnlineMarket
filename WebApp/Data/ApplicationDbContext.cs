using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Order> Order { get; set; }
        public DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
