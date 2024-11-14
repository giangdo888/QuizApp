namespace QuizApp.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class SignInUserDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
