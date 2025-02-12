using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;


namespace Mavryck_TimeManager.Tests.CostBrainTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class PatternRecognition_CostBrainTest_mavryck : Base
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
        public async Task PatternRecognition_BenchMarking_VerifyTheTextAllignmentOf_Metric_Column()
        {
            var Test = Extent.CreateTest("Pattern Recognition Bench Marking: Verify The Text Allignment Of Metric Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Metric";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b>");
                await CostBrainPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



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

        [Test]
        public async Task PatternRecognition_BenchMarking_VerifyTheTextAllignmentOf_UnitOfMeasurement_Column()
        {
            var Test = Extent.CreateTest("Pattern Recognition Bench Marking: Verify The Text Allignment Of Unit Of Measurement Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Unit of Measurement";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b>");
                await CostBrainPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



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

        [Test]
        public async Task PatternRecognition_BenchMarking_VerifyTheTextAllignmentOf_DCMBenchmark_Column()
        {
            var Test = Extent.CreateTest("Pattern Recognition Bench Marking: Verify The Text Allignment Of DCM Bechmark  Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "DCM Benchmark";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b>");
                await CostBrainPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



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

        [Test]
        public async Task PatternRecognition_BenchMarking_VerifyTheTextAllignmentOf_Current_Column()
        {
            var Test = Extent.CreateTest("Pattern Recognition Bench Marking: Verify The Text Allignment Of Current Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Current";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "4";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b>");
                await CostBrainPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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

        [Test]
        public async Task PatternRecognition_BenchMarking_VerifyTheTextAllignmentOf_Savannah_Column()
        {
            var Test = Extent.CreateTest("Pattern Recognition Bench Marking: Verify The Text Allignment Of Savannah Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Savannah";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "4";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b>");
                await CostBrainPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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


        [Test]
        public async Task PatternRecognition_Verify_CurveGraph_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition: Verify The S Curve Graph Chart");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var title = "S-curve";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> S Curve </b>");
                await CostBrainPage_mavryck.ClickOnScurve();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>S Curve Graph</b> is visible");
                Assert.True(await CostBrainPage_mavryck.VerifyCurveGraphIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Graph Title: <b>S Curve Graph</b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyChartNameIsDisplaying(title));

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of S Curve Graph</b>");
                await CostBrainPage_mavryck.ClickOnResizeIcon();
                Assert.True(await CostBrainPage_mavryck.VerifyFullScreenOfGridIsDisplaying2());



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

        [Test]
        public async Task PatternRecognition_Correlation_Verify_HeatMap()
        {
            var Test = Extent.CreateTest("Pattern Recognition Correlation: Verify The Heat Map 1");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var title = "Correlation heat map";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPatternRecognition();
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Correlation </b>");
                await CostBrainPage_mavryck.ClickOnCorrelation();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation HeatMap</b> is visible");
                Assert.True(await CostBrainPage_mavryck.VerifyCorrelationHeatMap());

                Test.Log(Status.Info, $"Step {++step}: Verify the Graph Title: <b>Correlation HeatMap</b> is displaying");
                Assert.True(await CostBrainPage_mavryck.VerifyChartNameIsDisplaying(title));

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of Correlation HeatMap</b>");
                await CostBrainPage_mavryck.ClickOnResizeIcon();
                Assert.True(await CostBrainPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
      
        
        [Test]
        public async Task PatternRecognition_Correlation_Verify_HeatMap2()
        {
            var Test = Extent.CreateTest("Pattern Recognition Correlation: Verify The Heat Map 2");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var title = "Correlation heat map-2";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPatternRecognition();
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Correlation </b>");
                await CostBrainPage_mavryck.ClickOnCorrelation();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation HeatMap</b> is visible");
                Assert.True(await CostBrainPage_mavryck.VerifyCorrelationHeatMap2());

                Test.Log(Status.Info, $"Step {++step}: Verify the Graph Title: <b>Correlation HeatMap</b> is displaying");
                Assert.True(await CostBrainPage_mavryck.VerifyChartNameIsDisplaying(title));

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of Correlation HeatMap</b>");
                await CostBrainPage_mavryck.ClickOnResizeIcon();
                Assert.True(await CostBrainPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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

        [Test]
        public async Task Verify_Hover_Feature_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("Pattern Recognition: Verify The Hover Feature");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPatternRecognition();
                await Task.Delay(15000);

                Test.Log(Status.Info, $" *** Hover The  <b>Pattern Recognition Features</b> ***");
                testSteps = await CostBrainPage_mavryck.Verify_Features_Of_PatternRecognition(step);
                step = testSteps.Count;

                Test.Log(Status.Info, $" *** Hover The  <b>Pattern Recognition Bench Marking Grid</b> ***");
                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b> ");
                await CostBrainPage_mavryck.ClickOnBenchMarking();

                testSteps = await CostBrainPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step);
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of Bechmarking</b>");
                await CostBrainPage_mavryck.ClickOnResizeIcon();
                Assert.True(await CostBrainPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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