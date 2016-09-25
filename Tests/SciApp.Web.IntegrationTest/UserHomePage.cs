using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SciApp.Web.IntegrationTest
{
    public class UserHomePage : BaseBlock
    {
        public UserHomePage(Session session) : base(session)
        {
            var driver = Session.Driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
            wait.Until(drv => drv.FindElement(By.Id("home")));

            Tag = Session.Driver.FindElement(By.TagName("body"));
        }

        public SpanElement UserNameSpan()
        {
            return new SpanElement(this, By.Id("lblUsername"));
        }
    }
}