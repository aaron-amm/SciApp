using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NLog;
using SciHospital.WebApp.Areas.Public;
using SciHospital.WebApp.Areas.Public.Controllers;

namespace SciHospital.WebApp
{
    public class Global : HttpApplication
    {
        private static IWindsorContainer container;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            container.Kernel.Register(
                Component.For<IPatientRepository>()
                .ImplementedBy<PatientRepository>()
                .LifestyleTransient());
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            BootstrapContainer();
            // Code that runs on application startup

            //GlobalConfiguration.Configure(WebApiConfig.Register);

            // AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            logger.Info("application started");
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            var publicAreaRegistration = new PublicAreaRegistration();
            publicAreaRegistration.RegisterArea(new AreaRegistrationContext(publicAreaRegistration.AreaName, routes));

            RouteConfig.RegisterRoutes(routes);

        }

        protected void Application_End()
        {
            container.Dispose();
        }


    }
}