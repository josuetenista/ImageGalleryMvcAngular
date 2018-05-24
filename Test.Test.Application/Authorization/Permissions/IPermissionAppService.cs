using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Test.Test.Authorization.Permissions.Dto;

namespace Test.Test.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
