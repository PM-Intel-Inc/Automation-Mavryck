using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Mavryck_TimeManager.Utils;
using NUnit.Framework;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Mavryck_TimeManager.Tests
{

    [SetUpFixture]

    public class TestSetup : Base
    {

        [OneTimeSetUp]
        public void SetupReports()
        {
            DeleteImagesFromFolder();
            Extent = new ExtentReports();
            string reportPath = Path.Combine(ReportPath, "index.html");
            var htmlReporter = new ExtentSparkReporter(reportPath);
            Extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void TeardownReports()
        {
            Extent.Flush();
            //SendEmailWithReport();

        }



    }
}
