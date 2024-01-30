using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shop.Application.Common.Helpers;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Mappers;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.CartRepository.Interface;
using Shop.Entities;

namespace Shop.Application.Repositories.CartRepository.Services;

public class CartServices : ICartService
{
    private readonly IShopDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contxt;
    private readonly UserManager<ApplicationUser> _userManager;

    public CartServices(IShopDbContext dbContext, IMapper mapper, IHttpContextAccessor contxt, UserManager<ApplicationUser> userManager)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _contxt = contxt;
        _userManager = userManager;
    }


    /*
        TODO: 
                1. Da se dopravi koga ke bidam logiran da go zeme id na user 
                2. Dali da go cuva na server koe e id na Cart ili na frontend vo localstorage ili ?????
     */
    public async Task<CartSessionResponseModel> AddItem(CartItemDto model)
    {
        ShoppingCart shoppingCart = null;

        // TODO: OVA MOZE I NA FRONTEND DA SE NAPRAVI 
        string? cartSession = _contxt.HttpContext.Session.GetString("CartSession");

        try
        {
            if (String.IsNullOrEmpty(cartSession))
            {
                shoppingCart = new ShoppingCart();
                shoppingCart.UserId = "1";
                _dbContext.ShoppingCarts.Add(shoppingCart);
                await _dbContext.SaveChangesAsync();

                _contxt.HttpContext.Session.SetString("CartSession", shoppingCart.ShoppingCartId.ToString());
            }

            _dbContext.CartItems.Add(CartItemModel.ToCartItem(model,
                       cartSession != null ? cartSession : shoppingCart.ShoppingCartId.ToString()));
            await _dbContext.SaveChangesAsync();
        }

        catch (Exception ex)
        {
            return new CartSessionResponseModel()
            {
                isValid = false,
                ResponseMessage = ex.Message
            };
        }

        return new CartSessionResponseModel()
        {
            isValid = true,
            CartSession = cartSession != null ? Int32.Parse(cartSession) : shoppingCart.ShoppingCartId,
        };
    }

    /*    public async Task<ResponseModel> Delete(int ProductId)
        {
            int cartSession = Int32.Parse(_contxt.HttpContext.Session.GetString("CartSession"));
            CartItem cartItem = await _dbContext.CartItems.AsNoTracking()
                               .FirstOrDefaultAsync(x => x.ProductId == ProductId && x.CartItemId == cartSession);

            if (cartItem == null)
            {
                return new ResponseModel()
                {
                    isValid = false,
                    ResponseMessage = "Item doesnt exist",
                };
            }
            try
            {
                _dbContext.CartItems.Remove(cartItem);
                await _dbContext.SaveChangesAsync();

                return new ResponseModel()
                {
                    isValid = true,
                    ResponseMessage = "This item is deleted",
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
        }*/


    /*    public async Task<ResponseModel> Update(CartItemDto model)
        {
            int cartSession = Int32.Parse(_contxt.HttpContext.Session.GetString("CartSession"));
            CartItem cartItem = await _dbContext.CartItems.AsNoTracking()
                                       .FirstOrDefaultAsync(x => x.ProductId == model.ProductId && x.CartItemId == cartSession);

            if (cartItem == null)
            {
                return new ResponseModel()
                {
                    isValid = false,
                    ResponseMessage = "Item doesnt exist",
                };
            }

            CartItem cartItem = CartItemModel.ToCartItem(model, cartSession.ToString());
            _dbContext.CartItems.Update(cartItem);

            await _dbContext.SaveChangesAsync();

            return $"Address with id {entity.Id} is updated";
        }*/
}
