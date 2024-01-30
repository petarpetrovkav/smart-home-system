using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop.Application.Common.Interfaces
{
    public interface IShopDbContext
    {
        public DbSet<Address> UserAddresses { get; }
        public DbSet<ShoppingCart> ShoppingCarts { get; }
        public DbSet<Product> Products { get; }
        public DbSet<ProductCategory> Categories { get; }
        public DbSet<CartItem> CartItems { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<OrderItem> OrderItems { get; }

        public Task<int> SaveChangesAsync();

    }
}
