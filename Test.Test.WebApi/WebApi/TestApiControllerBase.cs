using Abp.WebApi.Controllers;

namespace Test.Test.WebApi
{
    public abstract class TestApiControllerBase : AbpApiController
    {
        protected TestApiControllerBase()
        {
            LocalizationSourceName = TestConsts.LocalizationSourceName;
        }
    }
}