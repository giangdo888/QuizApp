using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizApp.DTOs;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public enum ToBeReturnedQuizzesType
    {
        All,
        NoAnswers,
        WithAnswers,
        Unknown
    }

    [Route("quizzes")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuiz _quizService;

        public QuizController(IQuiz quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllQuizzesController()
        {
            var allQuizzes = _quizService.GetAllQuizzes();
            return Ok(allQuizzes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetQuizController(int id, [FromQuery] string? type = null)
        {
            var getQuizzesType = string.IsNullOrEmpty(type)
                                ? ToBeReturnedQuizzesType.All
                                : Enum.TryParse(type, true, out ToBeReturnedQuizzesType parsedType)
                                ? parsedType
                                : ToBeReturnedQuizzesType.Unknown;

            object? quiz;
            switch(getQuizzesType)
            {
                case ToBeReturnedQuizzesType.All:
                    quiz = _quizService.GetQuizById<QuizDTO>(id);
                    break;
                case ToBeReturnedQuizzesType.NoAnswers:
                    quiz = _quizService.GetQuizById<QuizToPlayDTO>(id);
                    break;
                case ToBeReturnedQuizzesType.WithAnswers:
                    quiz = _quizService.GetAnswersForQuizById(id);
                    break;
                default:
                    return BadRequest("Invalid quiz type specified");
            }

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateQuizController(QuizDTO quiz)
        {
            var result = _quizService.CreateQuiz(quiz);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateQuizController(int id, QuizDTO quizDTO)
        {
            var result = _quizService?.UpdateQuiz(id, quizDTO);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteQuizController(int id)
        {
            var result = _quizService.DeleteQuiz(id);
            if(!result)
            {
                return NotFound();
            }

            return Ok("Delete successfully");
        }
    }
}
