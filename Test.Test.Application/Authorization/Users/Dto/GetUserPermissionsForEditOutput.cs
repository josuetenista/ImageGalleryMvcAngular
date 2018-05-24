using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Test.Test.Authorization.Permissions.Dto;

namespace Test.Test.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}