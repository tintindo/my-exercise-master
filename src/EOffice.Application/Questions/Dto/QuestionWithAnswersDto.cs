using System.Collections.Generic;
using Abp.AutoMapper;

namespace EOffice.Questions.Dto
{
    [AutoMapFrom(typeof(Question))]
    public class QuestionWithAnswersDto : QuestionDto
    {
        public List<AnswerDto> Answers { get; set; }
    }
}