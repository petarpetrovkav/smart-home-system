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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));

            builder.Property(d => d.Id).HasColumnOrder(1);
            builder.Property(d => d.Name).HasColumnOrder(2).HasMaxLength(50);
            builder.Property(d => d.Desc).HasColumnOrder(3).HasColumnType("varchar(200)");

        }
    }
}
