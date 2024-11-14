using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IQuiz
    {
        public List<SimpleQuizDTO>? GetAllQuizzes();
        public T? GetQuizById<T>(int id);
        public QuizAnswersDTO? GetAnswersForQuizById(int id);
        public QuizDTO? CreateQuiz(QuizDTO quizDTO);
        public QuizDTO? UpdateQuiz(int id, QuizDTO quizDTO);
        public bool DeleteQuiz(int id);
    }
}
