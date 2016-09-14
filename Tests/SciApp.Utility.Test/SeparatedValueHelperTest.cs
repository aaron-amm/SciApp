using NUnit.Framework;

namespace SciApp.Utility.Test
{
    [TestFixture]
    public class SeparatedValueHelperTest
    {
        [Test]
         public void Test()
        {
            var spaceSeparatedValue = "aa bb cc";
          var arrayValue=  spaceSeparatedValue.SpaceSeparatedToArray();
            Assert.AreEqual(3, arrayValue.Length);

        }

        [Test]
        public  void Test2()
        {

            var arrayValue= new []{ "aa", "bb", "cc"};
            var stringValue = arrayValue.ArrayToSpaceSeparated();
            Assert.AreEqual("aa bb cc", stringValue);
        }
    }
}