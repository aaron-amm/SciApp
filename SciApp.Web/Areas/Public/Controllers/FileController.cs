using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SciHospital.WebApp.Areas.Public.Controllers
{
    public class FileController : Controller
    {

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadedFile)
        {
            if (uploadedFile == null)
            {
                return new HttpStatusCodeResult(500, "no uploadedFile");
            }
            var fileName = Path.GetFileName(uploadedFile.FileName);
            var filePath = Path.Combine(Server.MapPath("~/uploads"), fileName);
            var file=new FileInfo(filePath);
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }

            uploadedFile.SaveAs(filePath);
            return RedirectToAction("UploadResult", new { fileName });
        }

        [HttpGet]
        public ActionResult UploadResult(string fileName)
        {
            ViewBag.FileName = fileName;
            return View();
        }

    }
}