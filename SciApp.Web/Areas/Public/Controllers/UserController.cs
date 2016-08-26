using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SciHospital.WebApp.Areas.Public.Controllers
{
    public class UserController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Content("public/user");
        }

        [Authorize]
        public ActionResult Strict()
        {
            return Content("public/user/strict");
        }


        public ActionResult Get()
        {
            var requestUri = Request.Url;
            var jsonUri = $"{requestUri.Scheme}://{requestUri.Host}:{requestUri.Port}/home/json";
            var contextId = Thread.CurrentThread.ManagedThreadId;
            var task = Task.Run(() => GetJsonAsync(jsonUri));
            task.Wait();
            contextId = Thread.CurrentThread.ManagedThreadId;
            return Content("success");
        }



        public static Task GetJsonAsync(string url)
        {
            var contextId = Thread.CurrentThread.ManagedThreadId;
            return Task.Delay(10000);
        }


//        public ActionResult Get()
//        {
//            var requestUri = Request.Url;
//            var jsonUri = $"{requestUri.Scheme}://{requestUri.Host}:{requestUri.Port}/home/json";
//            var contextId = Thread.CurrentThread.ManagedThreadId;
//            var task = Task.Run(() => GetJsonAsync(jsonUri));
//            task.Wait();
//            contextId = Thread.CurrentThread.ManagedThreadId;
//            return Content("success");
//        }
//
//
//
//        public static async Task GetJsonAsync(string url)
//        {
//            var contextId = Thread.CurrentThread.ManagedThreadId;
//
//            using (var client = new HttpClient())
//            {
//                var jsonString = await client.GetStringAsync(url).ConfigureAwait(true);
//                await Task.Delay(1000);
//
//            contextId = Thread.CurrentThread.ManagedThreadId;
//                //return JObject.Parse(jsonString);
//            }
//        }


        public ActionResult Json()
        {
            var jsonObject = new { FirstName = "Sci", LastName = "Meta" };
            return Json(jsonObject, JsonRequestBehavior.AllowGet);
        }
    }
}