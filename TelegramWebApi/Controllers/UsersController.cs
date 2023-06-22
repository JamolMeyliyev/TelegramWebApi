using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelegramWebApi.Entities;
using TelegramWebApi.Managers;
using TelegramWebApi.Models;

namespace TelegramWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager _userManager;
        public UsersController(UserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userManager.GetUsers());
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserModel model)
        {
            return Ok(await _userManager.AddUser(model));
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model)
        {
            return Ok( await _userManager.Login(model));
        }
             
    }
}
