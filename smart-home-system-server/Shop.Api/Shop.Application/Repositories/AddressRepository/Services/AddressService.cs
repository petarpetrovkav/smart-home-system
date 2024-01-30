using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.AddressRepository.Interface;
using Shop.Entities;

namespace Shop.Application.Repositories.AddressRepository.Services;

public class AddressService : IAddressService
{
    private readonly IShopDbContext _dbContext;
    private readonly IMapper _mapper;

    public AddressService(IShopDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    // TODO: Da se dopravi za daden user da gi iscita site adresi.  
    public async Task<List<AddressDto>> GetAllByUserId(string userId)
    {
        List<Address> dbAddresses = await _dbContext.UserAddresses.Where(x => x.UserId == userId).ToListAsync();
        List<AddressDto> addressDtos = new();

        foreach (Address item in dbAddresses)
        {
            AddressDto addressDto = _mapper.Map<Address, AddressDto>(item);
            addressDtos.Add(addressDto);
        }

        return addressDtos;
    }

    // TODO: Da se dopravi da moze da dodava andresa i da izbrise adresa
}
