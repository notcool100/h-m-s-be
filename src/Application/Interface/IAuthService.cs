using System.Collections.Generic;
using Application.Dto;

namespace Application.Interface
{
   public interface IAuthService
{
    Task<string> GenerateOTPAsync(string phoneNumber);
    Task<string> VerifyOTPAsync(LoginRequestDto loginRequest);
}

}
