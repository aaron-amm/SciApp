using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace SciApp.Web.IntegrationTest
{
    public class UserLogInPage : BaseBlock
    {
        public UserLogInPage(Session session) : base(session)
        {
           
        }

        public ITextField<UserLogInPage> UserNameField => new TextField<UserLogInPage>(this, By.Id("Username"));
        public ITextField<UserLogInPage> PasswordField => new TextField<UserLogInPage>(this, By.Id("Password"));
        public IClickable<UserHomePage> LoginButton => new Clickable<UserHomePage>(this,By.Id("btnLogIn"));

    }
}