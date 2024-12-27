using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mavryck_TimeManager.Utils;
using NUnit.Framework;
using System.IO;

namespace Mavryck_TimeManager.Tests
{

    [SetUpFixture]

    public class TestSetup : Base
    {
        public static ExtentReports extent;


        [OneTimeSetUp]
        public new  void SetupReports()
        {
            DeleteImagesFromFolder();
            Extent = new ExtentReports();
            string reportPath = Path.Combine(ReportPath, "index.html");
            var htmlReporter = new ExtentSparkReporter(reportPath);
            Console.WriteLine(htmlReporter);
            Extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public new void TeardownReports()
        {
            Extent.Flush();
        }
    }
}
