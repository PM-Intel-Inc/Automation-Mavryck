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

namespace Mavryck_System.Tests.TimeManagerTests
{

    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class Core_Test_mavryck : Base
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
        public async Task Verify_AllRequirments_Of_NeuroDynamiq()
        {
            var Test = Extent.CreateTest("Verify All The Header Requirements Of NeuroDynamiq");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";

            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Version</b> Icon");
                var version = await TimeManagerPage_mavryck.VerifyVersion();
                Test.Log(Status.Info, $"Step {++step}: <b> Displayed Version is  " + version + "</b>");

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Date</b>");
                var date = await TimeManagerPage_mavryck.VerifyDate();
                Test.Log(Status.Info, $"Step {++step}: <b> Displayed Date is  " + date + "</b>");

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid's Icon</b>");
                Assert.True(await TimeManagerPage_mavryck.VerifyDownload_GridIcon());
                Assert.True(await TimeManagerPage_mavryck.VerifyShowHide_GridIcon());
                Assert.True(await TimeManagerPage_mavryck.Verify_FullScreen_GridIcon());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Available ROV's</b>");
                Assert.True(await TimeManagerPage_mavryck.VerifyAvailable_ROV());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Missing ROV's</b>");
                Assert.True(await TimeManagerPage_mavryck.VerifyMissing_ROV());


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
        public async Task Core_Verify_TextAllignment_Of_ID_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of ID Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var columnName = "ID";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


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


        [Test]
        public async Task Core_Verify_TextAllignment_Of_TaskName_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Task Name Column");
            
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var columnName = "Task Name";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";
            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
             
            

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


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


        [Test]
        public async Task Core_Verify_TextAllignment_Of_StartDate_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Task Name Column");
          
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Start Date";
            var colIndex = "4";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));
               

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


        [Test]
        public async Task Core_Verify_TextAllignment_Of_EndDate_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of End Date Column");
            
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "End Date";
            var colIndex = "5";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


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


        [Test]
        public async Task Core_Verify_TextAllignment_Of_DurationVariance_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Duration Variance Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var columnName = "Duration Variance";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "6";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


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


        [Test]
        public async Task Core_Verify_TextAllignment_Of_ReasonOfVariance_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Reason Of Variance Column");
            
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Reason of Variance";
            var colIndex = "7";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));

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

        [Test]
        public async Task Core_Verify_TextAllignment_Of_TotalFloat_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Total Float Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Total Float";
            var colIndex = "8";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               


                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


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


        [Test]
        public async Task Core_Verify_TextAllignment_Of_EarlyStart_Column()
        {
            var Test = Extent.CreateTest("Verify The Text Allignment Of Early Start Column");
            
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Early Start";
            var colIndex = "9";


            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               


                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();


                await Task.Delay(1000);
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


        [Test]
        public async Task Verify_TextAllignment_Of_EarlyFinish_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Early Finish Column");
           
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Early Finish";
            var colIndex = "10";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


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

        [Test]
        public async Task Core_Verify_TextAllignment_Of_LateStart_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Late Start Column");
           
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Late Start";
            var colIndex = "11";
            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               


                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(1000);

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


        [Test]
        public async Task Verify_TextAllignment_Of_LateFinish_Column()
        {
            var Test = Extent.CreateTest("Verify The Text Allignment Of Late Finish Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Late Finish";
            var colIndex = "12";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));
                await ScrollToElement(page, $"//span[text()='{columnName}']");
               


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


       



        [Test]
        public async Task Verify_Hover_Feature_Of_Core()
        {
            var Test = Extent.CreateTest("Core: Verify The Hover Feature Of Core");
          
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
              

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                 Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Core ***");
                await TimeManagerPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());


                Test.Log(Status.Info, $" *** Hover The  <b>Gantt Chart</b> Of Core ***");
                await TimeManagerPage_mavryck.HoverGanttChart();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Download Button</b> Of Grid ***");
                await TimeManagerPage_mavryck.HoverDownloadButton();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Download Tooltip </b> is displaying");
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Hide/Unhide Button</b> Of Grid ***");
                await TimeManagerPage_mavryck.HoverHideUnHideButton();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Hide/UnHide Button Tooltip </b> is displaying");
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Full Screen</b> Of Grid ***");
                await TimeManagerPage_mavryck.HoverFullScreenButton();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Full Screen Tooltip</b> is displaying");
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

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
        public async Task Verify_Pagination_Of_Core()
        {
            var Test = Extent.CreateTest("Core: Verify The Pagination Of Core ");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var pagination = "50";

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));
               

                Test.Log(Status.Info, $"Step {++step}: Change the <b>Pagination to 50 items per page </b> ");
                await TimeManagerPage_mavryck.SelectPagination(pagination);
               

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>50 items per page </b> is displaying");
                Assert.True(await TimeManagerPage_mavryck.VerifyPagination());


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
        public async Task Verify_Grid_Resizing()
        {
            var Test = Extent.CreateTest("Core: Verify The Grid Is Successfully Resized");
          
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
               
                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));
               

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
               

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
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

        [Test]
        public async Task Core_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Core : Verify The Page Titles With Tooltips");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var actualTitle = "Core";

            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));

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