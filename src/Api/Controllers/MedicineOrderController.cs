using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Controllers
{
  [ApiController]
[Route("api/[controller]")]
[Authorize]
public class MedicineOrderController : ControllerBase
{
    private readonly IMedicineOrderService _medicineOrderService;

    public MedicineOrderController(IMedicineOrderService medicineOrderService)
    {
        _medicineOrderService = medicineOrderService;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] MedicineOrderDto orderDto)
    {
        var order = await _medicineOrderService.PlaceOrderAsync(orderDto);
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetPatientOrders(Guid patientId)
    {
        var orders = await _medicineOrderService.GetPatientOrdersAsync(patientId);
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _medicineOrderService.GetByIdAsync(id);
        return Ok(order);
    }

    [HttpGet("{id}/track")]
    public async Task<IActionResult> TrackOrder(Guid id)
    {
        var trackingInfo = await _medicineOrderService.GetOrderTrackingInfoAsync(id);
        return Ok(new { trackingInfo });
    }

    [HttpPost("{orderId}/update-status")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateOrderStatus(Guid orderId, [FromBody] OrderStatus status)
    {
        await _medicineOrderService.UpdateOrderStatusAsync(orderId, status);
        return NoContent();
    }
}
}
