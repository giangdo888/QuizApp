using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IQuestion
    {
        public List<SimpleQuestionDTO>? GetAllQuestions();
        public QuestionDTO? GetQuestionById(int id);
        public QuestionDTO? CreateQuestion(Questions question);
        public QuestionDTO? UpdateQuestion(Questions question);
        public bool DeleteQuestionById(int id);
    }
}
