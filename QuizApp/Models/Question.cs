namespace QuizApp.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public required string QuestionType { get; set; }
        public Guid? AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
