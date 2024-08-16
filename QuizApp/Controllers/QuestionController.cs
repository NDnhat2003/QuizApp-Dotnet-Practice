using Microsoft.AspNetCore.Mvc;
using QuizApp.Dtos.Question;
using QuizApp.interfaces;
using QuizApp.Mappers;

namespace QuizApp.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IAnswerRepository _answerRepo;

        public QuestionController(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var questions = await _questionRepo.GetAllAsync();

            var questionsDto = questions.Select(q => q.ToQuestionDto()).ToList();
            
            return Ok(questionsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var question = await _questionRepo.GetByIdAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        [HttpPost("{answerId}")]
        public async Task<ActionResult> Create([FromRoute] Guid answerId, [FromBody] QuestionRequestDto questionDto)
        {
            if (!await _answerRepo.Exist(answerId))
            {
                return BadRequest("Answer does not exist");
            }

            var questionModel = questionDto.ToQuestionFromDto(answerId);
            await _questionRepo.CreateAsync(questionModel);
            return CreatedAtAction(nameof(GetById), new {id = questionModel}, questionModel.ToQuestionDto());
        }
    }
}
