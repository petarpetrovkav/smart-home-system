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

        [HttpPost]
        public async Task<IActionResult> AddItem(CartItemDto cartItemModel)
        {
            /*  ApplicationUser currentUser = await _userManager.FindByNameAsync(User.Claims?.FirstOrDefault()?.Value);
              var user = currentUser == null ? Guid.Empty.ToString() : currentUser.Id;
  */
            /* var registered = await _cartService.AddItem(cartItemModel, user);*/
            var registered = await _cartService.AddItem(cartItemModel);

            if (!registered.isValid)
            {
                return BadRequest(registered.ResponseMessage);
            }

            return Ok(registered);
        }
    }
}
