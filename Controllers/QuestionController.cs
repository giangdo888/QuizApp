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
        public readonly IMapper _mapper;
        public QuestionController(IQuestion questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetQuestionController(int id)
        {
            var question = _questionService.GetQuestionById(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateQuestionController(QuestionDTO questionDTO)
        {
            if (questionDTO == null)
            {
                return NotFound();
            }
            var question = _mapper.Map<Questions>(questionDTO);
            return Ok(_questionService.CreateQuestion(question));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateQuestionController(int id, QuestionDTO questionDTO)
        {
            if (questionDTO == null)
            {
                return NotFound();
            }
            questionDTO.Id = id;
            var question = _mapper.Map<Questions>(questionDTO);
            foreach(var answer in question.Answers)
            {
                answer.QuestionsId = question.Id;
            }

            var resultQuestion = _questionService.UpdateQuestion(question);
            if (resultQuestion == null)
            {
                return NotFound();
            }


            return Ok(resultQuestion);
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
