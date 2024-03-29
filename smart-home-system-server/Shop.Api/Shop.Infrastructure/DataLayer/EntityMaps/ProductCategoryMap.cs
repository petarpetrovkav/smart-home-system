using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> entity)
        {
            entity.ToTable(nameof(ProductCategory));

            entity.Property(d => d.ProductCategoryId).HasColumnOrder(1);
            entity.Property(d => d.Name).HasColumnOrder(2).HasMaxLength(50);
            entity.Property(d => d.Desc).HasColumnOrder(3).HasColumnType("varchar(200)");
            entity.Property(d => d.CreatedAt).HasColumnOrder(4).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("(GetDate())");
            entity.Property(d => d.ModifiedAt).HasColumnOrder(5);
            entity.Property(d => d.DeletedAt).HasColumnOrder(6);

            ProductCategory[] productCategories = new ProductCategory[]
            {
                new ProductCategory
                {
                    ProductCategoryId = Guid.Parse("7d6f45c8-a818-4336-8040-ea762e5c7990"),
                    Name = "Smart Heating",
                },
                new ProductCategory
                {
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    Name = "Smart Home",
                },
                new ProductCategory
                {
                    ProductCategoryId = Guid.Parse("1745e8de-2eac-4ccb-b954-1d00435fe66c"),
                    Name = "EV Charging",
                },
            };

            entity.HasData(productCategories);
        }
    }
}