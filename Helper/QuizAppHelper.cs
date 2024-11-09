using AutoMapper;
using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Helper
{
    public class AutoMappingProfille : Profile
    {
        public AutoMappingProfille()
        {
            //default all data group
            CreateMap<AnswerDTO, Answers>();
            CreateMap<Answers, AnswerDTO>();
            CreateMap<QuestionDTO, Questions>();
            CreateMap<Questions, QuestionDTO>();
            CreateMap<QuizDTO, Quizzes>();
            CreateMap<Quizzes, QuizDTO>();

            //group to play with no correct answer provided
            CreateMap<AnswerToPlayDTO, Answers>();
            CreateMap<Answers, AnswerToPlayDTO>();
            CreateMap<QuestionToPlayDTO, Questions>();
            CreateMap<Questions, QuestionToPlayDTO>();
            CreateMap<QuizToPlayDTO, Quizzes>();
            CreateMap<Quizzes, QuizToPlayDTO>();

            //group to show answer
            CreateMap<QuestionAnswersDTO, Questions>();
            CreateMap<Questions, QuestionAnswersDTO>();
            CreateMap<QuizAnswersDTO, Quizzes>();
            CreateMap<Quizzes, QuizAnswersDTO>();

            //group for simple
            CreateMap<SimpleQuizDTO, Quizzes>();
            CreateMap<Quizzes, SimpleQuizDTO>();
            CreateMap<SimpleQuestionDTO, Questions>();
            CreateMap<Questions, SimpleQuestionDTO>();
        }
    }
}
