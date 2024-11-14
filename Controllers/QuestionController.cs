using AutoMapper;
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

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllQuestionsController()
        {
            var questions = _questionService.GetAllQuestions();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetQuestionController(int id)
        {
            var result = _questionService.GetQuestionById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateQuestionController(QuestionDTO question)
        {
            var result = _questionService.CreateQuestion(question);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateQuestionController(int id, QuestionDTO question)
        {
            

            var result = _questionService.UpdateQuestion(id, question);
            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteQuestionController(int id)
        {
            var result = _questionService.DeleteQuestionById(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok("Delete successfully");
        }
    }
}
