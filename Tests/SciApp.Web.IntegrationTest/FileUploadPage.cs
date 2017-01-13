using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace SciApp.Web.IntegrationTest
{
    public class FileUploadPage : BaseBlock
    {
        public FileUploadPage(Session session) : base(session)
        {
        }

        public FileInput UploadedFile  => new FileInput(this, By.Name("uploadedFile"));

        public IClickable<FileUploadResult> UploadFileButton =>
            new Clickable<FileUploadResult>(this, By.Id("uploadFileButton"));

    }


    public class HtmlElement : Element
    {
        public HtmlElement(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public HtmlElement(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }
    }

    public class FileUploadResult : BaseBlock
    {
        public FileUploadResult(Session session) : base(session)
        {
        }

        public Element FileName  => new HtmlElement(this,By.Id("fileName"));
    }
}