using Abp.Application.Services.Dto;

namespace EOffice.Questions.Dto
{
    public class GetQuestionOutput : IOutputDto
    {
        public QuestionWithAnswersDto Question { get; set; }
    }
}