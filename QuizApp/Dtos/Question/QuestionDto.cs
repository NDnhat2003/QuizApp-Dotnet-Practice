using QuizApp.Models;

namespace QuizApp.Dtos.Question
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string QuestionType { get; set; }
        public Guid? AnswerId { get; set; }
    }
}
