using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Test.Test.Authorization.Users;

namespace Test.Test.Configuration.Host.Dto
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}