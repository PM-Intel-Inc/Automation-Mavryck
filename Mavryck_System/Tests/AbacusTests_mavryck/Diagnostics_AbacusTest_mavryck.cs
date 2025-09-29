using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_System.Pages;
using Mavryck_System.Utils;
using System;
using System.Threading.Tasks;
using PlanNotePlaywrite;
using System.Threading;
using System.Collections;

namespace Mavryck_System.Tests.AbacusTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class Diagnostics_AbacusTest_mavryck : Base
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
        public async Task Diagnostics_Verify_Cost_Variance_OverTime_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Cost Variance Over Time Map Is Displaying");
            int step = 0;
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var testSteps = new ArrayList();
            var abacusTitle = "Abacus";
            var title = "Cost Variance Over Time";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Cost Variance Over Time Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyCostVarianceOverTime());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Cost Variance Over Time Map </b> is displaying");
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
        public async Task Abacus_Verify_MapResizing_Of_Cost_Variance_OverTime_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Map Resizing Of Cost Variance OverTime Map");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Cost Variance Over Time Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyCostVarianceOverTime());


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
        public async Task Diagnostics_Verify_Schedule_Variance_OverTime_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Schedule Variance Over Time Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";
            var title = "Schedule Variance Over Time";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();
                

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Schedule Variance Over Time Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyScheduleVarianceOverTime());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Schedule Variance Over Time Map </b> is displaying");
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
        public async Task Diagnostics_Verify_MapResizing_Of_Schedule_Variance_OverTime_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Map Resizing Of Schedule Variance Over Time Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Schedule Variance Over Time Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyScheduleVarianceOverTime());

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
        public async Task Diagnostics_Verify_Cost_Overrun_Predictions_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Cost Overrun Predictions Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";
            var title = "Cost Overrun Predictions";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Cost Overrun Predictions Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyCostOverrunPredictions());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Cost Overrun Predictions Map </b> is displaying");
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
        public async Task Diagnostics_Verify_MapResizing_Of_Cost_Overrun_Predictions_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Map Resizing Of Cost Overrun Predictions Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Cost Overrun Predictions Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyCostOverrunPredictions());

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
        public async Task Diagnostics_Verify_Forecast_Accuracy_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Forecast Accuracy Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";
            var title = "Forecast Accuracy";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Forecast Accuracy Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyForecastAccuracy());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Forecast Accuracy Map </b> is displaying");
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
        public async Task Diagnostics_Verify_MapResizing_Of_Forecast_Accuracy_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Map Resizing Of Forecast Accuracy Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Forecast Accuracy Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyForecastAccuracy());

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
        public async Task Diagnostics_Verify_Labour_Resource_Constraints_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Labour Resource Constraints Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";
            var title = "Labor Resource Constraints";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Labour Resource Constraints Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyLabourResourceConstraints());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Labour Resource Constraints Map </b> is displaying");
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
        public async Task Diagnostics_Verify_MapResizing_Of_Labour_Resource_Constraints_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Map Resizing Of  Labour Resource Constraints Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Labour Resource Constraints Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyLabourResourceConstraints());

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
        public async Task Diagnostics_Verify_Material_Resource_Constraints_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Material Resource Constraints Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";
            var title = "Material Resource Constraints";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Material Resource Constraints Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyMaterialResourceConstraints());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Material Resource Constraints Map </b> is displaying");
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
        public async Task Diagnostics_Verify_MapResizing_Of_Material_Resource_Constraints_Map()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Map Resizing Of Material Resource Constraints Map Is Displaying");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Material Resource Constraints Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyMaterialResourceConstraints());

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
        public async Task Predictions_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Predictions:  Verify The Page Titles With Tooltips");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacusTitle = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnDiagnostics();

                Test.Log(Status.Info, "Verify the <b> Over View Icon Tooltip  With Page Title</b> ");
                await AbacusPage_mavryck.HoverGridView();

                byte[] screenshotBytes = await page.ScreenshotAsync();
                var tooltip = await AbacusPage_mavryck.GetTootlTipText();
                var pagetitleText = await AbacusPage_mavryck.GetPageTitleText();
                if (tooltip.Equals(pagetitleText))
                {
                    Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                    Test.Pass("Verified OverView ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                }
                else
                {
                    Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                    Test.Fail("Verified OverView", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                }
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