using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartTaskAPI.Services;

namespace SmartTaskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            var result = _service.Register();
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            var result = _service.Login();
            return Ok(result);
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken()
        {
            var result = _service.RefreshToken();
            return Ok(result);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            _service.Logout();
            return Ok("Logout successful");
        }
    }
}
