using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Test.Test.Authorization.Users;
using Test.Test.MultiTenancy;

namespace Test.Test.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
