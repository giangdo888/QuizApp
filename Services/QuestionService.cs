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

        public async Task<List<SimpleQuestionDTO>> GetAllQuestions()
        {
            var questions = await _context.Questions.ToListAsync();
            if (questions.Count == 0)
            {
                return [];
            }
            return _mapper.Map<List<SimpleQuestionDTO>>(questions);
        }

        public async Task<QuestionDTO?> GetQuestionById(int id)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == id);
            if (question == null) {
                return null;
            }

            var answers = await _context.Answers.Where(a => a.QuestionsId == id).ToListAsync();
            question.Answers = answers;

            return _mapper.Map<QuestionDTO>(question);
        }

        public async Task<QuestionDTO?> CreateQuestion(QuestionDTO questionDTO)
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

            return await GetQuestionById(newQuestion.Entity.Id);
        }

        public async Task<QuestionDTO?> UpdateQuestion(int id, QuestionDTO questionDTO)
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

            var contextQuestion  = await _context.Questions.FirstOrDefaultAsync(q => q.Id == question.Id);
            if (contextQuestion == null)
            {
                return null;
            }
            contextQuestion.Text = question.Text;

            var contextAnswers = await _context.Answers.Where(a => a.QuestionsId == question.Id).ToListAsync();
            _context.Answers.RemoveRange(contextAnswers);
            foreach(var answer in question.Answers)
            {
                await _context.Answers.AddAsync(answer);
            }

            await _context.SaveChangesAsync();
            return await GetQuestionById(contextQuestion.Id);
        }

        public async Task<bool> DeleteQuestionById(int id)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == id);
            if (question == null)
            {
                return false;
            }

            var answers = await _context.Answers.Where(a => a.QuestionsId == id).ToListAsync();
            foreach(var answer in answers)
            {
                _context.Answers.Remove(answer);
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
