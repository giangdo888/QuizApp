using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models
{
    public class Questions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        //navigation properties
        public List<Answers> Answers { get; set; }
        public List<Quizzes> Quizzes { get; set; }
    }
}
