using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = "1",
                Country = "Macedonia",
                FirstName = "Petar",
                LastName = "Petrov",
            };

            entity.HasData(user);
        }
    }
}