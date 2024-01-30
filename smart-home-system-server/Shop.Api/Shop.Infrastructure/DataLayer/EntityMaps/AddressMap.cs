using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable(nameof(Address));

            entity.Property(d => d.AddressId).HasColumnOrder(1);
            entity.Property(d => d.Street).HasColumnOrder(3).HasColumnType("varchar(50)");
            entity.Property(d => d.City).HasColumnOrder(4);
            entity.Property(d => d.PostalCode).HasColumnOrder(5);
            entity.Property(d => d.Country).HasColumnOrder(6);

            entity.HasOne(address => address.User)
                  .WithMany(user => user.Address)
                  .HasForeignKey(address => address.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            Address[] addresses = new Address[]
            {
                new Address
                {
                       AddressId = 1,
                       City = "Kavadarci",
                       Country = "Macedonia",
                       PostalCode = "1430",
                       Street = "Gorgi Sugare Br.90",
                       UserId = "1"
                },
                new Address
                {
                       AddressId = 2,
                       City = "Skopje",
                       Country = "Macedonia",
                       PostalCode = "1000",
                       Street = "Franklin Ruzvelt 50a 2/27",
                       UserId = "1"
                },
            };

            entity.HasData(addresses);
        }
    }
}