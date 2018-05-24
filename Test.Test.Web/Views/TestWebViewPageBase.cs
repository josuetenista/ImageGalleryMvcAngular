using Abp.Dependency;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Views;

namespace Test.Test.Web.Views
{
    public abstract class TestWebViewPageBase : TestWebViewPageBase<dynamic>
    {
       
    }

    public abstract class TestWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        public IAbpSession AbpSession { get; private set; }
        
        protected TestWebViewPageBase()
        {
            AbpSession = IocManager.Instance.Resolve<IAbpSession>();
            LocalizationSourceName = TestConsts.LocalizationSourceName;
        }
    }
}