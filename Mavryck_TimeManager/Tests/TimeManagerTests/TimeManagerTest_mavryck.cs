using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using System;
using System.Threading.Tasks;
using PlanNotePlaywrite;
using System.Threading;
using System.Collections;

namespace Mavryck_TimeManager.Tests
{
    [Order(4)]
    public class TimeManagerTest_mavryck : Base
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
        public async Task Verify_Requirments_Of_TimeManager_CORE()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            
            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of ID Column");

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

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Version</b> Icon");
                Assert.True(await TimeManagerPage_mavryck.VerifyVersion());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Date</b>");
                Assert.True(await TimeManagerPage_mavryck.VerifyDate());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Add File</b> Button");
                Assert.True(await TimeManagerPage_mavryck.VerifyAdd_File_Button());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Users</b> Button");
                Assert.True(await TimeManagerPage_mavryck.VerifyAdd_Member());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Activities Grid</b>");
                Assert.True(await TimeManagerPage_mavryck.VerifyActivity_Grid());

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



        [Test, Order(2)]
        public async Task Verify_TextAllignment_Of_ID_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var columnName = "ID";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of ID Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>ID</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Task Name : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left  , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>ID</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Task Name : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right  , colIndex));

                Test.Log(Status.Info, $"Step {++step}:  Select <b> Center </b> Text Allignment Of  <b>ID</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Task Name : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center , colIndex ));


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
        public async Task Verify_TextAllignment_Of_TaskName_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var columnName = "Task Name";
            var textAllig_left = "Left";
            var textAllig_right = "Right"; 
            var textAllig_center = "Center";
            var colIndex = "3";
            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of Task Name Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b> Task Name </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Task Name : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left, colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b> Task Name </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Task Name : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right, colIndex));

                Test.Log(Status.Info, $"Step {++step}:  Select <b> Center </b> Text Allignment Of  <b> Task Name </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Task Name : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center , colIndex));


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
        public async Task Verify_TextAllignment_Of_StartDate_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Start Date";
            var colIndex = "4";

            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of Start Date Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b> Start Date </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left  , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b> Start Date </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right  , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b> Start Date </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center, colIndex));


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
        public async Task Verify_TextAllignment_Of_EndDate_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "End Date";
            var colIndex = "5";

            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of End Date Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b> End Date </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>End Date : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left  , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b> End Date </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right  ,colIndex
                    ));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b> End Date </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center  , colIndex));


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
        public async Task Verify_TextAllignment_Of_DurationVariance_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var columnName = "Duration Variance";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "6";

            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of Duration Variance Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b> Duration Variance </b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>End Date : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left  , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b> Duration Variance</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName , textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b> Duration Variance</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName , textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center ,colIndex));


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
        public async Task Verify_TextAllignment_Of_ReasonOfVariance_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Reason of Variance";
            var colIndex = "7";
                
            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of Reason Of Variance Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>Reason Of Variance</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>End Date : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>Reason Of Variance</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right  ,colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>Reason Of Variance</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center  ,colIndex));


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
        public async Task Verify_TextAllignment_Of_TotalFloat_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Total Float";
            var colIndex = "8";

            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of Total Float Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>Reason Of Variance</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>End Date : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left  ,colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>Reason Of Variance</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right  , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>Reason Of Variance</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center ,colIndex));


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
        public async Task Verify_TextAllignment_Of_EarlyStart_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Early Start";
            var colIndex = "9";


            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of Early Start Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>Early Start</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>End Date : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left  , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>Early Start</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right, colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>Early Start</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center, colIndex));

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
        public async Task Verify_TextAllignment_Of_EarlyFinish_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Early Finish";
            var colIndex = "10";

            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of Early Finish Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>Early Finish</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>End Date : LEFT</b> ");
                await ScrollToElement(page, columnName);
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>Early Finish</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right  , colIndex) );

                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>Early Finish</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center  ,colIndex));


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

        [Test, Order(11)]
        public async Task Verify_TextAllignment_Of_LateStart_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Late Start";
            var colIndex = "11";
            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of Late Start Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>Late Start</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>End Date : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>Late Start</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right , colIndex));

                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>Late Start</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center , colIndex));


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


        [Test, Order(12)]
        public async Task Verify_TextAllignment_Of_LateFinish_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Late Finish";
            var colIndex = "12";

            try
            {
                Test = Extent.CreateTest("Verify The Text Allignment Of Late Finish Column");

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
                await ScrollToElement(page, $"//span[text()='{columnName}']");
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>Late Finish</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left) ;


                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>End Date : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left  , colIndex));


                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>Late Finish</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right) ;

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right , colIndex));


                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>Late Finish</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center, colIndex));

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


        [Test, Order(12)]
        public async Task Verify_RequirementsOf_SideNavMenu()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = " Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Late Finish";
            var colIndex = "12";

            try
            {
                Test = Extent.CreateTest("Verify The Requirements Of Side Navigation Requirements Of Time Manager CORE");

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
                await ScrollToElement(page, $"//span[text()='{columnName}']");
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await TimeManagerPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>Late Finish</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_left);


                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>End Date : LEFT</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_left, colIndex));


                Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>Late Finish</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_right);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>Start Date : Right</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_right, colIndex));


                Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>Late Finish</b>");
                await TimeManagerPage_mavryck.SelectAllignment(columnName, textAllig_center);

                Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment Of <b>Start Date : Center</b> ");
                Assert.True(await TimeManagerPage_mavryck.VerifyTextAlign(textAllig_center, colIndex));

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