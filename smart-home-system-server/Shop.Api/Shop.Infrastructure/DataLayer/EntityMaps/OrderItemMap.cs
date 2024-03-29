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

  /*          OrderItem[] orderItems = new OrderItem[]
            {
                new OrderItem
                {
                  OrderItemId = Guid.Parse("d2417907-704a-44a7-8d2e-61cfab5e0f2d"),
                  OrderId = Guid.Parse("1156aaeb-8849-430a-b7c3-ee2e596c7c1e"),
                  ProductId = Guid.Parse("da754736-f440-42fe-b329-1b9bef43e3f0"),
                  Quantity = 2,
                  PriceAtPurchase = 200,
                },
                new OrderItem
                {
                  OrderItemId = Guid.Parse("bd22ec0a-0a45-4138-85c5-79a2ca979d0e"),
                  OrderId = 1,
                  ProductId = Guid.Parse("c3d91c54-f10a-4391-9b76-42083d4f362a"),
                  Quantity = 1,
                  PriceAtPurchase = 100,
                },
                new OrderItem
                {
                  OrderItemId = Guid.Parse("4d03df58-cfce-42d0-afa5-8ab781fd382a"),
                  OrderId = 2,
                  ProductId = Guid.Parse("da754736-f440-42fe-b329-1b9bef43e3f0"),
                  Quantity = 3,
                  PriceAtPurchase = 300,
                },
            };
            entity.HasData(orderItems);*/
        }
    }
}
