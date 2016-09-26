using System;
using System.Threading;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SciApp.Web.IntegrationTest
{
    public class DatePicker<TResult> :  Clickable where TResult : IBlock
    {
        public DatePicker(IBlock parent, By by) : base(parent, by)
        {
        }

        public DatePicker(TResult parent, IWebElement tag) : base(parent, tag)
        {

        }

        public TResult SelectDate(int selectedDate)
        {
            Click<TResult>();

            var driver =ParentBlock.Session.Driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
            const string datePopupId = "ui-datepicker-div";
            wait.Until(drv => drv.FindElement(By.Id(datePopupId)));

            var datePopup = ParentBlock.Tag.FindElement(By.Id(datePopupId));
            var allDates = datePopup.FindElements(By.XPath(@"//table[@class='ui-datepicker-calendar']//td"));
            foreach (var ele in allDates)
            {
                var  date= ele.Text;
                if (string.Equals(date, selectedDate.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    ele.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }

            return Session.CurrentBlock<TResult>(this.ParentBlock.Tag);

        }

    }
}