using System;
using NUnit.Framework;

namespace SciApp.SimpleCom.Api.Test
{
    public class HelloComTest
    {

        [STAThread]
        [Test]
        public void SayHello_ValidCom_ReturnHelloWorldMessage()
        {
            var helloCom = (IHelloCom)new HelloCom();
            Assert.AreEqual("Hello World", helloCom.SayHello());
        }
    }
}