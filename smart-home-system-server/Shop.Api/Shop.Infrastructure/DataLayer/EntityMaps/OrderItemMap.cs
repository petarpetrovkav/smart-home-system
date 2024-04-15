using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity.ToTable(nameof(OrderItem));

            entity.Property(d => d.OrderItemId).HasColumnOrder(1);
            entity.Property(d => d.OrderId).HasColumnOrder(2);
            entity.Property(d => d.ProductId).HasColumnOrder(3);
            entity.Property(d => d.Quantity).HasColumnOrder(4);
            entity.Property(d => d.PriceAtPurchase).HasColumnOrder(5);

            OrderItem[] orderItems = new OrderItem[]
            {
                new OrderItem
                {
                  OrderItemId = Guid.Parse("d2417907-704a-44a7-8d2e-61cfab5e0f2d"),
                  OrderId = Guid.Parse("4b55da49-e4fd-4744-8e99-34e290673dd9"),
                  ProductId = Guid.Parse("5e326ee6-e48e-4b82-9b0c-f6b6e13b3c94"),
                  Quantity = 2,
                  PriceAtPurchase = 200,
                },
                new OrderItem
                {
                  OrderItemId = Guid.Parse("bd22ec0a-0a45-4138-85c5-79a2ca979d0e"),
                  OrderId = Guid.Parse("4b55da49-e4fd-4744-8e99-34e290673dd9"),
                  ProductId = Guid.Parse("914a7eaf-1f86-43fa-8ff2-fde40a2d5d91"),
                  Quantity = 1,
                  PriceAtPurchase = 100,
                },
                new OrderItem
                {
                  OrderItemId = Guid.Parse("4d03df58-cfce-42d0-afa5-8ab781fd382a"),
                  OrderId = Guid.Parse("4b55da49-e4fd-4744-8e99-34e290673dd9"),
                  ProductId = Guid.Parse("6d729ff2-c3b3-420a-a9e7-5dbd345ec0ce"),
                  Quantity = 3,
                  PriceAtPurchase = 300,
                },
            };
            entity.HasData(orderItems);
        }
    }
}
