using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;

namespace Mavryck_System.Tests.OptimaResTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]


    public class PatternRecognition_OptimaRes_Test_mavryck : Base
    {

        private IPlaywright playwright;
        private IBrowser browser;
        private IBrowserContext context;
        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            playwright = await PlaywrightConfig.ConfigurePlaywrightAndLaunchBrowser();
            browser = await PlaywrightConfig.LaunchChromiumBrowser(playwright, chromiumExecutablePath, true);
            //step = 0;

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 }
            });

            page = await context.NewPageAsync();  // Initialize page here
        }

        [TearDown]
        public async Task Teardown()
        {
            if (browser != null)
            {
                await browser.CloseAsync();
            }
            playwright?.Dispose();
        }

       


        [Test]
        public async Task PatternRecognition_Verify_TotalFloatIndex_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Total Float Index Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Total Float Index";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Float Index Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyTotalFloat_Index_Map());

                Test.Log(Status.Info, $"Step {++step}: Verify the Bar Chart Title: <b>Total Float Index</b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_TotalFloatIndex_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Resizing Of Total Float Index Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Float Index Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyTotalFloat_Index_Map());


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await OptimaResPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await OptimaResPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_CriticalActivitiesTrending_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Critical Activities Trending Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Critical Activities Trending";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Critical Activities Trending</b>");
                await OptimaResPage_mavryck.ClickOnCriticalActivitiesTrending();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Critical Activities Trending Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyCriticalActivitiesTrendingMap());

                Test.Log(Status.Info, $"Step {++step}: Verify the Bar Chart Title: <b>Critical Activities Trending</b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_CriticalActivitiesTrending_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Resizing Of  Critical Activities Trending Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Critical Activities Trending</b>");
                await OptimaResPage_mavryck.ClickOnCriticalActivitiesTrending();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Critical Activities Trending Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyCriticalActivitiesTrendingMap());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await OptimaResPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await OptimaResPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_SCurve_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The S Curve Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "S Curve Graph";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>S Curve Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifySCurveGraph());

                Test.Log(Status.Info, $"Step {++step}: Verify the Title: <b>S Curve Map </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_SCurve_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Resizing Of S Curve Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Critical Activities Trending</b>");
                await OptimaResPage_mavryck.ClickOnCriticalActivitiesTrending();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Critical Activities Trending Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyCriticalActivitiesTrendingMap());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await OptimaResPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await OptimaResPage_mavryck.VerifyFullScreenOfGridIsDisplaying());



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }



        [Test]
        public async Task PatternRecognition_Verify_NumerOf_DelayEvents_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Number Of Delay Events Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Number of Delay Events";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b>");
                await OptimaResPage_mavryck.ClickOnAnomalies();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Number Of Delay Events Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyNumberOfDelayEventsMap());

                Test.Log(Status.Info, $"Step {++step}: Verify the Bar Chart Title: <b>Number Of Delay Events Map </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }

        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_NumerOf_DelayEvents_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Resizing Of Number Of Delay Events Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b>");
                await OptimaResPage_mavryck.ClickOnAnomalies();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Number Of Delay Events Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyNumberOfDelayEventsMap());


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await OptimaResPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await OptimaResPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_CorrelationHeat_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Correlation HeatMap Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Correlation heat map";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Correlation</b>");
                await OptimaResPage_mavryck.ClickOnCorrelation();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Heat Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyCorrelationHeatMap());

                Test.Log(Status.Info, $"Step {++step}: Verify the Bar Chart Title: <b>Correlation Heat Map </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }

        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_CorrelationHeat_Map()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Resizing Of Correlation HeatMap Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Correlation</b>");
                await OptimaResPage_mavryck.ClickOnCorrelation();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Heat Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyCorrelationHeatMap());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await OptimaResPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await OptimaResPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_CorrelationHeat_Map2()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Correlation HeatMap 2  Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Correlation heat map-2";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Correlation</b>");
                await OptimaResPage_mavryck.ClickOnCorrelation();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Heat Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyCorrelationHeatMap_2());

                Test.Log(Status.Info, $"Step {++step}: Verify the Bar Chart Title: <b>Correlation Heat Map </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_Resizing_Of_CorrelationHeat_Map2()
        {
            var Test = Extent.CreateTest("Optima Res (Pattern Recognition) : Verify The Resizing Of Correlation HeatMap 2 Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Correlation</b>");
                await OptimaResPage_mavryck.ClickOnCorrelation();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Heat Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyCorrelationHeatMap_2());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await OptimaResPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await OptimaResPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }



        [Test]
        public async Task PatternRecognition_Verify_Hover_Feature()
        {
            var Test = Extent.CreateTest("Pattern Recognition: Verify The Hover Feature");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $" *** Hover The  <b> Trends </b> ***");
                await OptimaResPage_mavryck.HoverTrends();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Trends Hover Tooltip </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b> Correlation </b> ***");
                await OptimaResPage_mavryck.HoverCorrelation();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Hover Tooltip </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b> Anomalies </b> ***");
                await OptimaResPage_mavryck.HoverAnomalies();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Anomalies Hover Tooltip </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyHoverTooltip());




            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }



        [Test]
        public async Task PatternRecognition_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Pattern Recognition: Verify The Page Titles With Tooltips");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnPatternRecognition();


                await OptimaResPage_mavryck.VerifyPageTitleWithTooltip_PatternRecognition();
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

