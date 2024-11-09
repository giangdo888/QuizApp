using AutoMapper;
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
        public readonly IMapper _mapper;
        public QuestionService(QuizAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<QuestionDTO>? GetAllQuestions()
        {
            var questions = _context.Questions.ToList();
            foreach(var question in questions)
            {
                var answers = _context.Answers.Where(a =>  a.QuestionsId == question.Id).ToList();
                question.Answers = answers;
            }

            return _mapper.Map<List<QuestionDTO>>(questions);
        }

        public QuestionDTO? GetQuestionById(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (question == null) {
                return null;
            }

            var answers = _context.Answers.Where(a => a.QuestionsId == id).ToList();
            question.Answers = answers;

            var QuestionDTO = _mapper.Map<QuestionDTO>(question);

            return QuestionDTO;
        }

        public QuestionDTO? CreateQuestion(Questions question)
        {
            foreach (var answer in question.Answers)
            {
                _context.Answers.Add(answer);
            }

            var newQuestion = _context.Questions.Add(question);
            _context.SaveChanges();

            return GetQuestionById(newQuestion.Entity.Id);
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
