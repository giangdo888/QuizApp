using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IQuestion
    {
        public List<SimpleQuestionDTO>? GetAllQuestions();
        public QuestionDTO? GetQuestionById(int id);
        public QuestionDTO? CreateQuestion(QuestionDTO question);
        public QuestionDTO? UpdateQuestion(int id, QuestionDTO question);
        public bool DeleteQuestionById(int id);
    }
}
