using Abp.Domain.Services;

namespace Test.Test
{
    public abstract class TestDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected TestDomainServiceBase()
        {
            LocalizationSourceName = TestConsts.LocalizationSourceName;
        }
    }
}
