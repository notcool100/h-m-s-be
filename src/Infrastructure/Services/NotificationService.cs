namespace Infrastructure.Services{
    public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IEmailService _emailService;
    private readonly ISmsService _smsService;

    public NotificationService(
        INotificationRepository notificationRepository,
        IEmailService emailService,
        ISmsService smsService)
    {
        _notificationRepository = notificationRepository;
        _emailService = emailService;
        _smsService = smsService;
    }

    public async Task SendNotificationAsync(Guid userId, string title, string message, NotificationType type)
    {
        // Save notification to database
        var notification = new Notification
        {
            UserId = userId,
            Title = title,
            Message = message,
            Type = type,
            CreatedAt = DateTime.UtcNow
        };

        await _notificationRepository.AddAsync(notification);

        // For emergency notifications, also send SMS
        if (type == NotificationType.Emergency)
        {
            // In a real app, you would get the patient's phone number
            await _smsService.SendSmsAsync("+97798XXXXXXXX", message);
        }
    }

    public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(Guid userId)
    {
        return await _notificationRepository.GetByUserIdAsync(userId);
    }

    public async Task MarkNotificationAsReadAsync(Guid notificationId)
    {
        var notification = await _notificationRepository.GetByIdAsync(notificationId);
        if (notification != null)
        {
            notification.IsRead = true;
            await _notificationRepository.UpdateAsync(notification);
        }
    }
}
}