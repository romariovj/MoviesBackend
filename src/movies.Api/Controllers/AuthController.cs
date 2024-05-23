using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movies.Api.Models;
using movies.Application.Services;

namespace movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            
            if (login.Username == "romario" && login.Password == "password")
            {
                var token = _tokenService.GenerateToken(login.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
