namespace QuizApp.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }
    public class QuestionToPlayDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<AnswerToPlayDTO> Answers { get; set; }
    }

    public class QuestionAnswersDTO
    {
        public int Id { get; set; }
        public int CorrectAnswerId { get; set; }
    }

    public class SimpleQuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
