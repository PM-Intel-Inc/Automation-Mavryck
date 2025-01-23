

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
    [Order(8)]
    public class GigoTest_mavryck : Base
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
        public async Task Gigo_Verify_TextAllignment_Of_SRNo_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Sr. No.";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

            try
            {
                Test = Extent.CreateTest("Gigo Duration Flaw: Verify The Text Allignment Of Sr No Column");

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
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();

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


        [Test, Order(2)]
        public async Task Gigo_Verify_TextAllignment_Of_ActivityID_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Activity ID";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";
            try
            {
                Test = Extent.CreateTest("Gigo Duration Flaw: Verify The Text Allignment Of Activity ID Column");

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
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();

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


        [Test, Order(3)]
        public async Task Gigo_Verify_TextAllignment_Of_Task_Name_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Task Name";
            var colIndex = "3";

            try
            {
                Test = Extent.CreateTest("Gigo Duration Flaw: Verify The Text Allignment Of Task Name Column");

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
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();

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


        [Test, Order(4)]
        public async Task Gigo_Verify_TextAllignment_Of_Reason_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Reason";
            var colIndex = "4";

            try
            {
                Test = Extent.CreateTest("Gigo Duration Flaw: Verify The Text Allignment Of Reason Column");

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
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();

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


        [Test, Order(5)]
        public async Task Gigo_Verify_TextAllignment_Of_Flag_As_Incorrect_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Flag As Incorrect";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "5";

            try
            {
                Test = Extent.CreateTest("Gigo Duration Flaw: Verify The Text Allignment Of Flag As Incorrect Column");

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
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();


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

        [Test, Order(6)]
        public async Task Gigo_LogicalFlaw_Verify_TextAllignment_Of_SrNO_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Sr. No.";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

            try
            {
                Test = Extent.CreateTest("Gigo Logical Flaw: Verify The Text Alignment Of Flag As Incorrect Column");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));
                Thread.Sleep(10000);



                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Logical Flaw </b>");
                await TimeManagerPage_mavryck.ClickOnGigoLogicalFlaw();

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


        [Test, Order(7)]
        public async Task Gigo_Logical_FlawVerify_TextAllignment_Of_ActivityID_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Activity ID";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";
            try
            {
                Test = Extent.CreateTest("Gigo Logical Flaw: Verify The Text Allignment Of Activity ID Column");

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
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Logical Flaw </b>");
                await TimeManagerPage_mavryck.ClickOnGigoLogicalFlaw();

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


        [Test, Order(8)]
        public async Task Gigo_Logical_flaw_Verify_TextAllignment_Of_Task_Name_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Task Name";
            var colIndex = "3";

            try
            {
                Test = Extent.CreateTest("Gigo Logical Flaw: Verify The Text Allignment Of Task Name Column");

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
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Logical Flaw </b>");
                await TimeManagerPage_mavryck.ClickOnGigoLogicalFlaw();

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


        [Test, Order(9)]
        public async Task Gigo_Logical_Flaw_Verify_TextAllignment_Of_Reason_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Reason";
            var colIndex = "4";

            try
            {
                Test = Extent.CreateTest("Gigo Logical Flaw: Verify The Text Allignment Of Reason Column");

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
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Logical Flaw </b>");
                await TimeManagerPage_mavryck.ClickOnGigoLogicalFlaw();

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


        [Test, Order(10)]
        public async Task Gigo_Logical_flaw_Verify_TextAllignment_Of_Flag_As_Incorrect_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Flag As Incorrect";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "5";

            try
            {
                Test = Extent.CreateTest("Gigo Logical Flaw: Verify The Text Allignment Of Flag As Incorrect Column");

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
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> GIGO </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Logical Flaw </b>");
                await TimeManagerPage_mavryck.ClickOnGigoLogicalFlaw();

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

        [Test, Order(11)]
        public async Task Verify_Requirments_Of_TimeManager_Gigo()
        {

            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page);
            var timeManager = "Time Manager";
            try
            {
                Test = Extent.CreateTest("Verify The Header Requirments Of GIGO");

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
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>GIGO</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();

                Test.Log(Status.Info, $" *** Verify The Grid Icons *** ");
                Assert.True(await TimeManagerPage_mavryck.VerifyDownload_GridIcon());
                Assert.True(await TimeManagerPage_mavryck.VerifyShowHide_GridIcon());
                Assert.True(await TimeManagerPage_mavryck.Verify_FullScreen_GridIcon());
                Assert.True(await TimeManagerPage_mavryck.VerifyIndicators_GridIcon());


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
        public async Task Verify_Hover_Feature_Of_Gigo()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Gigo: Verify The Hover Feature");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu"));
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying"));
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>GIGO</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();
                Thread.Sleep(120000);

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Duration Flaw</b> Of Core ***"));
                await TimeManagerPage_mavryck.HoverDurationFlaw();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Duration Flaw Hover Tooltip </b> is displaying"));
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

                testSteps.AddRange(await TimeManagerPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Logical Flaw</b> Of Core ***"));
                await TimeManagerPage_mavryck.HoverLogicalFlaw();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Logical Flaw Hover Tooltip </b> is displaying"));
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

                await TimeManagerPage_mavryck.ClickOnGigoLogicalFlaw();
                testSteps.AddRange(await TimeManagerPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));

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

        [Test, Order(13)]
        public async Task Verify_Grid_Resizing_Of_DurationFlawGrid_And_LogicalFlaw_Grid()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Gigo: Verify The Duration And Logical Flaw Grid Is Successfully Resized");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>GIGO</b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnGigo();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Duration Flaw Grid ");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await TimeManagerPage_mavryck.VerifyFullScreenOfGridIsDisplaying());
                await TimeManagerPage_mavryck.ClickOnExitFullScreen();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Logical Flaw</b>");
                await TimeManagerPage_mavryck.ClickOnGigoLogicalFlaw();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Logical Flaw Grid ");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
                Thread.Sleep(10000);

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

    }



}