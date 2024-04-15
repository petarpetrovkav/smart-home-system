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
                    OrderId = Guid.Parse("4b55da49-e4fd-4744-8e99-34e290673dd9"),
                    AddressId = Guid.Parse("D3DB2F0C-19EE-4FB3-9AC4-475E2BE5E47C"),
                    PaymentMethod = "test",
                    OrderStatus = OrderStatus.Pending,
                    TotalCost = 160,
                    UserId = "392e10a6-af25-47bc-a99b-eb73a2f81b65",
                },
  /*              new Order
                {
                    OrderId = Guid.NewGuid(),
                    AddressId = Guid.Parse("D3DB2F0C-19EE-4FB3-9AC4-475E2BE5E47C"),
                    PaymentMethod = "test",
                    OrderStatus = OrderStatus.Processing,
                    TotalCost = 1500,
                    UserId = "0a02b5f0-9916-4774-915e-b8e2c8c6bed8",
                },*/
            };

            entity.HasData(orders);
        }
    }
}
