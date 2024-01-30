using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.AddressRepository.Interface;
using Shop.Application.Repositories.AddressRepository.Services;
using Shop.Entities;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /*
             // TODO: Da se dopravi da moze da dodava andresa i da izbrise adresa
         */

        private readonly AddressService _addressService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddressController(IAddressService addressService, UserManager<ApplicationUser> userManager)
        {
            _addressService = (AddressService?)addressService;
            _userManager = userManager;
        }



        [HttpGet("getAllByUserId")]
        public async Task<IEnumerable<AddressDto>> GetAllByUserId()
        {
            // ApplicationUser user = await _userManager.FindByNameAsync(User.Claims?.FirstOrDefault()?.Value);

            return await _addressService.GetAllByUserId("9c860138-12e2-4110-9855-c0fb9df53041");
        }
    }
}
