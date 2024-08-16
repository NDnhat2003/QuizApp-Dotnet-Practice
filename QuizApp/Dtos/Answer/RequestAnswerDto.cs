using QuizApp.Dtos.Question;
using QuizApp.Models;

namespace QuizApp.Dtos.Answer
{
    public class RequestAnswerDto
    {
        public string Content { get; set; }
        public bool isCorrect { get; set; }
    }
}
