using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Mavryck_TimeManager.Utils
{
    public class Constants
    {
        public static readonly string BaseUrl = "https://dev.mavryck.com/login";
        public static readonly string email = "mavryck_dev@mavryck.com";
        public static readonly string password = "Dev12345!";
        public static ExtentReports Extent { get; set; }
        //public static ExtentTest Test { get; set; }

        public readonly int retryCount = 2;

        public System.Random Random = new System.Random();

        public static string chromiumExecutablePath = "C:\\Users\\USER\\AppData\\Local\\ms-playwright\\chromium-1000\\chrome-win\\chrome.exe";

        public static string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
        public static string reportsFolderPath = Path.Combine(projectDirectory, "report");
        public string ReportPath = reportsFolderPath;
        public static string JsonReportsFolderPath = Path.Combine(projectDirectory, "json");
        public static string JsonReportPath = JsonReportsFolderPath;
        public static string ScreenshotPath = Path.Combine(reportsFolderPath, "image");
        public static string resourcesFolderPath = Path.Combine(projectDirectory, "resources");
        public static string DataFolderPath = Path.Combine(resourcesFolderPath, "data");
        public static string costFile = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\resources\data\CostData.xlsx"));
        public static string contractFile = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\resources\data\Contract Document.docx"));
        public static string scheduleFile = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\resources\data\Adkaro Piling Program Baseline.mpp"));
        public static string schedulefileName = "Adkaro Piling Program Baseline";
        public static string costFileName = "CostData";
        public static string projectName = "Mavryck Automation Project";
        public static string contractFileName = "Contract Document";


       

    }
}
