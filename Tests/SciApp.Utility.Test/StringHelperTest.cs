using System.IO;
using NUnit.Framework;

namespace SciApp.Utility.Test
{
    public class StringHelperTest
    {
        [Test]
        public void RemoveNewLine_Test()
        {
            //http://www.dotnetperls.com/regexoptions-multiline
            //^xxx$ and multiple line option
            var input = File.ReadAllText(@"NewLineStringInput.txt");
            const string expectedResult = @"hellomynewworld";
            Assert.AreEqual(expectedResult, input.RemoveNewLine());
        }



    }
}