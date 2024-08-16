using QuizApp.Dtos.Question;

namespace QuizApp.Dtos.Quiz
{
    public class QuizDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public List<QuestionDto>? Questions { get; set; }
    }
}
