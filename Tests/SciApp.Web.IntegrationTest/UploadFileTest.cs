using System.IO;
using Bumblebee.Extensions;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using NUnit.Framework;

namespace SciApp.Web.IntegrationTest
{
    [TestFixture]
    public class UploadFileTest
    {
        [Test]
        public void Test()
        {
            const string filePath = @"c:\\silicon-valley.jpg";
            var page = Threaded<Session>
                 .With<Chrome>()
                 .NavigateTo<FileUploadPage>("http://localhost:8080/file/upload")
                 .UploadedFile.SelectFile<FileUploadPage>(filePath)
                 .UploadFileButton.Click<FileUploadResult>();

            page.Verify(f => f.FileName.Tag.Text == Path.GetFileName(filePath));

        }

        [TearDown]
        public void TearDown()
        {
            Threaded<Session>.End();
        }
    }
}