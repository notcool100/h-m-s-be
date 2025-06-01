using System.Collections.Generic;
using Application.Dto;
using Application.Interface;

namespace Application.Services
{
   public class MedicineOrderService : IMedicineOrderService
{
    private readonly IMedicineOrderRepository _orderRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public MedicineOrderService(
        IMedicineOrderRepository orderRepository,
        IPatientRepository patientRepository,
        INotificationService notificationService,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _patientRepository = patientRepository;
        _notificationService = notificationService;
        _mapper = mapper;
    }

    public async Task<MedicineOrder> PlaceOrderAsync(MedicineOrderDto orderDto)
    {
        var patient = await _patientRepository.GetByIdAsync(orderDto.PatientId);
        if (patient == null)
        {
            throw new Exception("Patient not found");
        }

        var order = _mapper.Map<MedicineOrder>(orderDto);
        order = await _orderRepository.AddAsync(order);

        // Send notification
        await _notificationService.SendNotificationAsync(
            orderDto.PatientId,
            "Medicine Order Placed",
            $"Your medicine order #{order.Id} has been placed successfully",
            NotificationType.MedicineOrder);

        return order;
    }

    public async Task<IEnumerable<MedicineOrder>> GetPatientOrdersAsync(Guid patientId)
    {
        return await _orderRepository.GetByPatientIdAsync(patientId);
    }

    public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        order.Status = status;
        
        if (status == OrderStatus.Shipped)
        {
            order.TrackingNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
        else if (status == OrderStatus.Delivered)
        {
            order.DeliveryDate = DateTime.UtcNow;
        }

        await _orderRepository.UpdateAsync(order);

        // Send notification
        var statusMessage = status switch
        {
            OrderStatus.Shipped => $"Your medicine order #{orderId} has been shipped. Tracking #: {order.TrackingNumber}",
            OrderStatus.Delivered => $"Your medicine order #{orderId} has been delivered",
            _ => $"Status of your medicine order #{orderId} has been updated to {status}"
        };

        await _notificationService.SendNotificationAsync(
            order.PatientId,
            $"Order #{orderId} Update",
            statusMessage,
            NotificationType.MedicineOrder);
    }

    public async Task<string> GetOrderTrackingInfoAsync(Guid orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        return order.Status switch
        {
            OrderStatus.Processing => "Your order is being processed",
            OrderStatus.Shipped => $"Your order has been shipped. Tracking number: {order.TrackingNumber}",
            OrderStatus.Delivered => $"Your order was delivered on {order.DeliveryDate?.ToShortDateString()}",
            _ => "Status information not available"
        };
    }
}
}
