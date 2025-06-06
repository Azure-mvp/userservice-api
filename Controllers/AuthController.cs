using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] LoginRequest request)
        {
            if (request.Username == "test" && request.Password == "1234")
            {
                return Ok(new User
                {
                    Username = request.Username,
                    Token = "mocked-jwt-token-1234"
                });
            }

            return Unauthorized();
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
