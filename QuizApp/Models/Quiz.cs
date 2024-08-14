namespace QuizApp.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }
        public required int Duration { get; set; }

        public List<Question>? Questions { get; set; } = new List<Question>();

    }
}
