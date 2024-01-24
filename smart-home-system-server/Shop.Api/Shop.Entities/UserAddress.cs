using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int ApplicationUserId { get; set; }
        public ICollection<ApplicationUser>? Users { get; set; }
    }
}
