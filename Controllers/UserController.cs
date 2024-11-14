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

        public IActionResult SignUp(UserDTO userDTO)
        {
            var result = _userService.SignUp(userDTO);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult SignIn(SignInUserDTO signInData)
        {
            var token = _userService.SignIn(signInData);
            if (token == null)
            {
                return NotFound();
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllUsersController()
        {
            return Ok(_userService.getAllUsers());
        }
    }
}
