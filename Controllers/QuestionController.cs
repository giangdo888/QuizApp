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
        public async Task<ActionResult<List<SimpleQuestionDTO>>> GetAllQuestionsController()
        {
            var questions = await _questionService.GetAllQuestions();
            if (questions.Count == 0)
            {
                return NotFound("Question list is empty");
            }
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDTO>> GetQuestionController(int id)
        {
            var result = await _questionService.GetQuestionById(id);
            if (result == null)
            {
                return NotFound("Not found question id: " + id);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<QuestionDTO>> CreateQuestionController(QuestionDTO question)
        {
            var result = await _questionService.CreateQuestion(question);
            if (result == null)
            {
                return BadRequest("Failed to create question");
            }
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateQuestionController(int id, QuestionDTO question)
        {
            var result = await _questionService.UpdateQuestion(id, question);
            if (result == null)
            {
                return BadRequest("Failed to update question");
            }


            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteQuestionController(int id)
        {
            var result = await _questionService.DeleteQuestionById(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok("Deleted successfully");
        }
    }
}
