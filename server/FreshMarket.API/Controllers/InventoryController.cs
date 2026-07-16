using FreshMarket.Application.DTOs.Inventory;
using FreshMarket.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreshMarket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _inventoryService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _inventoryService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInventoryRequest request)
    {
        return Ok(await _inventoryService.CreateAsync(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateInventoryRequest request)
    {
        return Ok(await _inventoryService.UpdateAsync(id, request));
    }

    [HttpPut("{id:guid}/increase")]
    public async Task<IActionResult> Increase(Guid id, StockAdjustmentRequest request)
    {
        return Ok(await _inventoryService.IncreaseStockAsync(id, request));
    }

    [HttpPut("{id:guid}/decrease")]
    public async Task<IActionResult> Decrease(Guid id, StockAdjustmentRequest request)
    {
        return Ok(await _inventoryService.DecreaseStockAsync(id, request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _inventoryService.DeleteAsync(id);
        return NoContent();
    }
}