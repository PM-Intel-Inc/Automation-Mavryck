using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;

namespace Mavryck_System.Tests.TimeManagerTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]


    public class OculusDv_mavryck : Base
    {

        private IPlaywright playwright;
        private IBrowser browser;
        private IBrowserContext context;
        private IPage page;
        //private int step;

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
        public async Task Verify_Header_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Verify The Header Requirments Of Oculus DV");
          
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var timeManager = "NeuroDynamiq";
            var appName = "projectManager";

            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(appName);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $" *** Verify The Header Requirments *** ");

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Schedule Quality</b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyScheduleQuality());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>QA Factor </b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyQAFactor());


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project Duration </b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyProjectDuration());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Start Date </b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyStartDate());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Finish Date </b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyFinishDate());


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
        public async Task Verify_TotalFloatIndex_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Verify The Total Float Index Chart Of Oculus DV");            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var timeManager = "NeuroDynamiq";
            var title = "Total Float Index";
            var appName = "projectManager";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(appName);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnOculusDV();
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Bar Chart</b> is visible");
                Assert.True(await OculusDvPage_mavryck.VerifyHeatMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Bar Chart Title: <b>Total Float Index</b> is displaying");
                Assert.True(await OculusDvPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Verify_WordMap_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Verify The Word Map Of Oculus DV");
           
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var timeManager = "NeuroDynamiq";
            var title = "Word map : Reasons of Variance";
            var appName = "projectManager";
            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(appName);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnOculusDV();
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Word Map</b> is visible");
                Assert.True(await OculusDvPage_mavryck.VerifyWordMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Word Map Title: <b>Reason Of Variance</b> is displaying");
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

        [Test]
        public async Task Verify_TaskCatogoriesMap_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Verify The Task Categories Map Of Oculus DV");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var appName = "projectManager";
            var timeManager = "NeuroDynamiq";
            var title = "Task Categories";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(appName);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnOculusDV();
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Task Categories</b> is visible");
                Assert.True(await OculusDvPage_mavryck.VerifyTaskCategoriesIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Task Categories </b> is displaying");
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


        [Test]
        public async Task Verify_CorrelationHeatMap_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Verify The Correlation Heat Map Of Oculus DV");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var appName = "projectManager";
            var timeManager = "NeuroDynamiq";
            var title = "Correlation Heatmap";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(appName);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnOculusDV();
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Heatmap</b> is visible");
                Assert.True(await OculusDvPage_mavryck.VerifyCorrelationHeatmapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Correlation Heatmap </b> is displaying");
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



        [Test]
        public async Task Verify_CriticalActivitiesTrendingMap_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Verify The Critical Activities Trending Map Of Oculus DV");
         
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var appName = "projectManager";
            var timeManager = "NeuroDynamiq";
            var title = "Critical Activities Trending";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(appName);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnOculusDV();
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Critical Activities Trending</b> Map");
                await OculusDvPage_mavryck.ClickOnCriticalActivitiesTrendingMapIsdisplaying();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Critical Activities Trending Map</b> is visible");
                Assert.True(await OculusDvPage_mavryck.VerifyCriticalActivitiesTrendingMapIsdisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Critical Activities Trending </b> is displaying");
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


        [Test]
        public async Task Verify_TaskOverRunsMap_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Verify The Task Over Runs Map Of Oculus DV");
           
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var appName = "projectManager";
            var timeManager = "NeuroDynamiq";
            var title = "Task Over Runs";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnOculusDV();
                await Task.Delay(15000);

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


        [Test]
        public async Task Verify_BowWaveMap_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Verify The Bow Wave Map Of Oculus DV");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var timeManager = "NeuroDynamiq";
            var title = "Bow Wave";
            var appName = "projectManager";
            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(appName);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnOculusDV();
                await Task.Delay(120000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Bow Wave Map</b> is visible");
                Assert.True(await OculusDvPage_mavryck.VerifyBowWaveIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Bow Wave</b> is displaying");
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

        [Test]
        public async Task OculusDV_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Oculus DV:  Verify The Page Titles With Tooltips");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManager = "NeuroDynamiq";
            var appName = "projectManager";
            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(appName);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnOculusDV();

                await TimeManagerPage_mavryck.VerifyPageTitleWithTooltip_OculusDV();
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