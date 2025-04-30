using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;




namespace Mavryck_System.Tests.AbacusTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class Prediction_AbacusTest_mavryck : Base
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
        public async Task Predictions_CompletionGrid_VerifyTheTextAllignmentOf_Tasks_Column()
        {
            var Test = Extent.CreateTest("Predictions Completion Grid: Verify The Text Allignment Of TaskName Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";
            var columnName = "TaskName";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);
           

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnCompletionGrid();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await AbacusPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_BaselineDuration_Column()
        {
            var Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Baseline Duration Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            
            var columnName = "Baseline Duration";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnCompletionGrid();
            

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await AbacusPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Remaining_Duration_Current_Column()
        {
            var Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Remaining Duration Current Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Remaining Duration Current";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await AbacusPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Current_Finish_Column()
        {
            var Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Current Finish Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Current Finish";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await AbacusPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Critical_Column()
        {
            var Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Critical Column");          
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Critical";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await AbacusPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Optimal_Bias_Check_Column()
        {
            var Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Optimal Bias Check Column");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Optimal Bias Check";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await AbacusPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Predicted_Remaining_Duration_Column()
        {
            var Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Predicted Remaining Duration Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Predicted Remaining Duration";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await AbacusPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Predicted_Finish_Date_Column()
        {
            var Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Predicted Finish Date Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Predicted Finish Date";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await AbacusPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Prediction_CompletionGrid_VerifyTheTextAllignmentOf_Insights_Column()
        {
            var Test = Extent.CreateTest("Prediction Completion Grid: Verify The Text Allignment Of Insights Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Insights";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Completion Grid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnCompletionGrid();
                Thread.Sleep(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await AbacusPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Verify_Hover_Feature_Of_Prediction()
        {
            var Test = Extent.CreateTest("Prediction: Verify The Hover Feature");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";         
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Probabilities </b> Of Predictions ***"));
                await AbacusPage_mavryck.HoverProbabilites();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Probabilities Hover Tooltip </b> is displaying"));
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());


                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Completion Grid </b> Of Predictions ***"));
                await AbacusPage_mavryck.HoverCompletionGrid();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Completion Grid Hover Tooltip </b> is displaying"));
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());
                await AbacusPage_mavryck.ClickOnCompletionGrid();

                testSteps.AddRange(await AbacusPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover());
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Prognosis </b> Of Predictions ***"));
                await AbacusPage_mavryck.HoverPrognosis();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Prognosis Hover Tooltip </b> is displaying"));
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());


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
        public async Task Verify_AI_Prediction_Of_CompletionProbability()
        {
            var Test = Extent.CreateTest("Verify AI Prediction Of Completion Probability");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
           

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict </b>");
                await AbacusPage_mavryck.CLickOnPredictButton2();

                

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


        [Test]
        public async Task Verify_AI_Prediction_Of_ClaimProbability()
        {
            var Test = Extent.CreateTest("Verify Prediction Of Claim Probability");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                await ScrollToElement(page, $"//h3[text()='Claim Probability']");
                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict </b>");
                await AbacusPage_mavryck.CLickOnPredictButton3();


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


        [Test]
        public async Task Verify_AI_Prediction_Of_Prognosis()
        {
            var Test = Extent.CreateTest("Verify Prediction Of Prognosis");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prognosis </b>");
                await AbacusPage_mavryck.ClickOnPrognosis();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict </b> And Select <b> 15-30% <b> ");
                await AbacusPage_mavryck.ClickOnPrognosisPredictButton();


                Test.Log(Status.Info, $"Step {++step}: Select <b> Phase </b>");
                await AbacusPage_mavryck.ClickOnPrognosisPhaseButton();
                Thread.Sleep(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict");
                await AbacusPage_mavryck.CLickOnPredictButton1();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Prognosis Grid</b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyPrognosisGrid());


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
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPredictions();

                await AbacusPage_mavryck.VerifyPageTitleWithTooltip_Predictions();
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