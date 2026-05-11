using Microsoft.AspNetCore.Mvc;
using SmartTaskAPI.DTOs;
using SmartTaskAPI.Services;

namespace SmartTaskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _service.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _service.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO userDto)
        {
            var user = _service.CreateUser(userDto);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO userDto)
        {
            var user = _service.UpdateUser(id, userDto);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _service.DeleteUser(id);
            return Ok();
        }
    }
}
