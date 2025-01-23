using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;


namespace Mavryck_TimeManager.Tests
{
    [Order(9)]
    public class ScheduleModeling_Test_mavryck : Base
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
        public async Task ScenarioModeling_Verify_TextAllignment_Of_Name_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Name";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

            try
            {
                Test = Extent.CreateTest("Scenario Modeling:  Verify The Text Allignment Of Name Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Scenario Modeling </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnScenarioModeling();

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
        public async Task ScenarioModeling_Verify_TextAllignment_Of_Status_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Status";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";
            try
            {
                Test = Extent.CreateTest("Scenario Modeling: Verify The Text Allignment Of Status Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Scenario Modeling </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnScenarioModeling();

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
        public async Task ScenarioModeling_Verify_TextAllignment_Of_Description_Column()
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
            var columnName = "Description";
            var colIndex = "3";

            try
            {
                Test = Extent.CreateTest("Scenario Modeling: Verify The Text Allignment Of Description Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Scenario Modeling </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnScenarioModeling();

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
        public async Task ScenarioModeling_Verify_TextAllignment_Of_AssignedTo_Column()
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
            var columnName = "Assigned to";
            var colIndex = "4";

            try
            {
                Test = Extent.CreateTest("Scenario Modeling: Verify The Text Allignment Of Assigned To Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Scenario Modeling </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnScenarioModeling();

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
        public async Task ScenarioModeling_Verify_TextAllignment_Of_Progress_Column()
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
            var columnName = "Progress";
            var colIndex = "4";

            try
            {
                Test = Extent.CreateTest("Scenario Modeling: Verify The Text Allignment Of Progress Column");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Scenario Modeling </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnScenarioModeling();

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
        public async Task Verify_Hover_Feature_Of_ScenarioModeling()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Verify The Hover Feature Of Scenario Modeling");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Scenario Modeling </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnScenarioModeling();

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

        [Test, Order(7)]
        public async Task Verify_Grid_Resizing_Of_ScenarioModeling()
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Duration Flaw Grid ");
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
