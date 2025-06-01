using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Controllers
{
 [ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("otp")]
    public async Task<IActionResult> GenerateOTP([FromBody] string phoneNumber)
    {
        // In a real app, you would validate the phone number format
        var otp = await _authService.GenerateOTPAsync(phoneNumber);
        return Ok(new { message = "OTP sent successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        var token = await _authService.VerifyOTPAsync(loginRequest);
        return Ok(new { token });
    }
}

}
