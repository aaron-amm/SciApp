using System.Web.Mvc;

namespace SciHospital.WebApp.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public const string NameForArea = "Admin";
        public override string AreaName => NameForArea;

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}