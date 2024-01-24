using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class CartItemMap : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable(nameof(CartItem));

            builder.Property(d => d.Id).HasColumnOrder(1);
            builder.Property(d => d.ProductId).HasColumnOrder(2);
            builder.Property(d => d.Quantity).HasColumnOrder(3);
            builder.Property(d => d.ShoppingSessionId).HasColumnOrder(4);
        }
    }
}
