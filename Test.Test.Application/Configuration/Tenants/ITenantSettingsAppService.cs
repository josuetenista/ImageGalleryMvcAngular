using System.Threading.Tasks;
using Abp.Application.Services;
using Test.Test.Configuration.Tenants.Dto;

namespace Test.Test.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
