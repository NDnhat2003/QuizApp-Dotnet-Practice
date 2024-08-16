using Microsoft.AspNetCore.Mvc;
using QuizApp.interfaces;

namespace QuizApp.Controllers
{
    [Route("api/answer")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepo;

        public AnswerController(IAnswerRepository answerRepo)
        {
            _answerRepo = answerRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var answers = await _answerRepo.GetAllAsync();
            return Ok(answers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var answer = await _answerRepo.GetByIdAsync(id);

            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

    }
}
