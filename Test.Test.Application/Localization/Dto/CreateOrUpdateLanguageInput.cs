using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Test.Test.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}