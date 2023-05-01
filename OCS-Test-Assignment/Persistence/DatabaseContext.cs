using Microsoft.EntityFrameworkCore;
using OCS_Test_Assignment.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OCS_Test_Assignment.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost;Database=OrdersDb;Username=postgres;Password=9014356789;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders").Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Order>().ToTable("Orders").Property(p => p.Status);
            modelBuilder.Entity<Order>().ToTable("Orders").Property(p => p.Created);

            modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails").Property(c => c.Id).IsRequired();
            modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails").Property(c => c.Qty).IsRequired();
            //modelBuilder.Entity<Order>().HasMany<OrderDetails>(od => od.Lines).WithOne(o => o.ParentOrder).HasForeignKey(o => o.Id);
        }
        public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
