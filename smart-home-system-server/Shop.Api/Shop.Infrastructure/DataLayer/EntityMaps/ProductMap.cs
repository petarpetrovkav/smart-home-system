using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.Property(d => d.Id).HasColumnOrder(1);
            builder.Property(d => d.CartItemId).HasColumnOrder(2);
            builder.Property(d => d.CategoryId).HasColumnOrder(3);

            builder.Property(d => d.Name).HasColumnOrder(4).HasMaxLength(50);
            builder.Property(d => d.Desc).HasColumnOrder(5).HasColumnType("varchar(200)");
            builder.Property(d => d.Price).HasColumnOrder(6);
            builder.Property(d => d.Url).HasColumnOrder(7);

        }
    }
}