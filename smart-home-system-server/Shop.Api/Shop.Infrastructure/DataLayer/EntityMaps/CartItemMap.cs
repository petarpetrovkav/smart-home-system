using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class CartItemMap : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> entity)
        {
            entity.ToTable(nameof(CartItem));

            entity.Property(d => d.CartItemId).HasColumnOrder(1);
            entity.Property(d => d.ShoppingCartId).HasColumnOrder(2);
            entity.Property(d => d.ProductId).HasColumnOrder(3);
            entity.Property(d => d.Quantity).HasColumnOrder(4);


/*            CartItem[] cartItems = new CartItem[]
            {
                new CartItem
                {
                       CartItemId = Guid.Parse("136435bd-3d60-4b39-b1db-68db5a5d8afd"),
                       ProductId = Guid.Parse("4d45957f-73e2-4e2a-bcd1-c7af742bbf4a"),
                       Quantity = 1,
                       ShoppingCartId = Guid.Parse("e46c346d-9b79-472c-aabe-2b0258f005be"),
                },
            };

            entity.HasData(cartItems);*/

        }
    }
}
