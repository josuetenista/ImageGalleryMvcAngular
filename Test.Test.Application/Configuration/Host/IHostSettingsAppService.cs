using System.Threading.Tasks;
using Abp.Application.Services;
using Test.Test.Configuration.Host.Dto;

namespace Test.Test.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
