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
    public class UserAddressMap : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable(nameof(UserAddress));

            builder.Property(d => d.Id).HasColumnOrder(1);
            builder.Property(d => d.ApplicationUserId).HasColumnOrder(2);
            builder.Property(d => d.Address).HasColumnOrder(3).HasColumnType("varchar(50)"); ;
            builder.Property(d => d.City).HasColumnOrder(4);
            builder.Property(d => d.PostalCode).HasColumnOrder(5);
        }
    }
}