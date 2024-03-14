using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<string> AddItem([FromBody] CartItemDto cartItemModel)
        {
            /* ApplicationUser currentUser = await _userManager.FindByNameAsync(User.Claims?.FirstOrDefault()?.Value);*/
            /* string user = currentUser == null ? Guid.Empty.ToString() : currentUser.Id;*/
            string user = "fccba221-bb03-4a88-9acd-bdfd4c1ac2fd";

            string response = await _cartService.Add(cartItemModel, user);

            return response;
        }

        [HttpPut("update")]
        public async Task<string> Put([FromBody] CartItemDto cartItemModel)
        {
            string user = "fccba221-bb03-4a88-9acd-bdfd4c1ac2fd";
            string response = await _cartService.Update(cartItemModel, user);

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            string user = "fccba221-bb03-4a88-9acd-bdfd4c1ac2fd";
            var response = await _cartService.Delete(id, user);

            return response;
        }

        [HttpGet]
        public async Task<string> GetAllProductByShoppingCart()
        /*public async Task<List<CartItemDto>> GetAllProductByShoppingCart()*/
        {
            /*ApplicationUser user = await _userManager.FindByNameAsync(User.Claims?.FirstOrDefault()?.Value);*/
            string user = "ae695d80-3432-4976-ad89-2e71fc8eb798";
            /* List<CartItemDto> cartDto = await _cartService.GetAllProductByShoppingCart(user);*/
            string cartDto = await _cartService.GetAllProductByShoppingCart(user);
            return cartDto;

        }
    }
}
