using FreshMarket.Application.DTOs.Addresses;

namespace FreshMarket.Application.Interfaces;

public interface IAddressService
{
    Task<List<AddressSummaryResponse>> GetUserAddressesAsync(Guid userId);

    Task<AddressResponse> GetByIdAsync(Guid id);

    Task<AddressResponse> CreateAsync(CreateAddressRequest request);

    Task<AddressResponse> UpdateAsync(Guid id, UpdateAddressRequest request);

    Task DeleteAsync(Guid id);
}