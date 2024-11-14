using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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

        public async Task<UserDTO?> SignUp(UserDTO userDTO)
        {
            if (string.IsNullOrEmpty(userDTO.Name) ||  string.IsNullOrEmpty(userDTO.Password))
            {
                return null;
            }

            userDTO.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            var newUser = _mapper.Map<Users>(userDTO);

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return userDTO;
        }

        public async Task<string> SignIn(SignInUserDTO signInUserDTO)
        {
            var userData = await GetUserByName(signInUserDTO.Name);
            if (userData == null || !BCrypt.Net.BCrypt.Verify(signInUserDTO.Password, userData.Password))
            {
                return string.Empty;
            }
            return JwtTokenHelper.GenerateJwtToken(userData);
        }

        public async Task<UserDTO?> GetUserByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }
            var userData = await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);
            if (userData == null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(userData);
        }

        public async Task<List<UserDTO>> getAllUsers()
        {
            var userList = await _context.Users.ToListAsync();
            if (userList.Count == 0)
            {
                return [];
            }

            return _mapper.Map<List<UserDTO>>(userList);
        }
    }
}
