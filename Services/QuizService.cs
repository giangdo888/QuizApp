using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.AppDbContext;
using QuizApp.DTOs;
using QuizApp.Helper;
using QuizApp.Interfaces;
using QuizApp.Models;
using System.Collections.Generic;

namespace QuizApp.Services
{
    public class QuizService : IQuiz
    {
        private readonly QuizAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IQuestion _questionService;

        public QuizService(QuizAppDbContext context, IMapper mapper, IQuestion questionService)
        {
            _context = context;
            _mapper = mapper;
            _questionService = questionService;
        }

        public async Task<List<SimpleQuizDTO>?> GetAllQuizzes()
        {
            var allQuizzes = await _context.Quizzes.ToListAsync();
            return _mapper.Map<List<SimpleQuizDTO>>(allQuizzes);
        }

        public async Task<T?> GetQuizById<T>(int id) 
        {
            var quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);
            if (quiz == null)
            {
                return default;
            }
            var quizQuestions = await _context.Questions.Where(q => q.Quizzes.Any(qu => qu.Id == id)).ToListAsync();

            foreach (var q in quizQuestions)
            {
                var answers = await _context.Answers.Where(a => a.QuestionsId == q.Id).ToListAsync();
            }

            quiz.Questions = quizQuestions;
            return _mapper.Map<T>(quiz);
        }

        public async Task<QuizAnswersDTO?> GetAnswersForQuizById(int id)
        {
            var quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);
            if (quiz == null)
            {
                return default;
            }
            var quizQuestions = await _context.Questions.Where(q => q.Quizzes.Any(qu => qu.Id == id)).ToListAsync();

            var listQuestionAnswers = new List<QuestionAnswersDTO>();
            foreach (var q in quizQuestions)
            {
                var correctAnswer = await _context.Answers.FirstOrDefaultAsync(a => a.IsCorrect == true && a.QuestionsId == q.Id);
                var questionAnswers = new QuestionAnswersDTO
                {
                    Id = q.Id,
                    CorrectAnswerId = correctAnswer.Id
                };
                listQuestionAnswers.Add(questionAnswers);
            };

            var quizAnswersDTO = _mapper.Map<QuizAnswersDTO>(quiz);
            quizAnswersDTO.Questions.AddRange(listQuestionAnswers);
            return quizAnswersDTO;
        }

        public async Task<QuizDTO?> CreateQuiz(QuizDTO quizDTO)
        {
            if (quizDTO == null)
            {
                return null;
            }

            foreach (var question in quizDTO.Questions)
            {
                await _questionService.CreateQuestion(question);
            }

            var quiz = _mapper.Map<Quizzes>(quizDTO);

            var newQuiz = await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();

            return await GetQuizById<QuizDTO>(newQuiz.Entity.Id);
        }

        public async Task<QuizDTO?> UpdateQuiz(int id, QuizDTO quizDTO)
        {
            if (quizDTO == null)
            {
                return null;
            }

            var quiz = await _context.Quizzes.FirstOrDefaultAsync(q =>  q.Id == id);
            if (quiz == null)
            {
                return null;
            }

            foreach (var question in quizDTO.Questions)
            {
                await _questionService.UpdateQuestion(question.Id, question);
            }

            quiz.CreatedDate = DateTime.UtcNow;
            quiz.Name = quizDTO.Name;
            await _context.SaveChangesAsync();

            return await GetQuizById<QuizDTO>(quiz.Id);
        }

        public async Task<bool> DeleteQuiz(int id)
        {
            var quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);
            if (quiz == null)
            {
                return false;
            }

            var questionsQuiz = await _context.Questions.Where(q => q.Quizzes.Any(qu => qu.Id == id)).ToListAsync();
            foreach (var question in questionsQuiz)
            {
                await _questionService.DeleteQuestionById(question.Id);
            }

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
