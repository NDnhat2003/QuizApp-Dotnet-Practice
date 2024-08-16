using Microsoft.EntityFrameworkCore;
using QuizApp.Data;

using QuizApp.interfaces;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizAppDbContext _context;

        public AnswerRepository(QuizAppDbContext context)
        {
            _context = context;
        }

        public async Task<Answer> CreateAsync(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<bool> Exist(Guid id)
        { 
            return await _context.Answers.AnyAsync(a => a.Id == id);
        }

        public async Task<List<Answer>> GetAllAsync()
        {
            return await _context.Answers.Include(a => a.Questions).ToListAsync();
        }

        public async Task<Answer?> GetByIdAsync(Guid id)
        {
            return await _context.Answers.Include(a => a.Questions).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
