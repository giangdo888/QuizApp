﻿namespace QuizApp.DTOs
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class AnswerToPlayDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}