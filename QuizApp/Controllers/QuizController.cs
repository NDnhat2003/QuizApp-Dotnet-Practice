using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Dtos.Quiz;
using QuizApp.interfaces;
using QuizApp.Mappers;

namespace QuizApp.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepo;

        public QuizController(IQuizRepository quizRepo)
        {
            _quizRepo = quizRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            var quizzes = await _quizRepo.GetAllAsync();
            var quizzesDto = quizzes.Select(q => q.ToQuizDto());

            return Ok(quizzesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            var quiz = await _quizRepo.GetByIdAsync(id);

            return Ok(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuizRequestDto quizDto)
        {
            var quiz = await _quizRepo.CreateAsync(quizDto.ToQuizFromDTO());

            return CreatedAtAction(nameof(GetById), quiz, quiz.ToQuizDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] QuizRequestDto updateDto )
        {
            var quizModel = await _quizRepo.UpdateAsync(id, updateDto);

            return Ok(quizModel.ToQuizDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var quiz = await _quizRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}
