﻿using AutoMapper;
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

        public List<SimpleQuizDTO>? GetAllQuizzes()
        {
            var allQuizzes = _context.Quizzes.ToList();
            return _mapper.Map<List<SimpleQuizDTO>>(allQuizzes);
        }

        public T? GetQuizById<T>(int id) 
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);
            if (quiz == null)
            {
                return default;
            }
            var quizQuestions = _context.Questions.Where(q => q.Quizzes.Any(qu => qu.Id == id)).ToList();

            quizQuestions.ForEach(q =>
            {
                //this should already add all answers to the question, no need to add again
                var answers = _context.Answers.Where(a => a.QuestionsId == q.Id).ToList();
            });

            quiz.Questions = quizQuestions;


            var quizDTO = _mapper.Map<T>(quiz);

            return quizDTO;
        }

        public QuizAnswersDTO? GetAnswersForQuizById(int id)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);
            if (quiz == null)
            {
                return default;
            }
            var quizQuestions = _context.Questions.Where(q => q.Quizzes.Any(qu => qu.Id == id)).ToList();

            var listQuestionAnswers = new List<QuestionAnswersDTO>();
            quizQuestions.ForEach(q =>
            {
                var correctAnswer = _context.Answers.FirstOrDefault(a => a.IsCorrect == true && a.QuestionsId == q.Id);
                var questionAnswers = new QuestionAnswersDTO
                {
                    Id = q.Id,
                    CorrectAnswerId = correctAnswer.Id
                };
                listQuestionAnswers.Add(questionAnswers);
            });

            var quizAnswersDTO = _mapper.Map<QuizAnswersDTO>(quiz);
            quizAnswersDTO.Questions.AddRange(listQuestionAnswers);
            return quizAnswersDTO;
        }

        public QuizDTO? CreateQuiz(QuizDTO quizDTO)
        {
            if (quizDTO == null)
            {
                return null;
            }

            foreach (var question in quizDTO.Questions)
            {
                _questionService.CreateQuestion(question);
            }

            var quiz = _mapper.Map<Quizzes>(quizDTO);

            var newQuiz = _context.Quizzes.Add(quiz);
            _context.SaveChanges();

            return GetQuizById<QuizDTO>(newQuiz.Entity.Id);
        }

        public QuizDTO? UpdateQuiz(int id, QuizDTO quizDTO)
        {
            if (quizDTO == null)
            {
                return null;
            }

            var quiz = _context.Quizzes.FirstOrDefault(q =>  q.Id == id);
            if (quiz == null)
            {
                return null;
            }

            foreach (var question in quizDTO.Questions)
            {
                _questionService.UpdateQuestion(question.Id, question);
            }

            quiz.CreatedDate = DateTime.UtcNow;
            quiz.Name = quizDTO.Name;
            _context.SaveChanges();

            return GetQuizById<QuizDTO>(quiz.Id);
        }

        public bool DeleteQuiz(int id)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);
            if (quiz == null)
            {
                return false;
            }

            var questionsQuiz = _context.Questions.Where(q => q.Quizzes.Any(qu => qu.Id == id)).ToList();
            foreach (var question in questionsQuiz)
            {
                _questionService.DeleteQuestionById(question.Id);
            }

            _context.Quizzes.Remove(quiz);
            _context.SaveChanges();
            return true;
        }
    }
}
