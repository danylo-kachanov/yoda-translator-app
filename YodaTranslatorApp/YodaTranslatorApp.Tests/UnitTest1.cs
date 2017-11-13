using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Threading;
using TestStack.White;

namespace YodaTranslatorApp.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var appPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\YodaTranslatorApp\bin\Debug\YodaTranslatorApp.exe");
            var proc = Application.Launch(appPath);
            
            Thread.Sleep(3000);

            proc.Kill();
        }
    }
}
