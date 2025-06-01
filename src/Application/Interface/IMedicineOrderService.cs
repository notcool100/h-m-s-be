using System.Collections.Generic;
using Application.Dto;

namespace Application.Interface{
    public interface IMedicineOrderService
    {
        Task<MedicineOrder> PlaceOrderAsync(MedicineOrderDto orderDto);
    Task<IEnumerable<MedicineOrder>> GetPatientOrdersAsync(Guid patientId);
    Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
    Task<string> GetOrderTrackingInfoAsync(Guid orderId);
    }
}