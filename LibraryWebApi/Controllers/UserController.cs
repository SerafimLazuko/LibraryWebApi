using Library.BLL.DTO;
using Library.BLL.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController()]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [Authorize]
        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                return Ok(await userService.GetAllUsersAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUserAsync(UserToRegisterDTO userToRegisterDTO)
        {
            try
            {
                return Ok(await userService.RegisterUserAsync(userToRegisterDTO));
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUserAsync(UserToLoginDTO userToLoginDTO)
        {
            try
            {
                return Ok(await userService.LoginUserAsync(userToLoginDTO));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
