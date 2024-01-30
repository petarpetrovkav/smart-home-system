using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable(nameof(Product));

            entity.Property(d => d.ProductId).HasColumnOrder(1);
            entity.Property(d => d.ProductCategoryId).HasColumnOrder(2);
            entity.Property(d => d.ProductName).HasColumnOrder(3).HasMaxLength(50);

            entity.Property(d => d.Description).HasColumnOrder(4).HasColumnType("varchar(200)");
            entity.Property(d => d.Price).HasColumnOrder(5);
            entity.Property(d => d.StockQuantity).HasColumnOrder(6);
            entity.Property(d => d.ImageUrl).HasColumnOrder(7).HasColumnType("varchar(500)");
            entity.Property(d => d.CreatedAt).HasColumnOrder(8).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("(GetDate())");
            entity.Property(d => d.ModifiedAt).HasColumnOrder(9);
            entity.Property(d => d.DeletedAt).HasColumnOrder(10);



            Product[] products = new Product[]
            {
                new Product
                {
                    ProductId = 1,
                    ProductCategoryId = 1,
                    ProductName = "Hive Thermostat",
                    Price = 100,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/32ND65okw7jecneQDSTrrL/7427260a14a45fa5bb7619e205329181/Thermostat-PDP-Hero.png?fit=fill&h=500&q=100&w=500",                },
                new Product
                {
                    ProductId = 2,
                    ProductCategoryId = 1,
                    ProductName = "Hive Heating Plus",
                    Price = 500,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/mmqdniwkP9usRz1k5Tlwq/157c00189574c325a9d4c1c5a23a92e6/HHplus-PDP-Hero.png?fit=fill&h=500&q=100&w=500",
                },
                new Product
                {
                    ProductId= 3,
                    ProductCategoryId = 2,
                    ProductName = "E27 / B22 Smart Light Bulb",
                    Price = 100,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/6WkACGS9wvpAOQh2tvzTlP/306bce1547e9d634105ddf62351fdb50/img-pdp_hero_e27_dimmable_2x.jpeg?fit=fill&h=500&q=100&w=500",
                },
                new Product
                {
                    ProductId= 4,
                    ProductCategoryId = 2,
                    ProductName = "E14 Smart Light Bulb",
                    Price = 500,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/2zRGkm83nRH3G4pBsbEDdB/4f2d7abbf3dfb34762ff4aa50ac05d57/img-pdp_hero_e14_dimmable_2x.jpeg?fit=fill&h=500&q=100&w=500",
                },
            };

            entity.HasData(products);

        }
    }
}