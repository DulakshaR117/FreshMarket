using FreshMarket.Application.DTOs.Orders;
using FreshMarket.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreshMarket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout(CreateOrderRequest request)
    {
        return Ok(await _orderService.CheckoutAsync(request));
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetUserOrders(Guid userId)
    {
        return Ok(await _orderService.GetUserOrdersAsync(userId));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        return Ok(await _orderService.GetOrderByIdAsync(id));
    }

    [HttpPut("{id:guid}/status")]
    public async Task<IActionResult> UpdateStatus(
        Guid id,
        UpdateOrderStatusRequest request)
    {
        return Ok(await _orderService.UpdateOrderStatusAsync(id, request));
    }
}