namespace Infrastructure.Services{
    public class SmsService : ISmsService
{
    private readonly ILogger<SmsService> _logger;
    private readonly SmsSettings _smsSettings;

    public SmsService(IOptions<SmsSettings> smsSettings, ILogger<SmsService> logger)
    {
        _smsSettings = smsSettings.Value;
        _logger = logger;
    }

    public async Task SendSmsAsync(string phoneNumber, string message)
    {
        try
        {
            // In a real application, you would integrate with an SMS gateway like Twilio, Nexmo, etc.
            // This is a mock implementation
            _logger.LogInformation("SMS sent to {PhoneNumber}: {Message}", phoneNumber, message);
            await Task.Delay(100); // Simulate network delay
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending SMS to {PhoneNumber}", phoneNumber);
            throw;
        }
    }
}
}