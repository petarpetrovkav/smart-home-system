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
                  OrderItemId = 1,
                  OrderId = 1,
                  ProductId = 1,
                  Quantity = 2,
                  PriceAtPurchase = 200,
                },
                new OrderItem
                {
                  OrderItemId = 2,
                  OrderId = 1,
                  ProductId = 2,
                  Quantity = 1,
                  PriceAtPurchase = 100,
                },
                new OrderItem
                {
                  OrderItemId = 3,
                  OrderId = 2,
                  ProductId = 1,
                  Quantity = 3,
                  PriceAtPurchase = 300,
                },
                new OrderItem
                {
                  OrderItemId= 4,
                  OrderId = 1,
                  ProductId = 3,
                  Quantity = 4,
                  PriceAtPurchase = 150,
                },
            };
            entity.HasData(orderItems);
        }
    }
}
