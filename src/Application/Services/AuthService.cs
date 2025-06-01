using System.Collections.Generic;
using Application.Dto;
using Application.Interface;

namespace Application.Services
{
  public class AuthService : IAuthService
{
    private readonly IPatientRepository _patientRepository;
    private readonly ISmsService _smsService;
    private readonly ITokenService _tokenService;

    public AuthService(
        IPatientRepository patientRepository,
        ISmsService smsService,
        ITokenService tokenService)
    {
        _patientRepository = patientRepository;
        _smsService = smsService;
        _tokenService = tokenService;
    }

    public async Task<string> GenerateOTPAsync(string phoneNumber)
    {
        // Generate a 6-digit OTP
        var otp = new Random().Next(100000, 999999).ToString();
        
        // In a real application, you would store this OTP with an expiration time
        // and verify it later
        
        // Send OTP via SMS
        await _smsService.SendSmsAsync(phoneNumber, $"Your Health Bridge OTP is: {otp}");
        
        return otp;
    }

    public async Task<string> VerifyOTPAsync(LoginRequestDto loginRequest)
    {
        // In a real application, you would verify the OTP against what was stored
        // For this example, we'll assume it's always correct
        
        // Check if patient exists
        var patient = await _patientRepository.GetByPhoneNumberAsync(loginRequest.PhoneNumber);
        if (patient == null)
        {
            // Create new patient if not exists
            patient = new Patient
            {
                PhoneNumber = loginRequest.PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };
            patient = await _patientRepository.AddAsync(patient);
        }

        // Generate JWT token
        return _tokenService.GenerateToken(patient.Id.ToString(), patient.PhoneNumber);
    }
}
}
