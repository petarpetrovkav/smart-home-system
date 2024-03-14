using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public async Task<string> Add(CartItemDto model, string user)
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
            _dbContext.CartItems.Add(CartItemModel.ToCartItem(model, (cart is not null) ? cart.ShoppingCartId : shoppingCart.ShoppingCartId));
            await _dbContext.SaveChangesAsync();

            return "Product is added";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }



    public async Task<string> Delete(int ProductId, string user)
    {
        ShoppingCart cart = await _dbContext.ShoppingCarts.SingleOrDefaultAsync(sc => sc.UserId == user && sc.UpdatedAt == null);
        CartItem cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(x => x.ShoppingCartId == cart.ShoppingCartId && x.ProductId == ProductId);

        try
        {
            _dbContext.CartItems.Remove(cartItem);
            await _dbContext.SaveChangesAsync();
            return "This item is deleted";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }



    public async Task<string> Update(CartItemDto model, string user)
    {
        ShoppingCart cart = await _dbContext.ShoppingCarts.SingleOrDefaultAsync(sc => sc.UserId == user && sc.UpdatedAt == null);
        CartItem cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(x => x.ShoppingCartId == cart.ShoppingCartId && x.ProductId == model.ProductId);

        try
        {
            cartItem.Quantity = model.Quantity;
            _dbContext.CartItems.Update(cartItem);
            await _dbContext.SaveChangesAsync();
            return $"Product is updated";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<string> GetAllProductByShoppingCart(string user)
    /*public async Task<List<CartItemDto>> GetAllProductByShoppingCart(string user)*/
    {
        ShoppingCart cart = await _dbContext.ShoppingCarts.SingleOrDefaultAsync(sc => sc.UserId == user && sc.UpdatedAt == null);
        /* IList<CartItem> cartItem = _dbContext.CartItems.Include(x => x.Product).Where(x => x.ShoppingCartId == cart.ShoppingCartId).ToList();*/  //(x => x.ShoppingCartId == cart.ShoppingCartId);
        /*  var cartItemsInCart = _dbContext.CartItems.Where(x => x.ShoppingCartId == cart.ShoppingCartId).ToList();
          var productIdsInCart = cartItemsInCart.Select(cartItems => new { ProductId = cartItems.ProductId, Quantity = cartItems.Quantity }).ToList();

          var productsInCart = _dbContext.Products.Where(p => productIdsInCart.Contains(p.ProductId)).ToList();*/

        /*   var productsInCart = _dbContext.CartItems
           .Where(cartItem => cartItem.ShoppingCartId == cart.ShoppingCartId)
           .Select(cartItem => cartItem.Product)
           .Select(cartItem => cartItem.cartItems)
           .ToList();*/

        /*    var cartItemsAndProductsInCart = _dbContext.CartItems
                .Where(cartItem => cartItem.ShoppingCartId == cart.ShoppingCartId)
                .Join(_dbContext.Products,
                    cartItem => cartItem.ProductId,
                    product => product.ProductId,
                    (cartItem, product) => new { CartItem = cartItem, Product = product })
                .ToList();*/

        List<CartItem> cartItems = _dbContext.CartItems.Include(product => product.Product)
                                                       .Where(cartItem => cartItem.ShoppingCartId == cart.ShoppingCartId).ToList();
        List<CartItemDto> cartItemsDto = new();
        foreach (CartItem cartItem in cartItems)
        {
           /* CartItemDto cartItemDto = CartItemModel.ToCartItemDto(cartItem);*/
            /*      if (cartItem.Product is not null)
                  {
                      ProductDto productDto = _mapper.Map<cartItem.Product, ProductDto>(cartItem.Product);
                      *//*  cartItemDto.Products.Add(_mapper.Map<cartItem.Product, ProductDto>(cartItem.Product));*//*
                  }*/
        }
        return "asd";
    }


}
