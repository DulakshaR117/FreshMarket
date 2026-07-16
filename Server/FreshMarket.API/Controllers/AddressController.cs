using FreshMarket.Application.DTOs.Addresses;
using FreshMarket.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreshMarket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetUserAddresses(Guid userId)
    {
        return Ok(await _addressService.GetUserAddressesAsync(userId));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _addressService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAddressRequest request)
    {
        return Ok(await _addressService.CreateAsync(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateAddressRequest request)
    {
        return Ok(await _addressService.UpdateAsync(id, request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _addressService.DeleteAsync(id);
        return NoContent();
    }
}