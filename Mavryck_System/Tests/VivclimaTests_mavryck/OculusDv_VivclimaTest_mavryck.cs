using System;
using System.Collections;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;

namespace Mavryck_System.Tests.VivclimaTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class OculusDv_OptimaRes_Test_mavryck : Base
    {

        private IPlaywright playwright;
        private IBrowser browser;
        private IBrowserContext context;
        private IPage page;

        [SetUp]
        public async Task Setup()
        {
            playwright = await PlaywrightConfig.ConfigurePlaywrightAndLaunchBrowser();
            browser = await PlaywrightConfig.LaunchChromiumBrowser(playwright, chromiumExecutablePath, false);
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
        public async Task Vivclima_Verify_Header_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima : Verify The Header Requirments Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();

            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

             

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $" *** Verify The Header Requirments *** ");

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Percentage Green </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyPercentageGreen());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Industry Average</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyIndustryAverage());


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Carbon Footprint</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyCarbonfootprint());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Carbon Actual </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyCarbonActual());


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Carbon Budget </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyCarbonBudget());


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
        public async Task Vivclima_Verify_TotalCarbonTax_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Total Carbox Tax Map Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Total Carbon Tax";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Carbox Tax Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyCarboxTaxIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Total Carbox Tax</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Vivclima_Verify_MapResizing_Of_TotalCarbonTax_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Map Resizing Of Total Carbox Tax Map Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;



                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Carbox Tax Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyCarboxTaxIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
        public async Task Vivclima_Verify_SCurve_TotalCarbonTax_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The S Curve Total Carbox Tax Map Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Total Carbon Tax";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;



                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> S Curve</b>");
                await VivclimaPage_mavryck.ClickOnScurve();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Carbox Tax Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifySCurveCarboxTaxIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Total Carbox Tax</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Vivclima_Verify_MapResizing_Of_SCurve_TotalCarbonTax_Map_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Map Resizing Of S Curve Total Carbox Tax Map Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> S Curve</b>");
                await VivclimaPage_mavryck.ClickOnScurve();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task Vivclima_Verify_TotalCarbonEmission_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Total Carbox Emission Map Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Total Carbon Emission";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Carbox Emission Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyCarboxEmissionIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Total Carbox Emission</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Vivclima_Verify_MapResizing_TotalCarbonEmission_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Map Resizing Of Total Carbox Emission Map Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


               

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Carbox Emission Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyCarboxEmissionIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task Vivclima_Verify_SCurveTotalCarbonEmission_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The S Curve Of Total Carbon Emission Map Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Total Carbon Emission";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


               

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                await ScrollToElement(page, "//h3[text()='Total Carbon Emission']");
                Test.Log(Status.Info, $"Step {++step}: Click On <b>S Curve</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnScurve();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Carbox Emission Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyCarboxEmissionIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Total Carbox Emission</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Vivclima_Verify_MapResizing_Of_SCurveTotalCarbonEmission_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Map Resizing Of S Curve Of Total Carbon Emission Map Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                await ScrollToElement(page, "//h3[text()='Total Carbon Emission']");
                Test.Log(Status.Info, $"Step {++step}: Click On <b>S Curve</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnScurve();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Carbox Emission Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyCarboxEmissionIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task Viclima_Verify_TornadoEmission_ComparisonChart_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Tornado Emission Comparison Chart Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Tornado Emission Comparison Chart";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

          
                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Tornado Emission Comparison Chart Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyTornadoEmissionComparisonChartIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Tornado Emission Comparison Chart</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Viclima_Verify_MapResizing_Of_TornadoEmission_ComparisonChart_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Map Resizing Of Tornado Emission Comparison Chart Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

             

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Tornado Emission Comparison Chart Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyTornadoEmissionComparisonChartIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());



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
        public async Task Viclima_Verify_TotalEmission_Chart_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Total Emission Chart Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Total Emission";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Emission Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyTotalEmissionChartIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Total Emission</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Viclima_Verify_MapResizing_Of_TotalEmission_Chart_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Map Resizing Of Total Emission Chart Of Oculus DV");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

            

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Emission Map</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyTotalEmissionChartIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


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
        public async Task Vivclima_Verify_Hover_Feature_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Hover Feature Of Oculus Dv");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclimaTitle = "Vivclima";
            byte[] screenshotBytes = null;

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

               

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Oculus DV ***");
                await VivclimaPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyHoverTooltip());

                screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Verified Grid View", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());

            }
            catch (Exception e)
            {
                screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task Vivclima_Verify_PageTitles_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV : Verify The Page Title");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclimaTitle = "Vivclima";
            var actualTitle = "Oculus DV";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

            

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnOculusDV();
                await Task.Delay(20000);

                await CommonFeaturesPage_mavryck.VerifyPageTitleWithTooltip(actualTitle);
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