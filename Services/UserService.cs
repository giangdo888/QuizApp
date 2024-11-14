using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using QuizApp.AppDbContext;
using QuizApp.DTOs;
using QuizApp.Helper;
using QuizApp.Interfaces;
using QuizApp.Models;
using System.Security;

namespace QuizApp.Services
{
    public class UserService : IUser
    {
        public readonly QuizAppDbContext _context;
        public readonly IMapper _mapper;

        public UserService(QuizAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserDTO? SignUp(UserDTO userDTO)
        {
            if (string.IsNullOrEmpty(userDTO.Name) ||  string.IsNullOrEmpty(userDTO.Password))
            {
                return null;
            }

            userDTO.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            var newUser = _mapper.Map<Users>(userDTO);

            _context.Users.Add(newUser);
            _context.SaveChangesAsync();

            return userDTO;
        }

        public string SignIn(SignInUserDTO signInUserDTO)
        {
            var userData = getUserByName(signInUserDTO.Name);
            if (userData == null || !BCrypt.Net.BCrypt.Verify(signInUserDTO.Password, userData.Password))
            {
                return string.Empty;
            }
            return JwtTokenHelper.GenerateJwtToken(userData);
        }

        public UserDTO? getUserByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }
            var userData = _context.Users.FirstOrDefault(u => u.Name == userName);
            if (userData == null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(userData);
        }

        public List<UserDTO> getAllUsers()
        {
            return _mapper.Map<List<UserDTO>>( _context.Users);
        }
    }
}
