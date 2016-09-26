using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace SciApp.Web.IntegrationTest
{
    public class BaseBlock : WebBlock
    {
        public BaseBlock(Session session) : base(session)
        {
            Tag = Session.Driver.GetElement(By.TagName("body"));
        }
    }
}