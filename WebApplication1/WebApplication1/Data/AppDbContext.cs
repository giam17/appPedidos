using Microsoft.EntityFrameworkCore;
using TuProyecto.Models;

namespace TuProyecto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Precio)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(i => i.PrecioUnitario)
                .HasPrecision(18, 2);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Cliente)
                .WithMany(u => u.Orders!)
                .HasForeignKey(o => o.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Product)
                .WithMany() 
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Order>()
                .Property(o => o.Fecha)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
