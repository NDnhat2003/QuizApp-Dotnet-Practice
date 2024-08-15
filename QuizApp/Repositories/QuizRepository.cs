using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Dtos.Quiz;
using QuizApp.interfaces;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizAppDbContext _context;
        public QuizRepository(QuizAppDbContext context) 
        {
            _context = context;
        }

        public async Task<Quiz> CreateAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        public async Task<Quiz?> DeleteAsync(Guid id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return null;
            }

            _context.Remove(quiz);

            await _context.SaveChangesAsync();

            return quiz;
        }

        public async Task<List<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public Task<Quiz?> GetByIdAsync(Guid id)
        {
            var quiz = _context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);

            if (quiz == null)
            {
                return null;
            }

            return quiz;
        }

        public async Task<Quiz?> UpdateAsync(Guid id, QuizRequestDto quizDto)
        {
            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return null;
            }

            _context.Entry(quiz).CurrentValues.SetValues(quizDto);
            await _context.SaveChangesAsync();

            return quiz;
        }
    }
}
