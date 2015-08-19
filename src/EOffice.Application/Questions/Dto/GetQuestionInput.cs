using Abp.Application.Services.Dto;

namespace EOffice.Questions.Dto
{
    public class GetQuestionInput : EntityRequestInput
    {
        public bool IncrementViewCount { get; set; }
    }
}