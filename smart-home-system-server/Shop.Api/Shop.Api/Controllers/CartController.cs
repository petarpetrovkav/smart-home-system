using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Common.Helpers;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.CartRepository.Interface;
using Shop.Application.Repositories.CartRepository.Services;
using Shop.Entities;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartServices _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = (CartServices?)cartService;
            _userManager = userManager;
        }

        /*        [HttpGet("getAllByUser")]
                public async Task<IEnumerable<>>*/

        [HttpPost("AddItem")]
        public async Task<ResponseModel> AddItem([FromBody] CartItemDto cartItemModel)
        {
            /* ApplicationUser currentUser = await _userManager.FindByNameAsync(User.Claims?.FirstOrDefault()?.Value);*/
            /* string user = currentUser == null ? Guid.Empty.ToString() : currentUser.Id;*/
            string user = "a353673a-9586-42e1-8921-7413f50fd650";
            return await _cartService.Add(cartItemModel, user);
        }

        [HttpPut("Update")]
        public async Task<ResponseModel> Put([FromBody] CartItemDto cartItemModel)
        {
            string user = "a353673a-9586-42e1-8921-7413f50fd650";
            return await _cartService.Update(cartItemModel, user);
        }

        [HttpDelete("Delete")]
        public async Task<ResponseModel> Delete([FromBody] CartItemDto cartItemModel)     /*, int shoppingCartId*/
        {
            string user = "a353673a-9586-42e1-8921-7413f50fd650";
            return await _cartService.Delete(cartItemModel.ProductId, cartItemModel.ShoppingCartId);
        }

        [HttpGet("GetAllProductByShoppingCart")]
        public async Task<IEnumerable<CartProductDto>> GetAllProductByShoppingCart()
        {
            /*ApplicationUser user = await _userManager.FindByNameAsync(User.Claims?.FirstOrDefault()?.Value);*/
            string user = "a353673a-9586-42e1-8921-7413f50fd650";
            return await _cartService.GetAllProductByShoppingCart(user);
        }
    }
}
