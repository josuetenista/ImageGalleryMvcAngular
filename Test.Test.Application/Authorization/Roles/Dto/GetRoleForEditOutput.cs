using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Test.Test.Authorization.Permissions.Dto;

namespace Test.Test.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}