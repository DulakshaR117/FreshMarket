using FreshMarket.Application.DTOs.Addresses;
using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<List<AddressSummaryResponse>> GetUserAddressesAsync(Guid userId)
    {
        var addresses = await _addressRepository.GetByUserIdAsync(userId);

        return addresses.Select(x => new AddressSummaryResponse
        {
            Id = x.Id,
            AddressLine1 = x.AddressLine1,
            City = x.City,
            IsDefault = x.IsDefault
        }).ToList();
    }

    public async Task<AddressResponse> GetByIdAsync(Guid id)
    {
        var address = await _addressRepository.GetByIdAsync(id);

        if (address == null)
            throw new Exception("Address not found.");

        return MapToResponse(address);
    }

    public async Task<AddressResponse> CreateAsync(CreateAddressRequest request)
    {
        var address = new Address
        {
            UserId = request.UserId,
            AddressLine1 = request.AddressLine1,
            AddressLine2 = request.AddressLine2,
            City = request.City,
            District = request.District,
            Province = request.Province,
            PostalCode = request.PostalCode,
            IsDefault = request.IsDefault
        };

        await _addressRepository.AddAsync(address);
        await _addressRepository.SaveChangesAsync();

        return MapToResponse(address);
    }

    public async Task<AddressResponse> UpdateAsync(Guid id, UpdateAddressRequest request)
    {
        var address = await _addressRepository.GetByIdAsync(id);

        if (address == null)
            throw new Exception("Address not found.");

        address.AddressLine1 = request.AddressLine1;
        address.AddressLine2 = request.AddressLine2;
        address.City = request.City;
        address.District = request.District;
        address.Province = request.Province;
        address.PostalCode = request.PostalCode;
        address.IsDefault = request.IsDefault;

        _addressRepository.Update(address);
        await _addressRepository.SaveChangesAsync();

        return MapToResponse(address);
    }

    public async Task DeleteAsync(Guid id)
    {
        var address = await _addressRepository.GetByIdAsync(id);

        if (address == null)
            throw new Exception("Address not found.");

        _addressRepository.Delete(address);
        await _addressRepository.SaveChangesAsync();
    }

    private static AddressResponse MapToResponse(Address address)
    {
        return new AddressResponse
        {
            Id = address.Id,
            UserId = address.UserId,
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            City = address.City,
            District = address.District,
            Province = address.Province,
            PostalCode = address.PostalCode,
            IsDefault = address.IsDefault
        };
    }
}