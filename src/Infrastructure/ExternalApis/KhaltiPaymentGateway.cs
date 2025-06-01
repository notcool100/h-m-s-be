
namespace Infrastructure.ExternalApis{
    public class KhaltiPaymentGateway : IPaymentGateway
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public KhaltiPaymentGateway(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient;
        _apiKey = apiKey;
    }

    public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request)
    {
        // Implement Khalti payment processing
        // This is a simplified example
        var paymentRequest = new
        {
            token = request.Token,
            amount = request.Amount,
            mobile = request.MobileNumber
        };

        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Key {_apiKey}");
        var response = await _httpClient.PostAsJsonAsync("https://khalti.com/api/v2/payment/verify/", paymentRequest);

        if (response.IsSuccessStatusCode)
        {
            return new PaymentResponse
            {
                Success = true,
                TransactionId = Guid.NewGuid().ToString(),
                Message = "Payment successful"
            };
        }

        return new PaymentResponse
        {
            Success = false,
            Message = "Payment failed"
        };
    }
}
}