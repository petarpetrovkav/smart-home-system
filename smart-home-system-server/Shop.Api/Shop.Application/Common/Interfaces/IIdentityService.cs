using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<ResponseModel> Register(RegisterModelDto model);

        Task<string> SignIn(SignInModelDto model);

        Task<ApplicationUser> GetUserByUserName(string userName);
    }
}
