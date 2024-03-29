using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Interfaces;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser>, IShopDbContext
    {
        public ShopDbContext() { }

        public ShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-NOBPBIS\\SQLEXPRESS;Database=SmartHomeSystemShop;Trusted_Connection=True;");
            }
        }

        public DbSet<Address> UserAddresses => Set<Address>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCategory> Categories => Set<ProductCategory>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Order> Orders { get; }
        public DbSet<OrderItem> OrderItems { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            builder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
            base.OnModelCreating(builder);
        }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
