using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable(nameof(Order));

            entity.Property(d => d.OrderId).HasColumnOrder(1);
            entity.Property(d => d.AddressId).HasColumnOrder(3);
            entity.Property(d => d.PaymentMethod).HasColumnOrder(4).HasMaxLength(20);

            entity.Property(d => d.OrderStatus).HasConversion(forward => forward.ToString(),
                             backwards => (OrderStatus)Enum.Parse(typeof(OrderStatus), backwards, true)).HasColumnOrder(5).HasMaxLength(20);

            entity.Property(d => d.OrderDate).HasColumnOrder(6).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("(GetDate())");
            entity.Property(d => d.TotalCost).HasColumnOrder(7);

            Order[] orders = new Order[]
            {
                new Order
                {
                    OrderId = 1,
                    AddressId = 1,
                    PaymentMethod = "test",
                    OrderStatus = OrderStatus.Pending,
                    TotalCost = 160,
                    UserId = "1",
                },
                new Order
                {
                    OrderId = 2,
                    AddressId = 2,
                    PaymentMethod = "test",
                    OrderStatus = OrderStatus.Processing,
                    TotalCost = 1500,
                    UserId = "1",
                },
            };

            entity.HasData(orders);
        }
    }
}
