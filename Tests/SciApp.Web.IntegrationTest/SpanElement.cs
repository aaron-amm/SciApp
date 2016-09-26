using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace SciApp.Web.IntegrationTest
{
    public class SpanElement : Element, IHasText
    {
        public SpanElement(IBlock parent, By by) : base(parent, by)
        {
        }

        public SpanElement(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }
    }
}