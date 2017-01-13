using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace SciApp.Web.IntegrationTest
{
    public class FileInput : Element 
    {
        public FileInput(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public FileInput(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }


        public TParent SelectFile<TParent>(string filePath) where TParent : IBlock
        {
            this.Tag.SendKeys(filePath);
            return Session.CurrentBlock<TParent>(this.ParentBlock.Tag);

        }


    }

}