namespace QuizApp.Models
{
    public class Records
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime AttemptedDate { get; set; } = DateTime.UtcNow;

        //foreign key
        public int QuizzesId { get; set; }
        public int UsersId { get; set; }
    }
}
