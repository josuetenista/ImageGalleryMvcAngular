using Abp.Authorization;
using Test.Test.Authorization.Roles;
using Test.Test.Authorization.Users;
using Test.Test.MultiTenancy;

namespace Test.Test.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
