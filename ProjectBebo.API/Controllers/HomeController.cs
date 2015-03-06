using System.Web.Mvc;

namespace ProjectBebo.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
