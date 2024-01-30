using AutoMapper;
using Shop.Application.Common.Helpers;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Mappers;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.OrderRepository.Interface;
using Shop.Entities;

namespace Shop.Application.Repositories.OrderRepository.Services;

public class OrderService : IOrder
{
    private readonly IShopDbContext _dbContext;
    private readonly IMapper _mapper;

    public OrderService(IShopDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ResponseModel> AddItem(OrderDto orderModel)
    {
        List<OrderItem> orderItems = null;

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
        };
    }
}
