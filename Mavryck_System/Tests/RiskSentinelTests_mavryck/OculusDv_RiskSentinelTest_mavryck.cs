using System;
using System.Collections;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;

namespace Mavryck_System.Tests.RiskSentinelTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class OculusDv_RiskSentinelTest_mavryck : Base
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
        public async Task RiskSentinel_Verify_Contingencies_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Contingencies Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var title = "Contingecy Draw Down";
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;



                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Contingencies Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyContingenciesDrawDownMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Contingencies</b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task RiskSentinel_Verify_MapResizing_Of_Contingencies_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of Contingencies Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Contingencies Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyContingenciesDrawDownMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await RiskSentinelPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await RiskSentinelPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task RiskSentinel_Verify_QRA_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The QRA Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var title = "QRA";
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> QRA Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyQRAMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>QRA</b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task RiskSentinel_Verify_MapResizing_Of_QRA_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of QRA Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> QRA Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyQRAMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await RiskSentinelPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await RiskSentinelPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task RiskSentinel_Verify_Phase_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Phase Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var title = "Phase";
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Phase Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyPhaseMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Phase</b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task RiskSentinel_Verify_MapResizing_Of_Phase_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of Phase Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Phase Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyPhaseMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await RiskSentinelPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await RiskSentinelPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task RiskSentinel_Verify_Exposure_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Exposure Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var title = "Exposure";
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Exposure Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyExposureMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Exposure</b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task RiskSentinel_Verify_MapResizing_Of_Exposure_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of Exposure Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Exposure Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyExposureMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await RiskSentinelPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await RiskSentinelPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task RiskSentinel_Verify_OpenActions_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Exposure Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var title = "Open Actions";
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Open Actions Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyOpenActionsMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Open Actions</b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task RiskSentinel_Verify_MapResizing_Of_OpenActions_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of OpenActions Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Open Actions Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyOpenActionsMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await RiskSentinelPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await RiskSentinelPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task RiskSentinel_Verify_Classifications_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Classifications Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var title = "Classification";
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Classification Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyClassificationMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Classification</b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task RiskSentinel_Verify_MapResizing_Of_Classifications_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Map Resizing Of Classifications Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Classification Map</b> is visible");
                Assert.True(await RiskSentinelPage_mavryck.VerifyClassificationMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await RiskSentinelPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await RiskSentinelPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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