using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string Country { get; set; } = null!;
        public int UserAddressId { get; set; }
        public UserAddress? UserAddress { get; set; }
    }
}
