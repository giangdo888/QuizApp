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

        public List<SimpleQuestionDTO>? GetAllQuestions()
        {
            var questions = _context.Questions.ToList();
            return _mapper.Map<List<SimpleQuestionDTO>>(questions);
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

        public QuestionDTO? CreateQuestion(QuestionDTO questionDTO)
        {
            if (questionDTO == null)
            {
                return null;
            }
            var question = _mapper.Map<Questions>(questionDTO);
            foreach (var answer in question.Answers)
            {
                _context.Answers.Add(answer);
            }

            var newQuestion = _context.Questions.Add(question);
            _context.SaveChanges();

            return GetQuestionById(newQuestion.Entity.Id);
        }

        public QuestionDTO? UpdateQuestion(int id, QuestionDTO questionDTO)
        {
            if (questionDTO == null)
            {
                return null;
            }
            questionDTO.Id = id;
            var question = _mapper.Map<Questions>(questionDTO);
            foreach (var answer in question.Answers)
            {
                answer.QuestionsId = question.Id;
            }

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
