using System.Web.Mvc;

namespace Test.Test.Web.Controllers
{
    public class HomeController : TestControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}