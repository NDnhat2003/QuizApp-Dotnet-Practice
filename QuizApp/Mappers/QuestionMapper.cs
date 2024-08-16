using QuizApp.Dtos.Question;
using QuizApp.Models;

namespace QuizApp.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionDto ToQuestionDto(this Question question)
        {
            return new QuestionDto
            {
                Id = question.Id,
                Content = question.Content,
                QuestionType = question.QuestionType,
                AnswerId = question.AnswerId
            };
        }

        public static Question ToQuestionFromDto(this QuestionRequestDto questionDto, Guid AnswerId)
        {
            return new Question
            {
                Content = questionDto.Content,
                QuestionType = questionDto.QuestionType,
                AnswerId = AnswerId
            };
        }
    }
}
