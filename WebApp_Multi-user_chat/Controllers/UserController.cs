using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp_Multi_user_chat.Dto;
using WebApp_Multi_user_chat.Entities;
using WebApp_Multi_user_chat.Interfaces;
using WebApp_Multi_user_chat.Models;

namespace WebApp_Multi_user_chat.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserRequest user)
        {
            return Ok(await _userService.LoginAsync(user));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest user)
        {
            if(!await _userService.RegisterUser(user))
            {
                return BadRequest(new ErrorLog("This user already exist"));
            }

            return Ok(true);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }
    }
}
