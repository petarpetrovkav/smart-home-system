using Shop.Application.Common.Models;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Mappers
{
    public static class RegisterModel
    {
        public static ApplicationUser ToApplicationUser(this RegisterModelDto registerModel)
        {
            return new ApplicationUser()
            {
                Country = registerModel.Country,
                Email = registerModel.Email,
                UserName = registerModel.Username,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
            };

        }
    }
}
