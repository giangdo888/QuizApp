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

        [HttpPost]

        public IActionResult SignUp(UserDTO userDTO)
        {
            var result = _userService.SignUp(userDTO);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
