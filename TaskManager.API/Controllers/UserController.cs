using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.ServiceInterfaces;
using TaskManager.Contracts;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private ILogger<UserController> _logger;
        private readonly IUserService userService;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {

            this.userService = userService;
            _logger = logger;
        }
        [HttpPost("register")]
        public async Task<IActionResult>Register(RegisterRequest request)
        {
            var existUser = await userService.RegisterAsync(request);
            if (!existUser)
            {
                return BadRequest("Пользователь с таким email уже существует");
            }
            return Ok("Регистрация успешна");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await userService.LoginAsync(request);
                if (token == null)
                {
                    return Unauthorized("Неверный email или пароль");
                }
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                return StatusCode(500, "Internal server error");
            }
        }
        
    }
}
