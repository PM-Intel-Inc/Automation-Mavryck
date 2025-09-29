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

    public class Andon_OptimaRes_Test_mavryck : Base
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
        public async Task Andon_Verify_Hover_Feature()
        {
            var Test = Extent.CreateTest("Andon: Verify The Hover Feature");
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();

                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Andon ***");
                await OptimaResPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await OptimaResPage_mavryck.VerifyHoverTooltip());


                await OptimaResPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover();

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
        public async Task Andon_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Andon : Verify The Page Titles With Tooltips");
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();



                await OptimaResPage_mavryck.VerifyPageTitleWithTooltip_Andon();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

   

        [Test]
        public async Task Andon_Verify_Overveiw_GridResizing()
        {
            var Test = Extent.CreateTest("Andon:  Verify The Overview Grid Resizing");
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



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
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
        public async Task Andon_Verify_TextAllignment_Of_ID_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of ID Column");
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_TaskName_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Task Name Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Task Name";
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_Start_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Start Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Start";
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_Finish_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Finish Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Finish";
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_Duration_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Duration Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Duration";
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



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_RemainingDuration_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Remaining Duration Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Remaining Duration";
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_Critical_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Critical Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Critical";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "7";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_BaselineDuration_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Baseline Duration Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Baseline Duration";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "8";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_EarlyStart_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Early Start Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Early Start";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "9";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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

        public async Task Andon_Verify_TextAllignment_Of_EarlyFinish_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Early Finish Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Early Finish";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "10";

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



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();

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
        public async Task Andon_Verify_TextAllignment_Of_LateStart_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Late Start Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Late Start";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "11";

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



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_LateFinish_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Late Finish Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Late Finish";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "12";

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



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_ActualStart_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Actual Start Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Actual Start";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "13";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_ActualFinish_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Actual Finish Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Actual Finish";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "14";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();
                await Task.Delay(10000);


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
        public async Task Andon_Verify_TextAllignment_Of_ActualDurationColumn()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Actual Duration Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Actual Duration";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "15";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_Milestone_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Milestone Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "MileStone";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "16";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_ParentTask_ActivityID_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Parent Task Activity Id Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Parent Task Activity Id";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "17";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_ParentTask_Name_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Parent Task Name Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Parent Task Name";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "18";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_ParentTask_UniqueId_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Parent Task Unique Id Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Parent Task Unique Id";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "19";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_SequenceNumber_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Sequence Number Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Sequence Number";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "20";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_Summary_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Summary Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Summary";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "21";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_TotalFloat_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Total Float Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Total Float";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "22";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_UpdateNumber_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of Update Number Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "Update Number";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "23";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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
        public async Task Andon_Verify_TextAllignment_Of_WBS_Column()
        {


            var Test = Extent.CreateTest("Andon:  Verify The Text Alignment Of WBS Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var OptimaResPage_mavryck = new OptimaResPage_mavryck(page, Test);
            var OptimaRes = "OptimaRes";
            var columnName = "WBS";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "24";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon </b> From Side Nav Menu");
                await OptimaResPage_mavryck.ClickOnAndon();


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









    }
}