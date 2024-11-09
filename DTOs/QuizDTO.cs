namespace QuizApp.DTOs
{
    public class QuizDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<QuestionDTO> Questions { get; set; }
    }

    public class QuizToPlayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionToPlayDTO> Questions { get; set; }
    }

    public class QuizAnswersDTO
    {
        public int Id { get; set; }
        public List<QuestionAnswersDTO> Questions { get; set; }
    }

    public class SimpleQuizDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
