using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using NUnit.Framework;
using Rhino.Mocks;
using SciHospital.WebApp;
using SciHospital.WebApp.Areas.Public;

namespace SciApp.Web.Test
{
    public class RoutingTest
    {

        [Test]
        public void GetRouteData_ValidRequestUrl_ReturnCorrectControllerAndAction()
        {
            var routes = new RouteCollection();
            Global.RegisterRoutes(routes);

            var httpContextMock = MockRepository.GenerateMock<HttpContextBase>();
            const string url = "~/Patient/UpdatePatient";
            httpContextMock.Stub(c => c.Request.AppRelativeCurrentExecutionFilePath).Return(url);

            var routeData = routes.GetRouteData(httpContextMock);
            var controller = routeData.Values["controller"];
            var action = routeData.Values["action"];
            Assert.AreEqual("Patient", controller);
            Assert.AreEqual("UpdatePatient", action);
        }

        [Test]
        public void GetRouteData_UrlHasId_ReturnCorrectId()
        {
            var routes = new RouteCollection();
            Global.RegisterRoutes(routes);

            var httpContextMock = MockRepository.GenerateMock<HttpContextBase>();
            const string url = "~/Patient/UpdatePatient/1";
            httpContextMock.Stub(c => c.Request.AppRelativeCurrentExecutionFilePath).Return(url);

            var routeData = routes.GetRouteData(httpContextMock);
            var id = routeData.Values["id"];
            Assert.AreEqual("1", id);
        }

        [Test]
        public void GetRouteData_UrlHasArea_ReturnCorrectAreaName()
        {
            var routes = new RouteCollection();
            Global.RegisterRoutes(routes);

            var httpContextMock = MockRepository.GenerateMock<HttpContextBase>();
            const string url = "~/Public/Patient/UpdatePatient/1";
            httpContextMock.Stub(c => c.Request.AppRelativeCurrentExecutionFilePath).Return(url);

            var routeData = routes.GetRouteData(httpContextMock);
            var area = routeData.DataTokens["area"];
            Assert.AreEqual(PublicAreaRegistration.NameForArea, area);
        }

        [Test]
        public void GetRouteData_RootUrl_ReturnCorrectAreaControllerAndActionName()
        {
            var routes = new RouteCollection();
            Global.RegisterRoutes(routes);

            var httpContextMock = MockRepository.GenerateMock<HttpContextBase>();
            const string url = "~/";
            httpContextMock.Stub(c => c.Request.AppRelativeCurrentExecutionFilePath).Return(url);

            var routeData = routes.GetRouteData(httpContextMock);
            var area = routeData.DataTokens["area"];
            var controller = routeData.Values["controller"];
            var action = routeData.Values["action"];

            Assert.AreEqual(PublicAreaRegistration.NameForArea, area);
            Assert.AreEqual("Home", controller);
            Assert.AreEqual("Index", action);
        }

        [Test]
        public void GetRouteData_WebFormUrl_ReturnCorrectAreaControllerAndActionName()
        {
            var routes = new RouteCollection();
            Global.RegisterRoutes(routes);

            var httpContextMock = MockRepository.GenerateMock<HttpContextBase>();
            const string url = "~/hello";
            httpContextMock.Stub(c => c.Request.AppRelativeCurrentExecutionFilePath).Return(url);

            var routeData = routes.GetRouteData(httpContextMock);
            var routeHandler = (WebFormRouteHandler) routeData.RouteHandler;

            Assert.AreEqual("~/hello.aspx", routeHandler.VirtualPath);
        }

    }
}
