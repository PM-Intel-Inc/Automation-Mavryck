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


namespace Mavryck_TimeManager.Tests
{
    [Order(10)]
    public class PatternRecognition : Base
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
        public async Task PatternRecognition_BenchMarking_VerifyTheTextAllignmentOf_Tasks_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Tasks";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition Bench Marking: Verify The Text Allignment Of Sr No Column");

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
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();


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
        public async Task PatternRecognition_BenchMarking_VerifyTheTextAllignmentOf_CurrentProject_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Current Project";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition Bench Marking: Verify The Text Allignment Of Current Project  Column");

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
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();


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
        public async Task PatternRecognition_BenchMarking_VerifyTheTextAllignmentOf_Comparable_InHouse_Projects_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Comparable In-House Projects";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition Bench Marking: Verify The Text Allignment Of Comparable In-House Projects  Column");

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
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();


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
        public async Task PatternRecognition_BenchMarking_VerifyTheTextAllignmentOf_Similar_Projects_In_Other_Companies_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Similar Projects In Other Companies";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "4";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition Bench Marking: Verify The Text Allignment Of Similar Projects In Other Companies Column");

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
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();


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
        public async Task PatternRecognition_Verify_TotalFloatIndex_Map()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page);
            var timeManager = "Time Manager";
            var title = "Total Float Index";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition: Verify The Total Float Index Chart");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Float Index</b> is visible");
                Assert.True(await OculusDvPage_mavryck.VerifyBarChartIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Bar Chart Title: <b>Total Float Index</b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyChartNameIsDisplaying(title));

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of Total Float Index</b>");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
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


        [Test, Order(5)]
        public async Task PatternRecognition_Verify_CriticalActivitiesTrendingMap()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page);
            var timeManager = "Time Manager";
            var title = "Critical Activities Trending";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition: Verify The Critical Activities Trending Map");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Critical Activities Trending</b> Map");
                await OculusDvPage_mavryck.ClickOnCriticalActivitiesTrendingMapIsdisplaying();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Critical Activities Trending Map</b> is visible");
                Assert.True(await OculusDvPage_mavryck.VerifyCriticalActivitiesTrendingMapIsdisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Critical Activities Trending </b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyChartNameIsDisplaying(title));

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of Critical Activities Trending</b>");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
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

        [Test, Order(6)]
        public async Task PatternRecognition_Verify_CurveGraph_Map()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page);
            var timeManager = "Time Manager";
            var title = "S Curve Graph";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition: Verify The S Curve Graph Chart");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>S Curve Graph</b> is visible");
                Assert.True(await TimeManagerPage_mavryck.VerifyCurveGraphIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Graph Title: <b>S Curve Graph</b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyChartNameIsDisplaying(title));

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of S Curve Graph</b>");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
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
        public async Task PatternRecognition_Correlation_Verify_HeatMap()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page);
            var timeManager = "Time Manager";
            var title = "Correlation Heatmap-2";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition Correlation: Verify The Heat Map");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Correlation </b>");
                await TimeManagerPage_mavryck.ClickOnCorrelation();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation HeatMap</b> is visible");
                Assert.True(await TimeManagerPage_mavryck.VerifyCorrelationHeatMap());

                Test.Log(Status.Info, $"Step {++step}: Verify the Graph Title: <b>Correlation HeatMap</b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyChartNameIsDisplaying(title));

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of Correlation HeatMap</b>");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
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


        [Test, Order(8)]
        public async Task PatternRecognition_Anomolies_Verify_TaskOverRunsMap()
            
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page);
            var timeManager = "Time Manager";
            var title = "Task Over Runs";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition Anomolies: Verify The Task Over Runs Map");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Anomalies </b>");
                await TimeManagerPage_mavryck.ClickOnAnamolies();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Task Over Runs Map</b> is visible");
                Assert.True(await OculusDvPage_mavryck.VerifyTotalOverRunsIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Task Over Runs </b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyChartNameIsDisplaying(title));

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



        [Test, Order(9)]
        public async Task PatternRecognition_Anomolies_Verify_NumberOfDelayEventsMap()

        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page);
            var timeManager = "Time Manager";
            var title = "Number Of Delay Events";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition Anomolies: Verify The Number Of Delay Events Map");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Anomalies </b>");
                await TimeManagerPage_mavryck.ClickOnAnamolies();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Number Of Delay Events Map</b> is visible");
                Assert.True(await TimeManagerPage_mavryck.VerifyNumberOfDelayEventsGraph());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Number Of Delay Events</b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyChartNameIsDisplaying(title));

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of Number Of Delay Events</b>");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
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



        [Test, Order(10)]
        public async Task Verify_Hover_Feature_Of_PatternRecognition()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Pattern Recognition: Verify The Hover Feature");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPatternRecognition();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $" *** Hover The  <b>Pattern Recognition Features</b> ***");
                testSteps=await TimeManagerPage_mavryck.Verify_Features_Of_PatternRecognition(step);
                step = testSteps.Count;

                Test.Log(Status.Info, $" *** Hover The  <b>Pattern Recognition Bench Marking Grid</b> ***");
                Test.Log(Status.Info, $"Step {++step}: Click On <b> Bench Marking </b> ");
                await TimeManagerPage_mavryck.ClickOnBenchMarking();

                Test.Log(Status.Info, $" *** Hover The  <b>Download Button</b> Of Grid ***");
                testSteps=await TimeManagerPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resizing Of Bechmarking</b>");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
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

    }
}