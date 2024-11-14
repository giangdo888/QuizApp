using QuizApp.DTOs;

namespace QuizApp.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO?> SignUp(UserDTO userDTO);
        public Task<string> SignIn(SignInUserDTO signInUserDTO);
        public Task<UserDTO?> GetUserByName(string userName);
        public Task<List<UserDTO>> getAllUsers();
        //public int? GetMaxScore(int userId);
    }
}
