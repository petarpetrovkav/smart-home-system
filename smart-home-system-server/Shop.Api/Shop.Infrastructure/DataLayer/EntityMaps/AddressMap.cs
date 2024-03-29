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

            entity.Property(d => d.Id).HasColumnOrder(1);
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
                       Id = Guid.Parse("8a58c5f6-e9cb-4066-951d-f74a4d5c88d1"),
                       City = "Kavadarci",
                       Country = "Macedonia",
                       PostalCode = "1430",
                       Street = "Gorgi Sugare Br.90",
                       UserId = "392e10a6-af25-47bc-a99b-eb73a2f81b65"
                },
                new Address
                {
                       Id = Guid.Parse("d3db2f0c-19ee-4fb3-9ac4-475e2be5e47c"),
                       City = "Skopje",
                       Country = "Macedonia",
                       PostalCode = "1000",
                       Street = "Franklin Ruzvelt 50a 2/27",
                       UserId = "392e10a6-af25-47bc-a99b-eb73a2f81b65"
                },
            };

            entity.HasData(addresses);
        }
    }
}