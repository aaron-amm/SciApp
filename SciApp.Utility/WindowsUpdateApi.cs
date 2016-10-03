using System;
using System.Linq;
using System.Runtime.InteropServices;
using WUApiLib;

namespace SciApp.Utility
{
    public class WindowsUpdateApi
    {

        public void GetUpdatedHistory()
        {
            var updateSession = new UpdateSession();
            var updateSearcher = updateSession.CreateUpdateSearcher();
            var count = updateSearcher.GetTotalHistoryCount();
            var history = updateSearcher.QueryHistory(0, count);

            for (var i = 0; i < count; ++i)
            {
                var item = history[i];
                Console.WriteLine($"{item.Title}, {item.Date}");
            }
        }

        public void GetAvailableUpdate()
        {
            try
            {
                var uSession = new UpdateSession();
                IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
                ISearchResult uResult = uSearcher.Search("IsInstalled=0 and Type='Software'");
                foreach (IUpdate update in uResult.Updates)
                {
                    Console.WriteLine(update.Title);
                }
            }
            catch (COMException ex)
            {
                //Exception from HRESULT: 0x8024402C
                //message checking internet connection
                //more info http://www.updatexp.com/0x8024402c.html

            }
        }
    }

}