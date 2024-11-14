using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using QuizApp.AppDbContext;
using QuizApp.DTOs;
using QuizApp.Helper;
using QuizApp.Interfaces;
using QuizApp.Models;

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
    }
}
