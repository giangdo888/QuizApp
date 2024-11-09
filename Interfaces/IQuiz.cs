using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IQuiz
    {
        public List<SimpleQuizDTO> GetAllQuizzes();
        public T? GetQuizById<T>(int id);
        public QuizAnswersDTO? GetAnswersForQuizById(int id);
        public QuizDTO? CreateQuiz(Quizzes quiz);
        public QuizDTO? UpdateQuiz(Quizzes quiz);
        public bool DeleteQuiz(int id);
    }
}
