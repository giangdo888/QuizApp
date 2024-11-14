using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IQuiz
    {
        public Task<List<SimpleQuizDTO>?> GetAllQuizzes();
        public Task<T?> GetQuizById<T>(int id);
        public Task<QuizAnswersDTO?> GetAnswersForQuizById(int id);
        public Task<QuizDTO?> CreateQuiz(QuizDTO quizDTO);
        public Task<QuizDTO?> UpdateQuiz(int id, QuizDTO quizDTO);
        public Task<bool> DeleteQuiz(int id);
    }
}
