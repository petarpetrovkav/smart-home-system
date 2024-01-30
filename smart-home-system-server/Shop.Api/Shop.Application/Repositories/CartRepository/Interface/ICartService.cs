using Shop.Application.Common.Helpers;
using Shop.Application.Common.Models;

namespace Shop.Application.Repositories.CartRepository.Interface;

public interface ICartService
{
    Task<CartSessionResponseModel> AddItem(CartItemDto model);
    /*    Task<string> Delete(int ProductId);
        Task<string> Update(CartItemDto model);*/
}
