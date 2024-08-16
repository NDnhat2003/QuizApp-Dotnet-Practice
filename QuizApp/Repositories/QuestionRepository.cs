using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.interfaces;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizAppDbContext _context;
        public QuestionRepository(QuizAppDbContext context)
        {
            _context = context;
        }

        public async Task<Question?> CreateAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<bool> Exist(Guid id)
        {
            return await _context.Questions.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Question>> GetAllAsync()
        {
            var quizzes = await _context.Questions.ToListAsync();
            return quizzes;
        }

        public async Task<Question> GetByIdAsync(Guid id)
        {
            return await _context.Questions.FindAsync(id);
        }

    }
}
