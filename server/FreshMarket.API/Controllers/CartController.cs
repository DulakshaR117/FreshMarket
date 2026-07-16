using FreshMarket.Application.DTOs.Cart;
using FreshMarket.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreshMarket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetCart(Guid userId)
    {
        var cart = await _cartService.GetCartAsync(userId);
        return Ok(cart);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddToCart(AddToCartRequest request)
    {
        try
        {
            var result = await _cartService.AddToCartAsync(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("items/{cartItemId:guid}")]
    public async Task<IActionResult> UpdateCartItem(Guid cartItemId, UpdateCartItemRequest request)
    {
        try
        {
            var result = await _cartService.UpdateCartItemAsync(cartItemId, request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("items/{cartItemId:guid}")]
    public async Task<IActionResult> RemoveItem(Guid cartItemId)
    {
        try
        {
            await _cartService.RemoveItemAsync(cartItemId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{userId:guid}/clear")]
    public async Task<IActionResult> ClearCart(Guid userId)
    {
        await _cartService.ClearCartAsync(userId);
        return NoContent();
    }
}