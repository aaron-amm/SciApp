using System.Web.Mvc;

namespace SciHospital.WebApp.Areas.Public.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Banner()
        {
            return View();
        }

    }
}