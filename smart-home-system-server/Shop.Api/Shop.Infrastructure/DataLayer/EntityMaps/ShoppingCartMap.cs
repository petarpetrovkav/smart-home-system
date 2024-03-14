using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class ShoppingCartMap : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> entity)
        {
            entity.ToTable(nameof(ShoppingCart));
            entity.Property(d => d.ShoppingCartId).HasColumnOrder(1);
            entity.Property(d => d.CreatedAt).HasColumnOrder(2).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("(GetDate())");
            entity.Property(d => d.UpdatedAt).HasColumnOrder(3);



            entity.HasOne(shoppingCart => shoppingCart.User)
           .WithMany(user => user.ShoppingCarts)
           .HasForeignKey(shoppingCart => shoppingCart.UserId)
           .OnDelete(DeleteBehavior.Cascade);


            ShoppingCart[] shoppingCarts = new ShoppingCart[]
            {
                new ShoppingCart
                {
                   ShoppingCartId=1,
                   UserId = "1",
                },
            };
            entity.HasData(shoppingCarts);
        }
    }
}