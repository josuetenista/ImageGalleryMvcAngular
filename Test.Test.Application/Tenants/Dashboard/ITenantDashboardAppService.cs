using Abp.Application.Services;
using Test.Test.Tenants.Dashboard.Dto;

namespace Test.Test.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
