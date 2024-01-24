using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shop.Entities;
using Shop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Hosting.Server;

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
                optionsBuilder.UseSqlServer("Server=DESKTOP-C37NTHQ\\SQLEXPRESS;Database=SmartHomeSystemShop;Trusted_Connection=True;");
            }
        }

        public DbSet<UserAddress> UserAddresses => Set<UserAddress>();
        public DbSet<ShoppingSession> ShoppingSessions => Set<ShoppingSession>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<CartItem> CartItems => Set<CartItem>();


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
