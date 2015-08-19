using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace EOffice.Questions.Dto
{
    public class SubmitAnswerInput : IInputDto
    {
        [Range(1, int.MaxValue)]
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}