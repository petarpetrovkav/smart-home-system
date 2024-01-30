using Shop.Application.Common.Models;

namespace Shop.Application.Repositories.AddressRepository.Interface;

public interface IAddressService
{
    Task<List<AddressDto>> GetAllByUserId(string userId);
}
