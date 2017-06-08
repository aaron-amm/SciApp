using System;
using System.Drawing;
using System.Linq;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using Xunit;

namespace SciApp.Web.IntegrationTest
{

    public class GridDriver : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            ////cap.SetCapability("browserName","chrome");
            ////cap.SetCapability("platform","WIN10");
            ////var driver = new RemoteWebDriver(new Uri(node), cap);
            ////return driver;
            ////var option = new ChromeOptions();
            ////option.BinaryLocation = @"C:\projects\SciApp\packages\Selenium.WebDriver.ChromeDriver.2.29.0\driver\win32\chromedriver.exe";
            ////var capabilities = option.ToCapabilities();
            ////var commandTimeout = TimeSpan.FromMinutes(5);
            //var driver = new RemoteWebDriver(new Uri(node), cap);
            //return driver;

            //const string node = "http://localhost:4444/wd/hub";
            //var cap = DesiredCapabilities.Chrome();
            //var driver = new RemoteWebDriver(new Uri(node), cap, TimeSpan.FromMinutes(3));

            //driver.Manage().Window.Size = new Size(320, 568);
            //return driver;
            return CreatePhantomJsDriver();
        }

        private static PhantomJSDriver CreatePhantomJsDriver()
        {
            var options = new PhantomJSOptions();
            var userAgent =
                "Mozilla/5.0 (iPhone; CPU iPhone OS 5_0 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9A334 Safari/7534.48.3";
            options.AddAdditionalCapability("phantomjs.page.settings.userAgent", userAgent);
            PhantomJSDriver driver = new PhantomJSDriver(options);
            driver.Manage().Window.Size = new Size(800, 600);
            return driver;
        }
    }


    public class UserLogInPageTest : IClassFixture<UserLogInPageFixture>
    {
        private readonly Session session;

        public UserLogInPageTest(UserLogInPageFixture userLogInPageFixture)
        {
            session = userLogInPageFixture.Session;
        }


        [Fact]
        public void ClickEditLink_EditUserPanelShow()
        {
            var page = session.NavigateTo<UserIndexPage>("http://localhost:8080/user/index");
            var driver = session.Driver;
            //0,1,2
            page.UserTableRows[1].EditUserLink.Click();


            //transparent by default
            driver.ExecuteScript<object>("$('body').css('background-color','white')");
            var takeScreenShort = (ITakesScreenshot)driver;
            takeScreenShort.GetScreenshot().SaveAsFile("login2.jpg", ScreenshotImageFormat.Jpeg);

            var displayValue = driver.FindElement(By.CssSelector(".edit-user-panel")).GetCssValue("display");
            Assert.Equal("block", displayValue);
        }




        [Fact]
        public void LogIn_ValidInput_LogInSuccessfully()
        {
            string userName;
            var page = session.NavigateTo<UserLogInPage>("http://192.168.1.105:8080/user/login");

            var driver = session.Driver;

            page.UserNameField.EnterText("aaron")
            .PasswordField.EnterText("12345")
            .LoginButton.Click()
            .UserNameSpan()
            .Store(out userName, s => s.Text);

            //transparent by default
            driver.ExecuteScript<object>("$('body').css('background-color','white')");
            var takeScreenShort = (ITakesScreenshot)driver;
            takeScreenShort.GetScreenshot().SaveAsFile("login2.jpg", ScreenshotImageFormat.Jpeg);

            Assert.Equal("aaron", userName);

        }

        [Fact]
        public void LogIn_ValidInput_LogInSuccessfully2()
        {
            string userName;
            var page = session.NavigateTo<UserLogInPage>("http://192.168.1.105:8080/user/login");

            var driver = session.Driver;

            page.UserNameField.EnterText("aaron")
            .PasswordField.EnterText("12345")
            .LoginButton.Click()
            .UserNameSpan()
            .Store(out userName, s => s.Text);
            Assert.Equal("aaron", userName);
        }

    }

    public class UserLogInPageFixture : IDisposable
    {

        public Session Session { get; private set; }
        public UserLogInPageFixture()
        {
            Session = Threaded<Session>.With<GridDriver>();
        }

        ///The tear down operation is needed in case there is a failure during the test.  The Session will need to be
        ///cleaned up.
        public void Dispose()
        {
            Threaded<Session>.End();
        }
    }



}