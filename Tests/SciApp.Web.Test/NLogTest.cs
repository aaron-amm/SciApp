using System.Linq;
using System.Web;
using NLog;
using NLog.Config;
using NLog.Targets;
using NUnit.Framework;

namespace SciApp.Web.Test
{

    public class MyFileTarget : NLog.Targets.FileTarget
    {
        protected override void Write(LogEventInfo logEvent)
        {
            base.Write(logEvent);
        }
    }

    [TestFixture]
    public class NLogTest
    {


        public MemoryTarget SwapToMemoryTarget(LoggingConfiguration configuration, string targetName)
        {
            var memoryTarget = new MemoryTarget(targetName) { Layout = "${message}" };
            foreach (var rule in configuration.LoggingRules)
            {
                var existingTarget = rule.Targets.SingleOrDefault(t => t.Name == targetName);
                if (existingTarget != null)
                {
                    rule.Targets.Remove(existingTarget);
                    rule.Targets.Add(memoryTarget);
                }
            }

            LogManager.ReconfigExistingLoggers();
            return memoryTarget;
        }



        [Test]
        public void Test()
        {
            var configuration = LogManager.Configuration;
            var mailTarget = SwapToMemoryTarget(configuration, "mail");
            var fileTarget = SwapToMemoryTarget(configuration, "file");

            var logger = LogManager.GetCurrentClassLogger();
            var ex = new HttpException();
            logger.Error(ex, "hello");
            Assert.AreEqual(0, mailTarget.Logs.Count);
            Assert.AreEqual("hello", fileTarget.Logs[0]);
        }
    }
}
