using System.Web.Mvc;

namespace SciHospital.WebApp.Areas.Public
{
    public class PublicAreaRegistration : AreaRegistration 
    {
        public const string NameForArea = "Public";
        public override string AreaName => NameForArea;

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var urlPattern = string.Format("{0}/{{controller}}/{{action}}/{{id}}",NameForArea);
            context.MapRoute(
                "Public_default",
                urlPattern,
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}