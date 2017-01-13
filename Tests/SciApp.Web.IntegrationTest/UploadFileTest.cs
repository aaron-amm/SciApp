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
            const string fileName = "C:/Users/aaron/Downloads/pd.jpg";
            Threaded<Session>
                .With<Chrome>()
                .NavigateTo<FileUploadPage>("http://localhost:8080/file/upload")
                .UploadedFile.SelectFile<FileUploadPage>(fileName)
                .UploadFileButton.Click<FileUploadResult>()
                .Verify(f => f.FileName.Tag.Text == "pd.jpg");

        }

        [TearDown]
        public void TearDown()
        {
            Threaded<Session>.End();
        }
    }
}