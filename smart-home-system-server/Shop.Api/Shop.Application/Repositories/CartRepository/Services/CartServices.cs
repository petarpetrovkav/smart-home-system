using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public async Task<ResponseModel> Add(CartItemDto model, string user)
    {
        ShoppingCart shoppingCart = null;
        ShoppingCart cart = _dbContext.ShoppingCarts.SingleOrDefault(sc => sc.UserId == user && sc.UpdatedAt == null);

        try
        {
            if (cart is null)
            {
                shoppingCart = new ShoppingCart();
                shoppingCart.UserId = user;
                shoppingCart.UpdatedAt = null;
                _dbContext.ShoppingCarts.Add(shoppingCart);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                try
                {
                    CartItem item = _dbContext.CartItems.SingleOrDefault(ci => ci.ProductId == Guid.Parse(model.ProductId) && ci.ShoppingCartId == cart.Id);
                    if (item is not null)
                    {
                        return new ResponseModel()
                        {
                            isValid = true,
                            ResponseMessage = "You have added the product to the basket"
                        };
                    }
                   
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
           

            _dbContext.CartItems.Add(CartItemModel.ToCartItem(model, (cart is not null) ? cart.Id : shoppingCart.Id));
            await _dbContext.SaveChangesAsync();

            return new ResponseModel()
            {
                isValid = true,
                ResponseMessage = "Product is added"
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



    public async Task<ResponseModel> Delete(string ProductId, string ShoppingCartId)  /* string user*/
    {
        /*  ShoppingCart cart = await _dbContext.ShoppingCarts.SingleOrDefaultAsync(sc => sc.UserId == user && sc.UpdatedAt == null);*/
        CartItem cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(x => x.ShoppingCartId == Guid.Parse(ShoppingCartId) && x.ProductId == Guid.Parse(ProductId));

        try
        {
            _dbContext.CartItems.Remove(cartItem);
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
            isValid = true,
            ResponseMessage = "Product has been deleted"
        };
    }



    public async Task<ResponseModel> Update(CartItemDto model, string user)
    {
        /*ShoppingCart cart = await _dbContext.ShoppingCarts.SingleOrDefaultAsync(sc => sc.UserId == user && sc.UpdatedAt == null);*/
        CartItem cartItem = await _dbContext.CartItems.
            FirstOrDefaultAsync(x => x.ShoppingCartId == Guid.Parse(model.ShoppingCartId) && x.ProductId == Guid.Parse(model.ProductId));

        try
        {
            cartItem.Quantity = model.Quantity;
            _dbContext.CartItems.Update(cartItem);
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
            isValid = true,
            ResponseMessage = "Product has been updated"
        };

    }

    public async Task<List<CartProductDto>> GetAllProductByShoppingCart(string user)
    {
        ShoppingCart cart = await _dbContext.ShoppingCarts.SingleOrDefaultAsync(sc => sc.UserId == user && sc.UpdatedAt == null);
        List<CartProductDto> productDto = new();

        if (cart is not null) { 
            List<CartItem> cartItems = _dbContext.CartItems.Include(product => product.Product).Where(cartItem => cartItem.ShoppingCartId == cart.Id).ToList();
            List<CartItemDto> cartItemsDto = new();
       
            foreach (CartItem cartItem in cartItems)
            {
                CartProductDto cartProductDto = ProductModel.ToCartProductDto(cartItem.Product, cartItem.Quantity, cart.Id);          
                productDto.Add(cartProductDto);
            }
            return productDto;
        }
        return productDto;
    }


}
