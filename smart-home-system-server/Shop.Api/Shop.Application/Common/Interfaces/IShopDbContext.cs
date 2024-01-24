using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Interfaces
{
    public interface IShopDbContext
    {
        public DbSet<UserAddress> UserAddresses { get; }
        public DbSet<ShoppingSession> ShoppingSessions { get; }
        public DbSet<Product> Products { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<CartItem> CartItems { get; }
        public Task<int> SaveChangesAsync();
    }
}
