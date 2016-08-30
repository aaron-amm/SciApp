using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using SciHospital.WebApp.Areas.Public;

namespace SciHospital.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(new Route("hello", new WebFormRouteHandler("~/hello.aspx")));


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                ).DataTokens.Add("area", PublicAreaRegistration.NameForArea);

            //ignore static file to not get match with mvc default route
            //match static file like ~/styles/style.css?version=1
//            routes.IgnoreRoute("{*ignoreFile}", new { ignoreFile = @".*\.(?:css|js|gif|jpg|png|svg|ico|ashx|woff|woff2|ttf|asmx|aspx)(?:\?.*)?" });
//            routes.IgnoreRoute("{resource}.{ignoreExtension}/{*pathInfo}", new  { ignoreExtension = "axd|asmx"});

        }

    }
    public class WebFormRouteHandler : IRouteHandler
    {
        public WebFormRouteHandler(string virtualPath) : this(virtualPath, true)
        {
        }

        public WebFormRouteHandler(string virtualPath, bool checkPhysicalUrlAccess)
        {
            this.VirtualPath = virtualPath;
            this.CheckPhysicalUrlAccess = checkPhysicalUrlAccess;
        }

        public string VirtualPath { get; private set; }

        public bool CheckPhysicalUrlAccess { get; set; }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (this.CheckPhysicalUrlAccess && !UrlAuthorizationModule.CheckUrlAccessForPrincipal(this.VirtualPath, requestContext.HttpContext.User, requestContext.HttpContext.Request.HttpMethod))
            {
                throw new SecurityException();
            }

            var page = BuildManager.CreateInstanceFromVirtualPath(this.VirtualPath, typeof(Page)) as IHttpHandler;

            if (page != null)
            {
                var routablePage = page as IRoutablePage;
                if (routablePage != null)
                    routablePage.RequestContext = requestContext;
            }
            return page;
        }
    }

    public interface IRoutablePage
    {
        RequestContext RequestContext { set; }
    }


}
