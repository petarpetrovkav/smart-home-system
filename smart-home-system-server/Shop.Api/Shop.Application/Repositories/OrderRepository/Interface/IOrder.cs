using Shop.Application.Common.Helpers;
using Shop.Application.Common.Models;

namespace Shop.Application.Repositories.OrderRepository.Interface;

public interface IOrder
{
    Task<ResponseModel> AddItem(OrderDto model);
}
