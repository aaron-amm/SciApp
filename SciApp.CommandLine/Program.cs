using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SciApp.CommandLine
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            var helloCom = (IHelloCom) new HelloCom();
            Console.WriteLine(helloCom.SayHello());

        }
    }
}
