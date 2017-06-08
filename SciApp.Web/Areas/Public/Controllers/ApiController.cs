using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SciHospital.WebApp.Areas.Public.Controllers
{
    public class ApiController:Controller
    {
        public ActionResult ScrollTop()
        {
            return View();
        }
    }
}