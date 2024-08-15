using Microsoft.AspNetCore.Mvc;
using QuizApp.Dtos.Quiz;
using QuizApp.Models;

namespace QuizApp.interfaces
{
    public interface IQuizRepository
    {
        Task<List<Quiz>> GetAllAsync();
        Task<Quiz?> GetByIdAsync(Guid id);
        Task<Quiz> CreateAsync(Quiz quiz);
        Task<Quiz?> UpdateAsync(Guid id, QuizRequestDto quizDto);
        Task<Quiz?> DeleteAsync(Guid id);
    }
}
