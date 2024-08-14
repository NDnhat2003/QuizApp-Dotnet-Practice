using Microsoft.AspNetCore.Mvc;
using QuizApp.Data;

namespace QuizApp.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly QuizAppDbContext _context;
        public QuizController(QuizAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var quizzes = _context.Quizzes.ToList();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            var quiz = _context.Quizzes.Find(id);

            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }
    }
}
