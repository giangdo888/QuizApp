using Microsoft.EntityFrameworkCore;
using QuizApp.AppDbContext;
using QuizApp.DTOs;
using QuizApp.Helper;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp.Services
{
    public class QuestionService : IQuestion
    {
        public readonly QuizAppDbContext _context;
        public QuestionService(QuizAppDbContext context)
        {
            _context = context;
        }

        public QuestionDTO CreateQuestion(Questions question)
        {
            foreach (var answer in question.Answers)
            {
                _context.Answers.Add(answer);
            }

            var newQuestion = _context.Questions.Add(question);
            _context.SaveChanges();

            return GetQuestionById(newQuestion.Entity.Id);
        }

        public QuestionDTO GetQuestionById(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (question == null) {
                return null;
            }

            var answers = _context.Answers.Where(a => a.QuestionsId == id).ToList();
            question.Answers = answers;

            var QuestionDTO = QuizAppHelper.ToQuestionDTO(question);

            return QuestionDTO;
        }

        public List<QuestionDTO> GetQuestionsByQuizId(int quizId)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == quizId);
            if (quiz == null) 
            { 
                return null;
            }

            var quizQuestions = _context.Questions.Where(q => q.Quizzes.Any(quiz => quiz.Id == quizId)).ToList();

            var quizQuestionsDTO = new List<QuestionDTO>();
            foreach (var question in quizQuestions)
            {
                var answers = question.Answers.ToList();
                var questionDTO = QuizAppHelper.ToQuestionDTO(question);

                quizQuestionsDTO.Add(questionDTO);
            }

            return quizQuestionsDTO;
        }

        public QuestionDTO? UpdateQuestion(Questions question)
        {
            var contextQuestion  = _context.Questions.FirstOrDefault(q => q.Id == question.Id);
            if (contextQuestion == null)
            {
                return null;
            }
            contextQuestion.Text = question.Text;

            var contextAnswers = _context.Answers.Where(a => a.QuestionsId == question.Id).ToList();
            _context.Answers.RemoveRange(contextAnswers);
            foreach(var answer in question.Answers)
            {
                _context.Answers.Add(answer);
            }

            _context.SaveChanges();
            return GetQuestionById(contextQuestion.Id);
        }

        public bool DeleteQuestionById(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (question == null)
            {
                return false;
            }

            var answers = _context.Answers.Where(a => a.QuestionsId == id).ToList();
            foreach(var answer in answers)
            {
                _context.Answers.Remove(answer);
            }

            _context.Questions.Remove(question);
            _context.SaveChanges();
            return true;
        }
    }
}
