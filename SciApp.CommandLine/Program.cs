using System;
using SciApp.SimpleCom.Api;

namespace SciApp.CommandLine
{
    public class Program
    {

        [STAThread]
        public static void Main(string[] args)
        {
            var helloCom = (IHelloCom)new HelloCom();
            Console.WriteLine(helloCom.SayHello());
        }
    }
}