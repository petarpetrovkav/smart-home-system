using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.ProductRepository.Interface;
using Shop.Application.Repositories.ProductRepository.Services;
using Shop.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(IProductService productService, UserManager<ApplicationUser> userManager)
        {
            _productService = (ProductService?)productService;
            _userManager = userManager;
        }


        [HttpGet("getAll")]
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpGet("getAllProductByCategory/{id}")]
        public async Task<IEnumerable<ProductDto>> GetAllProductByCategory(int id)
        {
            return await _productService.GetAllProductByCategory(id);
        }

        [HttpGet("getProductById/{id}")]
        public async Task<ProductDto> GetById(int id)
        {
            return await _productService.Get(id);
        }
    }
}
