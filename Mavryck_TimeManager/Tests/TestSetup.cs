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
            ExportResultsToJson();
            Extent.Flush();
        }

        public static void ExportResultsToJson()
        {
            // Serialize the results to JSON
            var jsonResults = JsonConvert.SerializeObject(new { testResults = _testResults }, Formatting.Indented);

            // Optionally write to file
            string reportPath = Path.Combine(JsonReportPath, "jsonFile.json");
            File.WriteAllText(reportPath, jsonResults);
            Console.WriteLine($"Test results exported to {reportPath}");
        }

    }
}
