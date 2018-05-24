using System.Web.Mvc;
using Abp.Auditing;

namespace Test.Test.Web.Controllers
{
    public class ErrorController : TestControllerBase
    {
        [DisableAuditing]
        public ActionResult E404()
        {
            return View();
        }
    }
}