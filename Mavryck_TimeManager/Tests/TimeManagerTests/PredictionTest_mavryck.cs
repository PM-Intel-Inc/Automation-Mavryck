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
    [Order(10)]
    public class PredictionTest_mavryck : Base
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
        public async Task Predictions_CompletionGrid_VerifyTheTextAllignmentOf_Tasks_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "TaskName";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

            try
            {
                Test = Extent.CreateTest("Predictions Completion Grid: Verify The Text Allignment Of TaskName Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(120000);

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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_BaselineDuration_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Baseline Duration";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";

            try
            {
                Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Baseline Duration Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(120000);


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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Remaining_Duration_Current_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Remaining Duration Current";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";

            try
            {
                Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Remaining Duration Current Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(120000);

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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Current_Finish_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Current Finish";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "4";

            try
            {
                Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Current Finish Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(120000);

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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Critical_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Critical";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "5";

            try
            {
                Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Critical Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(120000);

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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Optimal_Bias_Check_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Optimal Bias Check";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "6";

            try
            {
                Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Optimal Bias Check Column");

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
                
                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(120000);

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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Predicted_Remaining_Duration_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Predicted Remaining Duration";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "7";

            try
            {
                Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Predicted Remaining Duration Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(120000);

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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Predicted_Finish_Date_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Predicted Finish Date";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "8";

            try
            {
                Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Predicted Finish Date Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();
                Thread.Sleep(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(120000);


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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Insights_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Insights";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "9";

            try
            {
                Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Insights Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnCompletionGrid(); 
                Thread.Sleep(120000);


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
        public async Task Verify_Hover_Feature_Of_Prediction()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Prediction: Verify The Hover Feature");

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();


                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Probabilities </b> Of Predictions ***"));
                await TimeManagerPage_mavryck.HoverDurationFlaw();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Probabilities Hover Tooltip </b> is displaying"));
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());


                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Completion Grid </b> Of Predictions ***"));
                await TimeManagerPage_mavryck.HoverCompletionGrid();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Completion Grid Hover Tooltip </b> is displaying"));
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

                testSteps.AddRange(await TimeManagerPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Prognosis </b> Of Predictions ***"));
                await TimeManagerPage_mavryck.HoverPrognosis();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Prognosis Hover Tooltip </b> is displaying"));
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Recovery Schedule </b> Of Predictions ***"));
                await TimeManagerPage_mavryck.HoverRecoverySchedule();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Recovery Schedule Hover Tooltip </b> is displaying"));
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Change Orders </b> Of Predictions ***"));
                await TimeManagerPage_mavryck.HoverChangeOrders();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Change Orders Hover Tooltip </b> is displaying"));
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());

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


        [Test, Order(11)]
        public async Task Prediction_ChangeOrders_VerifyTheTextAllignmentOf_ChangeOrderRef_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Change Order Ref #";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";

            try
            {
                Test = Extent.CreateTest("Prediction Change Orders: Verify The Text Allignment Of Change Orders Ref Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Change Orders </b>");
                await TimeManagerPage_mavryck.ClickOnChangeOrders();
                Thread.Sleep(120000);


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

        [Test, Order(12)]
        public async Task Prediction_ChangeOrders_VerifyTheTextAllignmentOf_Project_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Project #";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";

            try
            {
                Test = Extent.CreateTest("Prediction Change Orders: Verify The Text Allignment Of Project # Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Change Orders </b>");
                await TimeManagerPage_mavryck.ClickOnChangeOrders();
                Thread.Sleep(120000);


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

        [Test, Order(13)]
        public async Task Prediction_ChangeOrders_VerifyTheTextAllignmentOf_ProjectName_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Project Name";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";

            try
            {
                Test = Extent.CreateTest("Prediction Change Orders: Verify The Text Allignment Of Project Name Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Change Orders </b>");
                await TimeManagerPage_mavryck.ClickOnChangeOrders();
                Thread.Sleep(120000);


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


        [Test, Order(14)]
        public async Task Prediction_ChangeOrders_VerifyTheTextAllignmentOf_ChangeOrderDescription_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Change Order Description";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "4";

            try
            {
                Test = Extent.CreateTest("Prediction Change Orders: Verify The Text Allignment Of Change Orders Description Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Change Orders </b>");
                await TimeManagerPage_mavryck.ClickOnChangeOrders();
                Thread.Sleep(120000);


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


        [Test, Order(15)]
        public async Task Prediction_ChangeOrders_VerifyTheTextAllignmentOf_PredictedProbability_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Predicted Probability";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "5";

            try
            {
                Test = Extent.CreateTest("Prediction Change Orders: Verify The Text Allignment Of Predicted Probability Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Change Orders </b>");
                await TimeManagerPage_mavryck.ClickOnChangeOrders();
                Thread.Sleep(120000);


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

        [Test, Order(16)]
        public async Task Prediction_ChangeOrders_VerifyTheTextAllignmentOf_CostImpact_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Cost Impace ($)";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "6";

            try
            {
                Test = Extent.CreateTest("Prediction Change Orders: Verify The Text Allignment Of Cost Impact ($) Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Change Orders </b>");
                await TimeManagerPage_mavryck.ClickOnChangeOrders();
                Thread.Sleep(120000);


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

        [Test, Order(17)]
        public async Task Prediction_ChangeOrders_VerifyTheTextAllignmentOf_ScheduleImpactDays_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Schedule Impact (days)";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "7";

            try
            {
                Test = Extent.CreateTest("Prediction Change Orders: Verify The Text Allignment Of Schedule Impact Days Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Change Orders </b>");
                await TimeManagerPage_mavryck.ClickOnChangeOrders();
                Thread.Sleep(120000);


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


        [Test, Order(18)]
        public async Task Prediction_ChangeOrders_VerifyTheTextAllignmentOf_ImpactCostTime_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "Impact (Cost/Time)";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "7";

            try
            {
                Test = Extent.CreateTest("Prediction Change Orders: Verify The Text Allignment Of Impact (Cost/Time) Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Change Orders </b>");
                await TimeManagerPage_mavryck.ClickOnChangeOrders();
                Thread.Sleep(120000);


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

        [Test, Order(19)]
        public async Task Prediction_ChangeOrders_VerifyTheTextAllignmentOf_HighLevelMitigationPlans_Column()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";
            var columnName = "High Level Mitigation Plans";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "8";

            try
            {
                Test = Extent.CreateTest("Prediction Change Orders: Verify The Text Allignment Of High Level Mitigation Plans Column");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Change Orders </b>");
                await TimeManagerPage_mavryck.ClickOnChangeOrders();
                Thread.Sleep(120000);


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



        [Test, Order(20)]
        public async Task Verify_AI_Prediction_Of_CompletionProbability()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Verify Prediction");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict </b>");
                await TimeManagerPage_mavryck.CLickOnPredictButton();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Tick </b>");
                await TimeManagerPage_mavryck.CLickOnYesPredictButton();
                Thread.Sleep(100000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Completion Probability Mavryck Prediction </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyMavryckPrediction());


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


        [Test, Order(21)]
        public async Task Verify_AI_Prediction_Of_ClaimProbability()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Verify Prediction Of Claim Probability");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));
                
                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                await ScrollToElement(page, $"//h3[text()='Claim Probability']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict </b>");
                await TimeManagerPage_mavryck.CLickOnPredictButton();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Tick </b>");
                await TimeManagerPage_mavryck.CLickOnYesPredictButton();
                Thread.Sleep(100000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Claim Probability Mavryck Prediction </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyMavryckPrediction());


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


        [Test, Order(22)]
        public async Task Verify_AI_Prediction_Of_Prognosis()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var timeManager = "Time Manager";

            try
            {
                Test = Extent.CreateTest("Verify Prediction Of Prognosis");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prognosis </b>");
                await TimeManagerPage_mavryck.ClickOnPrognosis();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict </b> And Select <b> 15-30% <b> ");
                await TimeManagerPage_mavryck.ClickOnPrognosisPredictButton();
              

                Test.Log(Status.Info, $"Step {++step}: Select <b> Phase </b>");
                await TimeManagerPage_mavryck.ClickOnPrognosisPhaseButton();
                Thread.Sleep(100000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict");
                await TimeManagerPage_mavryck.CLickOnPredictButton1();



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



        [Test, Order(23)]
        public async Task Prediction_Verify_RecoverySchedule_Graph()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page);
            var timeManager = "Time Manager";
            var title = "Recovery Schedule";

            try
            {
                Test = Extent.CreateTest("Prediction: Verify The Recovery Schedule Graph");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnPredictions();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Recovery Schedule </b>");
                await TimeManagerPage_mavryck.ClickOnRecoverySchedule();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Recovery Schedule Map </b> is visible");
                Assert.True(await TimeManagerPage_mavryck.VerifyRecoveryScheduleMapIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Recovery Schedule </b> is displaying");
                Assert.True(await TimeManagerPage_mavryck.VerifyChartNameIsDisplaying(title));

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