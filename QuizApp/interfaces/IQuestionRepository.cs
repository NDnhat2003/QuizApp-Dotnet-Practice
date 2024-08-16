using QuizApp.Models;

namespace QuizApp.interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(Guid id);
        Task<Question?> CreateAsync(Question question);
        Task<bool> Exist(Guid id);
    }
}
