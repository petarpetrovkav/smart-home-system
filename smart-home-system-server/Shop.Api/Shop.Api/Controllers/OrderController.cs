﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Common.Helpers;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.OrderRepository.Interface;
using Shop.Application.Repositories.OrderRepository.Services;
using Shop.Entities;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _orderService = (OrderService?)orderService;
            _userManager = userManager;
        }

        [HttpPost("AddItem")]
        public async Task<ResponseModel> AddItem([FromBody] OrderDto orderModel)
        {
            /* ApplicationUser currentUser = await _userManager.FindByNameAsync(User.Claims?.FirstOrDefault()?.Value);*/
            /* string user = currentUser == null ? Guid.Empty.ToString() : currentUser.Id;*/
            string user = "f171b554-c344-4233-8a6a-43f4ce5f2197";
            return await _orderService.Add(orderModel, user);
        }
    }
}
