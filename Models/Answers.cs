using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models
{
    public class Answers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        //foreign keys
        public int QuestionsId { get; set; }
    }
}