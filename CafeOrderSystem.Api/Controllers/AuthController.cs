using CafeOrderSystem.Api.DTOs;
using CafeOrderSystem.Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CafeOrderSystem.Api.Controllers
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto.Username, dto.Password);
            if (token == null)
                return Unauthorized(new 
                { 
                    success = false, 
                    message = "Invalid credentials" 
                });

            return Ok(new
            {
                success = true,
                message = "Login successful",
                token
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var success = await _authService.RegisterAsync(dto.Username, dto.Password);

            if (!success)
                return BadRequest(new 
                { 
                    success = false, 
                    message = "Registration failed" 
                });

            return Ok(new 
            { 
                success = true,
                message = "Register successful"
            });
        }
    }
}
