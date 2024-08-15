using QuizApp.Dtos.Quiz;
using QuizApp.Models;

namespace QuizApp.Mappers
{
    public static class QuizMapper
    {
        public static QuizDto ToQuizDto(this Quiz quiz)
        {
            return new QuizDto
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Duration = quiz.Duration,
                Description = quiz.Description
            };
        }
        public static Quiz ToQuizFromDTO(this QuizRequestDto quizDto) 
        {
            return new Quiz
            {
                Title = quizDto.Title,
                Duration = quizDto.Duration,
                Description = quizDto.Description
            };
        }
    }
}
