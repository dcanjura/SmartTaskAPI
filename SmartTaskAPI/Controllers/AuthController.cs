using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTaskAPI.DTOs;
using SmartTaskAPI.Services;
using System.Security.Claims;

namespace SmartTaskAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var result = await _service.RegisterAsync(
                dto.FullName,
                dto.Email,
                dto.Password
            );

            if (result == null)
                return BadRequest("User already exists");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _service.LoginAsync(
                dto.Email,
                dto.Password
            );

            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { token });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            var token = await _service.RefreshTokenAsync(refreshToken);

            if (token == null)
                return Unauthorized("Invalid refresh token");

            return Ok(new { token });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string refreshToken)
        {
            var result = await _service.RevokeTokenAsync(refreshToken);

            if (!result)
                return BadRequest("Invalid token");

            return Ok("Logout successful");
        }
    }
}