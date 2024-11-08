using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IQuestion
    {
        public QuestionDTO? CreateQuestion(Questions question);
        public QuestionDTO? GetQuestionById(int id);
        public QuestionDTO? UpdateQuestion(Questions question);
        public bool DeleteQuestionById(int id);
    }
}
