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


            CartItem[] cartItems = new CartItem[]
            {
                new CartItem
                {
                       CartItemId = 1,
                       ProductId = 1,
                       Quantity = 1,
                       ShoppingCartId = 1,
                },
            };

            entity.HasData(cartItems);

        }
    }
}
