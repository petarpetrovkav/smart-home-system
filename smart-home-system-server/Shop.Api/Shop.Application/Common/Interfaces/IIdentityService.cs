using Shop.Application.Common.Helpers;
using Shop.Application.Common.Models;
using Shop.Entities;

namespace Shop.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<ResponseModel> Register(RegisterModelDto model);

        Task<SignInResponse> SignIn(SignInModelDto model);

        Task<ApplicationUser> GetUserByUserName(string userName);
    }
}
