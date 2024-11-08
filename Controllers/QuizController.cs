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
        private readonly IMapper _mapper;
        private readonly IQuestion _questionService;

        public QuizController(IQuiz quizService, IMapper mapper, IQuestion questionService)
        {
            _quizService = quizService;
            _mapper = mapper;
            _questionService = questionService;
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

            object quiz;
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
        public IActionResult CreateQuizController(QuizDTO quizDTO)
        {
            if (quizDTO == null)
            {
                return NotFound();
            }

            //var questions = _mapper.Map<List<Questions>>(quizDTO.Questions);
            var quiz = _mapper.Map<Quizzes>(quizDTO);

            return Ok(_quizService.CreateQuiz(quiz));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateQuizController(int id, QuizDTO quizDTO)
        {
            if (quizDTO == null)
            {
                return NotFound();
            }

            quizDTO.Id = id;
            var quiz = _mapper.Map<Quizzes>(quizDTO);
            foreach(var question in quiz.Questions)
            {
                foreach(var answer in question.Answers)
                {
                    answer.QuestionsId = question.Id;
                }
            }

            return Ok(_quizService?.UpdateQuiz(quiz));
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
