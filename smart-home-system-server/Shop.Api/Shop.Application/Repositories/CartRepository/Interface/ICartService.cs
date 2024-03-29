using Shop.Application.Common.Helpers;
using Shop.Application.Common.Models;

namespace Shop.Application.Repositories.CartRepository.Interface;

public interface ICartService
{
    Task<ResponseModel> Add(CartItemDto model, string user);
    Task<ResponseModel> Delete(string ProductId, string ShoppingCartId); /*string user*/
    Task<ResponseModel> Update(CartItemDto model, string user);
    /*Task<List<CartItemDto>> GetAllProductByShoppingCart(CartItemDto model, string user);*/
    Task<List<CartProductDto>> GetAllProductByShoppingCart(string user);

}
