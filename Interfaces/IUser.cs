using QuizApp.DTOs;

namespace QuizApp.Interfaces
{
    public interface IUser
    {
        public UserDTO? SignUp(UserDTO userDTO);
        //public string SignIn(SignInUserDTO signInUserDTO);
        //public int? GetMaxScore(int userId);
    }
}
