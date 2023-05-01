using Microsoft.EntityFrameworkCore;
using OCS_Test_Assignment.Models;

namespace OCS_Test_Assignment.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost;Database=OSCOrders;Username=postgres;Password=9014356789;");
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
