using Shop.Application.Common.Helpers;
using Shop.Application.Common.Models;

namespace Shop.Application.Repositories.OrderRepository.Interface;

public interface IOrderService
{
    Task<ResponseModel> Add(OrderDto model, string user);
    /* Task<List<CartProductDto>> GetAllOrder();*/
}
