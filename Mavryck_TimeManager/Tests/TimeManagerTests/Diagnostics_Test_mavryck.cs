using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using System;
using System.Threading.Tasks;
using PlanNotePlaywrite;
using System.Threading;
using System.Collections;

namespace Mavryck_TimeManager.Tests
{
    [Order(11)]
    public class Diagnostics_Test_mavryck : Base
    {
        private IPlaywright playwright;
        private IBrowser browser;
        private IBrowserContext context;
        private int step;
        ArrayList testSteps;


        [SetUp]
        public async Task Setup()
        {
            playwright = await PlaywrightConfig.ConfigurePlaywrightAndLaunchBrowser();
            browser = await PlaywrightConfig.LaunchChromiumBrowser(playwright, chromiumExecutablePath, false);
            step = 0;
            testSteps = new ArrayList();

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });
        }

        [TearDown]
        public async Task Teardown()
        {
            await browser.CloseAsync();
        }

        [Test, Order(1)]
        public async Task Diagnostics_Verify_TextAllignment_Of_ID_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "ID";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

            try
            {
                Test = Extent.CreateTest("Diagnostics: Verify The Text Allignment Of ID Column");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await TimeManagerPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        [Test, Order(2)]
        public async Task Diagnostics_Verify_TextAllignment_Of_Criteria_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Criteria";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";

            try
            {
                Test = Extent.CreateTest("Diagnostics: Verify The Text Allignment Of Criteria Column");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await TimeManagerPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        [Test, Order(3)]
        public async Task Diagnostics_Verify_TextAllignment_Of_Baseline_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Baseline";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";

            try
            {
                Test = Extent.CreateTest("Diagnostics: Verify The Text Allignment Of Baseline Column");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await TimeManagerPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        [Test, Order(4)]
        public async Task Diagnostics_Verify_Hover_Feature_Of_ScheduleQualityIndex()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Diagnostics: Verify The Hover Feature Of Schedule Quality Index");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnDiagnostics();


                testSteps.AddRange(await TimeManagerPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }



        [Test, Order(5)]
        public async Task Diagnostics_Verify_DeepAnalysis_Report()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Diagnostics: Verify The Deep Analysis Report ");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu"));
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying"));
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu"));
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Deep Analysis </b>"));
                await TimeManagerPage_mavryck.ClickOnDeepAnalysis();

                testSteps.Add(Test.Log(Status.Info, $" <b> **** Wait For Few Seconds (Report is generating ) ****"));
                Thread.Sleep(100000);
                testSteps.AddRange(await TimeManagerPage_mavryck.VerifyDeepAnalysisReport(step));



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        [Test, Order(6)]
        public async Task Diagnostics_Verify_HoverFeature_Of_Complaince()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Diagnostics: Verify The Hover Feature Of Complaince");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu"));
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying"));
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu"));
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Complaince </b>"));
                await TimeManagerPage_mavryck.ClickOnComplaince();

                testSteps.AddRange(await TimeManagerPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await TimeManagerPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }



        [Test, Order(7)]
        public async Task Diagnostics_Verify_ContractAnalyzer_Report()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Diagnostics: Verify The Contract Analyzer Report ");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu"));
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying"));
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu"));
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Contract Analyzer </b>"));
                await TimeManagerPage_mavryck.ClickOnContractAnalysis();

                testSteps.Add(Test.Log(Status.Info, $" <b> **** Wait For Few Seconds (Report is generating ) ****"));
                Thread.Sleep(100000);
                Assert.True(await TimeManagerPage_mavryck.VerifyContractAnalysisReport(step));



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        [Test, Order(8)]
        public async Task Diagnostics_Verify_ReportAnalyzer_Report()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Diagnostics: Verify The Report Analyzer Report ");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu"));
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying"));
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu"));
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Report Analyzer </b>"));
                await TimeManagerPage_mavryck.ClickOnReportAnalysis();

                testSteps.Add(Test.Log(Status.Info, $" <b> **** Wait For Few Seconds (Report is generating ) ****"));
                Thread.Sleep(100000);
                Assert.True(await TimeManagerPage_mavryck.VerifyReportAnalysisReport(step));



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }



    }
}