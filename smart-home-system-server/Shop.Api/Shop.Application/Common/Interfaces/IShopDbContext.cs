using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Interfaces
{
    public interface IShopDbContext
    {
        public DbSet<Address> Addresses { get; }

        public DbSet<Student> Students { get; }

        public DbSet<Teacher> Teachers { get; }

        public DbSet<Course> Courses { get; }

        public Task<int> SaveChangesAsync();
    }
}
