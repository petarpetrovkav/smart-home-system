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
    public class ShoppingSessionMap : IEntityTypeConfiguration<ShoppingSession>
    {
        public void Configure(EntityTypeBuilder<ShoppingSession> builder)
        {
            builder.ToTable(nameof(ShoppingSession));

            builder.Property(d => d.Id).HasColumnOrder(1);
            builder.Property(d => d.UserId).HasColumnOrder(2);
            builder.Property(d => d.Total).HasColumnOrder(3);
        }
    }
}