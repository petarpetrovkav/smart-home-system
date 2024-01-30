using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Models
{
    public record RegisterModelDto(string Username, string Password, string Country, 
                                   string Email, string ConfirmPassword, string FirstName, string LastName);
}
