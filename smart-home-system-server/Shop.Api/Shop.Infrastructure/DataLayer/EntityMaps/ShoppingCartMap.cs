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
            entity.Property(d => d.Id).HasColumnOrder(1);
            entity.Property(d => d.CreatedAt).HasColumnOrder(2).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("(GetDate())");
            entity.Property(d => d.UpdatedAt).HasColumnOrder(3);



            entity.HasOne(shoppingCart => shoppingCart.User)
           .WithMany(user => user.ShoppingCarts)
           .HasForeignKey(shoppingCart => shoppingCart.UserId)
           .OnDelete(DeleteBehavior.Cascade);

/*
            ShoppingCart[] shoppingCarts = new ShoppingCart[]
            {
                new ShoppingCart
                {
                   ShoppingCartId=1,
                   UserId = Guid.Parse("0a02b5f0-9916-4774-915e-b8e2c8c6bed8")
                },
            };
            entity.HasData(shoppingCarts);*/
        }
    }
}