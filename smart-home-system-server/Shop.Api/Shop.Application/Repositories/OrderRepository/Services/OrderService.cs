using AutoMapper;
using Shop.Application.Common.Helpers;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Mappers;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.OrderRepository.Interface;
using Shop.Entities;

namespace Shop.Application.Repositories.OrderRepository.Services;

public class OrderService : IOrderService
{
    private readonly IShopDbContext _dbContext;
    private readonly IMapper _mapper;

    public OrderService(IShopDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ResponseModel> Add(OrderDto model, string user)
    {
        /*  List<OrderItem> orderItems = null;*/
  
        Address address = _dbContext.UserAddresses.FirstOrDefault(sc => sc.UserId == user);
   

        try
        {
            Order order = OrderItemModel.ToOrder(model.TotalCost, address.AddressId, user);
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return new ResponseModel()
            {
                isValid = true,
                ResponseMessage = order.OrderId.ToString()
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel()
            {
                isValid = false,
                ResponseMessage = ex.Message
            };
        }

    }


        /*List<OrderItem> orderItems = null;

        Order order = _mapper.Map<OrderDto, Order>(orderModel);
        _dbContext.Orders.Add(order);

        try
        {
            await _dbContext.SaveChangesAsync();
            foreach (OrderItemDto item in orderModel.ListOrderItems)
            {
                orderItems.Add(OrderItemModel.ToOrderItem(item, order.OrderId));
            }
            _dbContext.OrderItems.AddRange(orderItems);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ResponseModel()
            {
                isValid = false,
                ResponseMessage = ex.Message
            };
        }

        return new ResponseModel()
        {
            isValid = true
        };*/
}
