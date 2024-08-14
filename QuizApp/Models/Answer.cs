namespace QuizApp.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public required bool isCorrect  { get; set; }
        public List<Question>? Questions { get; set; } = new List<Question>();
    }
}
