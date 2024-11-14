using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.AppDbContext
{
    public class QuizAppDbContext : DbContext
    {
        public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options) : base(options) { }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Quizzes> Quizzes { get; set; }
        public DbSet<Records> Records { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questions>().HasData(
                new Questions { Id = 1, Text = "What is the capital of France?" },
                new Questions { Id = 2, Text = "Which continent is known as the 'Dark Continent'?" },
                new Questions { Id = 3, Text = "What is the longest river in the world?" },
                new Questions { Id = 4, Text = "Mount Everest is located in which mountain range?" },
                new Questions { Id = 5, Text = "Which ocean is the largest by surface area?" },
                new Questions { Id = 6, Text = "What is the smallest country in the world?" },
                new Questions { Id = 7, Text = "In which country is the Great Barrier Reef located?" },
                new Questions { Id = 8, Text = "Which country has the most time zones?" },
                new Questions { Id = 9, Text = "What is the largest desert in the world?" },
                new Questions { Id = 10, Text = "The Andes mountain range is located on which continent?" }
                );

            modelBuilder.Entity<Answers>().HasData(
                new Answers { Id = 1, Text = "Paris", IsCorrect = true, QuestionsId = 1 },
                new Answers { Id = 2, Text = "Berlin", IsCorrect = false, QuestionsId = 1 },
                new Answers { Id = 3, Text = "Madrid", IsCorrect = false, QuestionsId = 1 },
                new Answers { Id = 4, Text = "Rome", IsCorrect = false, QuestionsId = 1 },

                new Answers { Id = 5, Text = "Africa", IsCorrect = true, QuestionsId = 2 },
                new Answers { Id = 6, Text = "Asia", IsCorrect = false, QuestionsId = 2 },
                new Answers { Id = 7, Text = "Europe", IsCorrect = false, QuestionsId = 2 },
                new Answers { Id = 8, Text = "South America", IsCorrect = false, QuestionsId = 2 },

                new Answers { Id = 9, Text = "Nile", IsCorrect = false, QuestionsId = 3 },
                new Answers { Id = 10, Text = "Amazon", IsCorrect = true, QuestionsId = 3 },
                new Answers { Id = 11, Text = "Yangtze", IsCorrect = false, QuestionsId = 3 },
                new Answers { Id = 12, Text = "Mississippi", IsCorrect = false, QuestionsId = 3 },

                new Answers { Id = 13, Text = "Himalayas", IsCorrect = true, QuestionsId = 4 },
                new Answers { Id = 14, Text = "Andes", IsCorrect = false, QuestionsId = 4 },
                new Answers { Id = 15, Text = "Rockies", IsCorrect = false, QuestionsId = 4 },
                new Answers { Id = 16, Text = "Alps", IsCorrect = false, QuestionsId = 4 },

                new Answers { Id = 17, Text = "Pacific", IsCorrect = true, QuestionsId = 5 },
                new Answers { Id = 18, Text = "Atlantic", IsCorrect = false, QuestionsId = 5 },
                new Answers { Id = 19, Text = "Indian", IsCorrect = false, QuestionsId = 5 },
                new Answers { Id = 20, Text = "Arctic", IsCorrect = false, QuestionsId = 5 },

                new Answers { Id = 21, Text = "Vatican City", IsCorrect = true, QuestionsId = 6 },
                new Answers { Id = 22, Text = "Monaco", IsCorrect = false, QuestionsId = 6 },
                new Answers { Id = 23, Text = "San Marino", IsCorrect = false, QuestionsId = 6 },
                new Answers { Id = 24, Text = "Liechtenstein", IsCorrect = false, QuestionsId = 6 },

                new Answers { Id = 25, Text = "Australia", IsCorrect = true, QuestionsId = 7 },
                new Answers { Id = 26, Text = "USA", IsCorrect = false, QuestionsId = 7 },
                new Answers { Id = 27, Text = "Brazil", IsCorrect = false, QuestionsId = 7 },
                new Answers { Id = 28, Text = "South Africa", IsCorrect = false, QuestionsId = 7 },

                new Answers { Id = 29, Text = "France", IsCorrect = false, QuestionsId = 8 },
                new Answers { Id = 30, Text = "Russia", IsCorrect = false, QuestionsId = 8 },
                new Answers { Id = 31, Text = "USA", IsCorrect = false, QuestionsId = 8 },
                new Answers { Id = 32, Text = "France", IsCorrect = true, QuestionsId = 8 },

                new Answers { Id = 33, Text = "Sahara", IsCorrect = true, QuestionsId = 9 },
                new Answers { Id = 34, Text = "Gobi", IsCorrect = false, QuestionsId = 9 },
                new Answers { Id = 35, Text = "Kalahari", IsCorrect = false, QuestionsId = 9 },
                new Answers { Id = 36, Text = "Arabian", IsCorrect = false, QuestionsId = 9 },

                new Answers { Id = 37, Text = "South America", IsCorrect = true, QuestionsId = 10 },
                new Answers { Id = 38, Text = "Africa", IsCorrect = false, QuestionsId = 10 },
                new Answers { Id = 39, Text = "Asia", IsCorrect = false, QuestionsId = 10 },
                new Answers { Id = 40, Text = "Europe", IsCorrect = false, QuestionsId = 10 }
                );

            modelBuilder.Entity<Quizzes>().HasData(
                new Quizzes { Id = 1, Name = "Quiz set 1" },
                new Quizzes { Id = 2, Name = "Quiz set 2" }
                );

            modelBuilder.Entity<Questions>().HasMany(question => question.Quizzes).WithMany(quiz => quiz.Questions).UsingEntity(qq => qq.HasData(
                new { QuestionsId = 1, QuizzesId = 1 },
                new { QuestionsId = 2, QuizzesId = 1 },
                new { QuestionsId = 3, QuizzesId = 1 },
                new { QuestionsId = 4, QuizzesId = 1 },
                new { QuestionsId = 5, QuizzesId = 1 },
                new { QuestionsId = 6, QuizzesId = 2 },
                new { QuestionsId = 7, QuizzesId = 2 },
                new { QuestionsId = 8, QuizzesId = 2 },
                new { QuestionsId = 9, QuizzesId = 2 },
                new { QuestionsId = 10, QuizzesId = 2 }
                ));
        }
    }
}
