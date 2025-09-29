using System;
using System.Collections;
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
        public async Task OculusDV_Verify_Header_Requirements()
        {
            var Test = Extent.CreateTest(" Oculus DV : Verify The Hover Feature");
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Optima Res </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOptimaRes();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromMenu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $" *** Verify The Header Requirments *** ");

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> No Of Waiting Resources </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyNo_of_WaitingResources());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>No Of Waiting Workfront</b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyNo_of_Workfront());


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Total Salary Of Resources</b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifySalaryOfResources());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Forecasted Date </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyForecastedDate());



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
        public async Task OculusDV_Verify_Resources_Of_CostPerformance_Map()
        {


            var Test = Extent.CreateTest("Oculus DV : Verify The Resources of Cost Performance Map ");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Resources of Cost Performance";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Resources of Cost Performance Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.Verify_Resources_Of_Cost_Performance());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Resources of Cost Performance Map </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task OculusDV_Verify_TaskCategories_Map()
        {


            var Test = Extent.CreateTest("Oculus DV : Verify The Task Categories Map ");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Task Categories";
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Task Categories Map</b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyTaskChart_Map());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Task Categories Map </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task OculusDV_Verify_Resources_Active_Workload_Map()
        {


            var Test = Extent.CreateTest("Oculus DV : Verify The Resources Active Workload Map ");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Resource Active Workload";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Optima Res </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOptimaRes();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromMenu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Resources Active Workload</b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyResources_Active_Workload_Map());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Resources Active Workload </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task OculusDV_Verify_Resizing_Of_Resources_Of_CostPerformance_Map()
        {


            var Test = Extent.CreateTest("Oculus DV : Verify The Resizing Of  Resources Of Cost Performance Map ");
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Optima Res </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOptimaRes();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromMenu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Resources of Cost Performance Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.Verify_Resources_Of_Cost_Performance());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await OptimaResPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await OptimaResPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
        public async Task OculusDV_Verify_ResizingOf_Task_Categories_Map()
        {


            var Test = Extent.CreateTest("Oculus DV : Verify The Resizing Of  Task Categories  Map ");
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Task Categories Map</b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyTaskChart_Map());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await OptimaResPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await OptimaResPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
        public async Task OculusDV_Verify_Resizing_Of_Resources_Active_Workload_Map()
        {


            var Test = Extent.CreateTest("Oculus DV : Verify The  Resizing Of Resources Active Workload Map ");
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Optima Res </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOptimaRes();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Optima Res </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromMenu(OptimaRes);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Optime Res App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(OptimaRes));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnOculusDV();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Resources Active Workload</b> is visible");
                Assert.True(await OptimaResPage_mavryck.VerifyResources_Active_Workload_Map());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await OptimaResPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await OptimaResPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
        public async Task OptimaRes_Verify_Hover_Feature_Of_OculusDV()
        {
            var Test = Extent.CreateTest("Oculus DV: Verify The Hover Feature");
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnOculusDV();


                Test.Log(Status.Info, $" *** Hover The  <b>Overview </b> Of Core ***");
                await OptimaResPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Overview  Hover Tooltip </b> is displaying");
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
        public async Task OculusDV_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Oculus DV:  Verify The Hover Feature");
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Oculus DV</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnOculusDV();


                await OptimaResPage_mavryck.VerifyPageTitleWithTooltip_OculusDV();
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