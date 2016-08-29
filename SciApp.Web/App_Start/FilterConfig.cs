using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SciHospital.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomAuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {

        var routeData = httpContext.Request.RequestContext.RouteData;
        var area = routeData.DataTokens["area"];
        if (area != null && area.ToString() == "Admin")
        {
            var result=  base.AuthorizeCore(httpContext);
            return result;
        }

        return true;
    }

        private static bool IsValidEmail(string email)
        {
            // Email address: RFC 2822 Format 
            const string pattern = @"^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

}


}