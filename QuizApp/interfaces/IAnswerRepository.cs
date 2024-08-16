using QuizApp.Models;

namespace QuizApp.interfaces
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllAsync();
        Task<Answer?> GetByIdAsync(Guid id);
        Task<Answer> CreateAsync(Answer answer);
        Task<bool> Exist(Guid id);
    }
}
