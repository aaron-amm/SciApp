using System;
using System.Collections.Generic;
using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SciApp.Web.IntegrationTest
{
    public class UserIndexPage : BaseBlock
    {
        public UserIndexPage(Session session) : base(session)
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
        public UserTableRow[] UserTableRows
        {
            get
            {
                var rows = FindElements(By.CssSelector(".user-table tr")).ToArray();
                return rows.Select(tr => new UserTableRow(Session, tr)).ToArray();
            }
        }


    }


    public class UserTableRow : SpecificBlock
    {
        public UserTableRow(Session session, IWebElement tableRow) : base(session, tableRow)
        {
        }

        public IClickable<UserIndexPage> EditUserLink => 
            new Clickable<UserIndexPage>(this, By.CssSelector(".edit-user-link"));

    }

}