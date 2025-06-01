using System.Collections.Generic;
using Application.Dto;

namespace Application.Interface
{
public interface INotificationService
{
    Task SendNotificationAsync(Guid userId, string title, string message, NotificationType type);
    Task<IEnumerable<Notification>> GetUserNotificationsAsync(Guid userId);
    Task MarkNotificationAsReadAsync(Guid notificationId);
}
}
