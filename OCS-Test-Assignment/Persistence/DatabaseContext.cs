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
            => optionsBuilder.UseNpgsql("Host=myDatabase;Database=my_db;Username=my_user;Password=my_pw");
    public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetailss { get; set; }
    }
}
