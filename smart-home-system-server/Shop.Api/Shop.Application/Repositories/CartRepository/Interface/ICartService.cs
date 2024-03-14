using Shop.Application.Common.Models;

namespace Shop.Application.Repositories.CartRepository.Interface;

public interface ICartService
{
    Task<string> Add(CartItemDto model, string user);
    Task<string> Delete(int ProductId, string user);
    Task<string> Update(CartItemDto model, string user);
    /*Task<List<CartItemDto>> GetAllProductByShoppingCart(CartItemDto model, string user);*/
    Task<string> GetAllProductByShoppingCart(string user);

}
