using Bumblebee.Extensions;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using NUnit.Framework;

namespace SciApp.Web.IntegrationTest
{
    [TestFixture]
    public class UserLogInPageTest
    {
        [Test]
        public void LogIn_ValidInput_LogInSuccessfully()
        {
            string userName;
            Threaded<Session>
                .With<Chrome>()
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
            Threaded<Session>
              .End();
        }
    }
}