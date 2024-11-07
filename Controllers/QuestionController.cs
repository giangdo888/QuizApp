using Microsoft.AspNetCore.Mvc;
using QuizApp.DTOs;
using QuizApp.Helper;
using QuizApp.Interfaces;
using QuizApp.Models;
using QuizApp.Services;

namespace QuizApp.Controllers
{
    [Route("questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public readonly IQuestion _questionService;
        public QuestionController(IQuestion questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public IActionResult GetQuestionController(int id)
        {
            var question = _questionService.GetQuestionById(id);
            if (question == null)
            {
                return Ok("Id not found");
            }

            return Ok(question);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult CreateQuestionController(QuestionDTO questionDTO)
        {
            var question = QuizAppHelper.ToQuestions(questionDTO);
            return Ok(_questionService.CreateQuestion(question));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateQuestionController(int id, QuestionDTO questionDTO)
        {
            questionDTO.Id = id;
            var question = QuizAppHelper.ToQuestions(questionDTO);

            var resultQuestion = _questionService.UpdateQuestion(question);
            if (resultQuestion == null)
            {
                return NotFound();
            }


            return Ok(resultQuestion);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult DeleteQuestionController(int id)
        {
            var result = _questionService.DeleteQuestionById(id);
            if (!result)
            {
                return Ok("Id not found");
            }

            return Ok("Delete successfully");
        }
    }
}
