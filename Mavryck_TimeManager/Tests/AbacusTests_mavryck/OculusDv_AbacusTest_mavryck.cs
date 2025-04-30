using System;
using System.Collections;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;

namespace Mavryck_System.Tests.AbacusTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class OculusDv_AbacusTest_mavryck : Base
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

            page = await context.NewPageAsync();
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
        public async Task Abacus_Verify_Header_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV : Verify The Header Requirments");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $" *** Verify The Header Requirments *** ");

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Estimate  Quality <b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyEstimateQuality());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Class </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyClass());


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Margin</b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyMargin());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Finish Date </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyFinishDate());



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
        public async Task Abacus_Verify_Contingencies_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Contingencies Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var title = "Contingencies";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Contingencies Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyContingenciesMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Contingencies</b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Abacus_Verify_MapResizing_Of_Contingencies_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of Contingencies Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Contingencies Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyContingenciesMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task Abacus_Verify_ClassEstimate_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Class Estimate Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var title = "Class Estimate";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Class Estimate Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyClassEstimate());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Class Estimate </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Abacus_Verify_MapResizing_Of_ClassEstimate_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of Class Estimate Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Class Estimate Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyClassEstimate());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task Abacus_Verify_EsitmateAnomalies_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Estimate Anomalies Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var title = "Estimates Anomalies";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Estimate Anomalies Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyClassAnomalies());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Estimate Anomalies </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Abacus_Verify_MapResizing_Of_EstimateAnomalies_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of Estimate Anomalies Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Estimate Anomalies Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyClassAnomalies());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task Abacus_Verify_NumberOfDelayEvents_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Number Of Delay Events Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var title = "Number of Delay Events";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Scroll Down To <b>Estimate Anomalies </b>");
                await ScrollToElement(page, "//h3[text()='Estimates Anomalies']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Number Of Delay Events Map</b>");
                await AbacusPage_mavryck.ClickOnNumberOfDelayEvents();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Number Of Delay Events Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyClassAnomalies_NumberOfDelayEvents());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Number Of Delay Events Map </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Abacus_Verify_MapResizing_Of_NumberOfDelayEvents_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of Number Of Delay Events Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Scroll Down To <b>Estimate Anomalies </b>");
                await ScrollToElement(page, "//h3[text()='Estimates Anomalies']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Number Of Delay Events Map</b>");
                await AbacusPage_mavryck.ClickOnNumberOfDelayEvents();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Number Of Delay Events Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyClassAnomalies_NumberOfDelayEvents());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task Abacus_Verify_BowWave_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Number Of Delay Events Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var title = "Bow Wave";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Bow Wave Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyBowWaveMap());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Bow Wave Map </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Abacus_Verify_MapResizing_Of_BowWave_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of Number Of Delay Events Map");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Bow Wave Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyBowWaveMap());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task Abacus_Verify_Hover_Feature_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Hover Feature");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Oculus DV ***");
                await AbacusPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Verified Grid View", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());

            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task Abacus_Verify_PageTitles_WithTooltips_OF_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV : Verify The Page Titles With Tooltips");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnOculusDV();


                await AbacusPage_mavryck.VerifyPageTitleWithTooltip_OculusDV();
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