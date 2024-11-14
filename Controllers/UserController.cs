using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.DTOs;
using QuizApp.Interfaces;       

namespace QuizApp.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : Controller
    {
        public readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]

        public async Task<ActionResult<UserDTO>> SignUp(UserDTO userDTO)
        {
            var result = await _userService.SignUp(userDTO);
            if (result == null)
            {
                return BadRequest("Failed to register user");
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> SignIn(SignInUserDTO signInData)
        {
            var token = await _userService.SignIn(signInData);
            if (token == null)
            {
                return BadRequest("Invalid credentials");
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsersController()
        {
            var userList = await _userService.getAllUsers();
            if (userList.Count == 0)
            {
                return NotFound();
            }
            return Ok(userList);
        }
    }
}
