using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Common.Models;
using Shop.Application.Common.Helpers;
using Shop.Entities;

namespace Shop.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<ResponseModel> Register(RegisterModelDto model);

        Task<string> SignIn(SignInModelDto model);

        Task<ApplicationUser> GetUserByUserName(string userName);
    }
}
