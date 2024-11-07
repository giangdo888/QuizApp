using AutoMapper;
using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Helper
{
    public class AutoMappingProfille : Profile
    {
        public AutoMappingProfille()
        {
            CreateMap<AnswerDTO, Answers>();
            CreateMap<Answers, AnswerDTO>();
            CreateMap<QuestionDTO, Questions>();
            CreateMap<Questions, QuestionDTO>();
            CreateMap<QuizDTO, Quizzes>();
            CreateMap<Quizzes, QuizDTO>();

        }
    }
}
