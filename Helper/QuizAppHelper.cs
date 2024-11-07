using QuizApp.DTOs;
using QuizApp.Models;

namespace QuizApp.Helper
{
    public static class QuizAppHelper
    {
        public static Questions ToQuestions(QuestionDTO questionDTO)
        {
            var question = new Questions
            {
                Text = questionDTO.Text,
                Answers = questionDTO.Answers.Select(a => new Answers
                {
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            };

            if (questionDTO.Id != null)
            {
                question.Id = questionDTO.Id.Value;
            }

            for (int i = 0; i < questionDTO.Answers.Count; i++)
            {
                if (questionDTO.Answers[i].Id != null)
                {
                    question.Answers[i].Id = questionDTO.Answers[i].Id.Value;
                }

                if (question.Id != null)
                {
                    question.Answers[i].QuestionsId = question.Id;
                }
            }

            return question;
        }

        public static QuestionDTO ToQuestionDTO(Questions question)
        {
            return new QuestionDTO
            {
                Id = question.Id,
                Text = question.Text,
                Answers = question.Answers.Select(a => new AnswerDTO
                {
                    Id = a.Id,
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            };
        }
    }
}
