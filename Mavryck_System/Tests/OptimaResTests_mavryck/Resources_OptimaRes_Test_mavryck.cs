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

    public class Resources_OptimaRes_Test_mavryck : Base
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
        public async Task Resources_Verify_The_Hover_Feature()
        {
            var Test = Extent.CreateTest("Resources : Verify The Hover Feature");
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();

                Test.Log(Status.Info, $" Hover The  <b>Resource Input </b>");
                await OptimaResPage_mavryck.HoverResourceInput();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Resource Input  Hover Tooltip </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" Hover The  <b>Scheduling </b>");
                await OptimaResPage_mavryck.HoverScheduling();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Scheduling  Hover Tooltip </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyHoverTooltip());


                Test.Log(Status.Info, $" Hover The  <b>Dashboard </b>");
                await OptimaResPage_mavryck.HoverDashboard();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Dashboard  Hover Tooltip </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyHoverTooltip());


                Test.Log(Status.Info, $" Hover The  <b>Workfronts </b>");
                await OptimaResPage_mavryck.HoverWorkfronts();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Workfronts  Hover Tooltip </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyHoverTooltip());

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
        public async Task Resources_Verify_Equipment_Usage_Per_Week_Map()
        {


            var Test = Extent.CreateTest("Resources (Dashboard): Verify The Resources of Cost Performance Map ");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Equipment Usage per Week";
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Dashboard</b>");
                await OptimaResPage_mavryck.ClickOnDashboard();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Equipment Usage Per Week Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.Verify_Equipment_UsagePerWeek());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Equipment Usage Per Week </b> is displaying");
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
        public async Task Resources_Verify_No_Of_Equipments_Per_Task_Map()
        {


            var Test = Extent.CreateTest("Resources (Dashboard): Verify The Number Of Equipments Per Task Map ");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Number of Equipments per Task";
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Dashboard</b>");
                await OptimaResPage_mavryck.ClickOnDashboard();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Number Of Equipments Per Task</b> is visible");
                Assert.True(await OptimaResPage_mavryck.Verify_No_Of_Equipments_PerTask());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b> Number Of Equipments Per Task </b> is displaying");
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
        public async Task Resources_Verify_Resizing_Of_Equipment_Usage_Per_Week_Map()
        {


            var Test = Extent.CreateTest("Resources (Dashboard) : Verify The Resizing Of  Resources Of Cost Performance Map ");
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Dashboard</b>");
                await OptimaResPage_mavryck.ClickOnDashboard();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Equipment Usage Per Week Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.Verify_Equipment_UsagePerWeek());


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
        public async Task Resources_Verify_Resizing_Of_Number_Of_Equipments_Per_Task_Map()
        {


            var Test = Extent.CreateTest("Resources (Dashboard) : Verify The Resizing Of Number Of Equipments Per Task ");
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Dashboard</b>");
                await OptimaResPage_mavryck.ClickOnDashboard();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Number Of Equipments Per Task</b> is visible");
                Assert.True(await OptimaResPage_mavryck.Verify_No_Of_Equipments_PerTask());


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
        public async Task Resources_Verify_TextAllignment_Of_ID_Column()
        {


            var Test = Extent.CreateTest("Resources (Workfronts): Verify The Text Alignment of ID Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "ID";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Workfronts</b>");
                await OptimaResPage_mavryck.ClickOnWorkfronts();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await OptimaResPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await OptimaResPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Resources_Verify_TextAllignment_Of_QA_QA_Resource_Column()
        {


            var Test = Extent.CreateTest("Resources (Workfronts): Verify The Text Alignment of QA/QC Resource Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "QA/QC Resource";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Workfronts</b>");
                await OptimaResPage_mavryck.ClickOnWorkfronts();

                Test.Log(Status.Info, $"Step {++step}: Scroll Down To <b>QA/QC Reosurce Grid</b>");
                await ScrollToElement(page, "//h3[text()='QA/QC Resource']");


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await OptimaResPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await OptimaResPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Resources_Verify_TextAllignment_Of_Availability_Column()
        {


            var Test = Extent.CreateTest("Resources (Workfronts): Verify The Text Alignment of Availability Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Availability";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Workfronts</b>");
                await OptimaResPage_mavryck.ClickOnWorkfronts();

                Test.Log(Status.Info, $"Step {++step}: Scroll Down To <b>QA/QC Reosurce Grid</b>");
                await ScrollToElement(page, "//h3[text()='QA/QC Resource']");


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await OptimaResPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await OptimaResPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Resources_Verify_TextAllignment_Of_Active_Certification_Column()
        {


            var Test = Extent.CreateTest("Resources (Workfronts): Verify The Text Alignment of Active Certification Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Active Certification";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Workfronts</b>");
                await OptimaResPage_mavryck.ClickOnWorkfronts();

                Test.Log(Status.Info, $"Step {++step}: Scroll Down To <b>QA/QC Reosurce Grid</b>");
                await ScrollToElement(page, "//h3[text()='QA/QC Resource']");


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await OptimaResPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await OptimaResPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Resources_Verify_TextAllignment_Of_Next_Available_Date_Column()
        {


            var Test = Extent.CreateTest("Resources (Workfronts): Verify The Text Alignment of Next Available Date Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Next Available Date";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "4";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Workfronts</b>");
                await OptimaResPage_mavryck.ClickOnWorkfronts();

                Test.Log(Status.Info, $"Step {++step}: Scroll Down To <b>QA/QC Reosurce Grid</b>");
                await ScrollToElement(page, "//h3[text()='QA/QC Resource']");


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await OptimaResPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await OptimaResPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Resources_Verify_TextAllignment_Of_Installation_Completion_Column()
        {


            var Test = Extent.CreateTest("Resources (Workfronts): Verify The Text Alignment of Installation Completion Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Installation Completion Column";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "5";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Workfronts</b>");
                await OptimaResPage_mavryck.ClickOnWorkfronts();

                Test.Log(Status.Info, $"Step {++step}: Scroll Down To <b>QA/QC Reosurce Grid</b>");
                await ScrollToElement(page, "//h3[text()='QA/QC Resource']");


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await OptimaResPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await OptimaResPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Resources_Verify_TextAllignment_Of_Workfront_Available_Column()
        {


            var Test = Extent.CreateTest("Resources (Workfronts): Verify The Text Alignment of Workfront Available Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Workfront Available";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "6";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Workfronts</b>");
                await OptimaResPage_mavryck.ClickOnWorkfronts();

                Test.Log(Status.Info, $"Step {++step}: Scroll Down To <b>QA/QC Reosurce Grid</b>");
                await ScrollToElement(page, "//h3[text()='QA/QC Resource']");


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await OptimaResPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await OptimaResPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Resources_Verify_Workfronts_Map()
        {


            var Test = Extent.CreateTest("Resources (Workfronts) : Verify The Workfronts Map ");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var title = "Work Fronts";
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Workfronts</b>");
                await OptimaResPage_mavryck.ClickOnWorkfronts();




                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Workfronts Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.Verify_Workfronts_Map());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Workfronts </b> is displaying");
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
        public async Task Resources_Verify_Resizing_Of_Workfronts_Map()
        {


            var Test = Extent.CreateTest("Resources (Workfronts) : Verify The Resizing Of  Workfronts Map ");
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Workfronts</b>");
                await OptimaResPage_mavryck.ClickOnWorkfronts();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Workfronts Map </b> is visible");
                Assert.True(await OptimaResPage_mavryck.Verify_Workfronts_Map());

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
        public async Task Resources_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Resources:   Verify The Hover Feature");
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resources</b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnResources();
                await Task.Delay(15000);


                await OptimaResPage_mavryck.VerifyPageTitleWithTooltip_Resources();
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