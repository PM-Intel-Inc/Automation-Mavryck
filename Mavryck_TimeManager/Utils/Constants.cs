using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mavryck_TimeManager.Utils
{
    public class Constants
    {
        public static readonly string BaseUrl = "https://staging.mavryck.com/login";
        public static readonly string email = "mavryck_dev@mavryck.com";
        public static readonly string password = "Dev12345!";
        public static ExtentReports Extent { get;  set; }
        public static ExtentTest Test { get; set; }

        public readonly int retryCount = 2;

        public System.Random Random = new System.Random();

        public static string chromiumExecutablePath = "C:\\Users\\USER\\AppData\\Local\\ms-playwright\\chromium-1000\\chrome-win\\chrome.exe";

        public static string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
        public static string reportsFolderPath = Path.Combine(projectDirectory, "report");
        public string ReportPath = reportsFolderPath;
        public string ScreenshotPath = Path.Combine(reportsFolderPath, "image");
        public static string resourcesFolderPath = Path.Combine(projectDirectory, "resources");
        public static string DataFolderPath = Path.Combine(resourcesFolderPath, "data");
        public static string costFile = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\resources\data\CostData.xlsx"));
        public static string contractFile = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\resources\data\Contract Document.docx"));



        public void SetupReports()
        {
          
            var htmlReporter = new ExtentSparkReporter(ReportPath);
            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }

        public void TeardownReports()
        {
            Extent.Flush();
        }

        public async Task HandleExceptionAsync(IPage page, Exception e)
        {
            string screenshotPath = Path.Combine(ScreenshotPath, $"screenshot{DateTime.Now.Ticks}.png");
            var screenshotOptions = new PageScreenshotOptions
            {
                Path = screenshotPath,
            };
            // page.ScreenshotAsync(screenshotOptions).Wait();
            byte[] screenshotBytes = await page.ScreenshotAsync();
            Test.Fail($"Test failed: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            Assert.True(false);
        }

    }
}
