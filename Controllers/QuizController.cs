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
        public async Task<ActionResult<List<SimpleQuizDTO>>> GetAllQuizzesController()
        {
            var allQuizzes = await _quizService.GetAllQuizzes();
            return Ok(allQuizzes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetQuizController(int id, [FromQuery] string? type = null)
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
                    quiz = await _quizService.GetQuizById<QuizDTO>(id);
                    break;
                case ToBeReturnedQuizzesType.NoAnswers:
                    quiz = await _quizService.GetQuizById<QuizToPlayDTO>(id);
                    break;
                case ToBeReturnedQuizzesType.WithAnswers:
                    quiz = await _quizService.GetAnswersForQuizById(id);
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
        public async Task<ActionResult<QuizDTO>> CreateQuizController(QuizDTO quiz)
        {
            var result = await _quizService.CreateQuiz(quiz);
            if (result == null)
            {
                return BadRequest("Failed to create quiz");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QuizDTO>> UpdateQuizController(int id, QuizDTO quizDTO)
        {
            var result = await _quizService.UpdateQuiz(id, quizDTO);
            if (result == null)
            {
                return BadRequest("Failed to update quiz");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteQuizController(int id)
        {
            var result = await _quizService.DeleteQuiz(id);
            if(!result)
            {
                return NotFound();
            }

            return Ok("Deleted successfully");
        }
    }
}
