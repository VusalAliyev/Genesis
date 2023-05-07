using Genesis.Application.Dtos;
using Genesis.Infrastructure.Dto;
using Genesis.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        [HttpPost("getOtp")]
        public IActionResult GetOtp(OTPConfirmation confirmation)
        {
            Random generator = new Random();
            string otp = generator.Next(0, 1000000).ToString("D4");
            string otpContent = $"<h1>OTP: {otp}</h1>";
            EmailService.SendEmail(confirmation.Email, otpContent);
            Response.Cookies.Append($"{confirmation.FinCode}", otp);

            return Ok(TResponse<string>.Success(200));
        }

        [HttpPost("confirmOtp")]
        public IActionResult ConfirmOtp(string otp, string finCode)
        {

            string otpCode = Request.Cookies[$"{finCode}"];

            if (otpCode == null)
            {
                return Ok(TResponse<string>.Fail("Finkoda aid kod tapılmadı.", 404));
            }

            if (otp == otpCode)
            {
                return Ok(TResponse<string>.Success(200));
            }
            else
            {
                return Ok(TResponse<string>.Fail("Kod düzgün deyil.", 400));
            }
        }
    }
}
