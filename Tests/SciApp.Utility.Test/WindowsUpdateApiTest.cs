using NUnit.Framework;

namespace SciApp.Utility.Test
{
    public class WindowsUpdateApiTest
    {
        //Windows 10 update history
        //https://support.microsoft.com/en-us/help/12387/windows-10-update-history
        [Test]
        public void CheckUpdatedHistory_ValidInput_ReturnAllUpdatedHistory()
        {
            var api = new WindowsUpdateApi();
            api.GetUpdatedHistory();
        }

        //to install Windows update with C#
        //http://techforum4u.com/entry.php/11-Install-Windows-Update-Using-C

        [Test]
        public void CheckAvailableUpdate_ValidInput_ReturnAllAvailableUpdate()
        {
            var api = new WindowsUpdateApi();
            api.GetAvailableUpdate();
        }
    }
}