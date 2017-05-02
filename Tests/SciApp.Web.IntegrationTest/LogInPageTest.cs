using System;
using System.Threading;
using Bumblebee.Extensions;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SciApp.Web.IntegrationTest
{

    public class GridDriver : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            const string node = "http://192.168.1.105:4444/wd/hub";
            var cap = DesiredCapabilities.Chrome();
            //cap.SetCapability("browserName","chrome");
            //cap.SetCapability("platform","WIN10");
            //var driver = new RemoteWebDriver(new Uri(node), cap);
            //return driver;
            //var option = new ChromeOptions();
            //option.BinaryLocation = @"C:\projects\SciApp\packages\Selenium.WebDriver.ChromeDriver.2.29.0\driver\win32\chromedriver.exe";
            //var capabilities = option.ToCapabilities();
            //var commandTimeout = TimeSpan.FromMinutes(5);
            var driver = new RemoteWebDriver(new Uri(node), cap);
            return driver;
        }
    }
    [TestFixture]
    public class UserLogInPageTest
    {

        [Test]
        public void LogIn_ValidInput_LogInSuccessfully()
        {
            string userName;
            Threaded<Session>
                .With<GridDriver>()
                .NavigateTo<UserLogInPage>("http://localhost:8080/user/login")
                .UserNameField.EnterText("aaron")
                .PasswordField.EnterText("12345")
                .LoginButton.Click()
                .UserNameSpan()
                .Store(out userName, s => s.Text);

            Assert.AreEqual("aaron", userName);
        }

        ///The tear down operation is needed in case there is a failure during the test.  The Session will need to be
        ///cleaned up.
        [TearDown]
        public void TearDown()
        {
            Threaded<Session>.End();
        }
    }
}