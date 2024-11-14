using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IQuestion
    {
        public Task<List<SimpleQuestionDTO>> GetAllQuestions();
        public Task<QuestionDTO?> GetQuestionById(int id);
        public Task<QuestionDTO?> CreateQuestion(QuestionDTO question);
        public Task<QuestionDTO?> UpdateQuestion(int id, QuestionDTO question);
        public Task<bool> DeleteQuestionById(int id);
    }
}
