using System.IO;
using Bumblebee.Extensions;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;

namespace SciApp.Web.IntegrationTest
{
    public class UploadFileTest
    {
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

        public void TearDown()
        {
            Threaded<Session>.End();
        }
    }
}