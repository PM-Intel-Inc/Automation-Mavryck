using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;




namespace Mavryck_System.Tests.CostBrainTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class Prediction_CostBrainTest_mavryck : Base
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
        public async Task Predictions_CostForecast_VerifyTheTextAllignmentOf_ID_Column()
        {
            var Test = Extent.CreateTest("Predictions Completion Grid: Verify The Text Allignment Of TaskName Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "ID";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Cost Forecast </b>");
                await CostBrainPage_mavryck.ClickOnCostForecast();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



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
        public async Task Predictions_CostForecast_VerifyTheTextAllignmentOf_TaskName_Column()
        {
            var Test = Extent.CreateTest("Predictions Completion Grid: Verify The Text Allignment Of Task Name Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Task Name";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Cost Forecast </b>");
                await CostBrainPage_mavryck.ClickOnCostForecast();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



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
        public async Task Prediction_CostForecast_VerifyTheTextAllignmentOf_Duration_Column()
        {
            var Test = Extent.CreateTest("Prediction Cost Forecast : Verify The Text Allignment Of Baseline Duration Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Duration";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Cost Forecast </b>");
                await CostBrainPage_mavryck.ClickOnCostForecast();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Prediction_CostForecast_VerifyTheTextAllignmentOf_Budget_Column()
        {
            var Test = Extent.CreateTest("Prediction Cost Forecast: Verify The Text Allignment Of Budget Column");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Budget";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "4";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Cost Forecast </b>");
                await CostBrainPage_mavryck.ClickOnCostForecast();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Prediction_CostForecast_VerifyTheTextAllignmentOf_IncurredCost_Column()
        {
            var Test = Extent.CreateTest("Prediction Cost Forecast: Verify The Text Allignment Of Incurred Cost Column");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Incurred Cost";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "5";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Cost Forecast </b>");
                await CostBrainPage_mavryck.ClickOnCostForecast();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Prediction_CostForecast_VerifyTheTextAllignmentOf_ETC_Present_Column()
        {
            var Test = Extent.CreateTest("Prediction Cost Forecast: Verify The Text Allignment Of ETC Present Column");
          
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "ETC(Present)";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "6";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Cost Forecast </b>");
                await CostBrainPage_mavryck.ClickOnCostForecast();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Prediction_CostForecast_VerifyTheTextAllignmentOf_EAC_Present_Column()
        {
            var Test = Extent.CreateTest("Prediction Cost Forecast: Verify The Text Allignment Of EAC(Present) Column");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Optimal Bias Check";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "7";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Cost Forecast </b>");
                await CostBrainPage_mavryck.ClickOnCostForecast();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await CostBrainPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPredictions();

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Probabilities </b> Of Predictions ***"));
                await CostBrainPage_mavryck.HoverKnockOnImpact();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Knock On Impact Hover Tooltip </b> is displaying"));
                Assert.True(await CostBrainPage_mavryck.VerifyHoverTooltip());


                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Cost Forecast Grid </b> Of Predictions ***"));
                await CostBrainPage_mavryck.HoverCostForecast();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Cost Forecast  Hover Tooltip </b> is displaying"));
                Assert.True(await CostBrainPage_mavryck.VerifyHoverTooltip());
                await CostBrainPage_mavryck.ClickOnCostForecast();

                testSteps.AddRange(await CostBrainPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Prognosis </b> Of Predictions ***"));
                await CostBrainPage_mavryck.HoverPrognosis();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Prognosis Hover Tooltip </b> is displaying"));
                Assert.True(await CostBrainPage_mavryck.VerifyHoverTooltip());

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
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prediction </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Prognosis </b>");
                await CostBrainPage_mavryck.ClickOnPrognosis();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict </b> And Select <b> 15-30% <b> ");
                await CostBrainPage_mavryck.ClickOnPrognosisPredictButton();


                Test.Log(Status.Info, $"Step {++step}: Select <b> Phase </b>");
                await CostBrainPage_mavryck.ClickOnPrognosisPhaseButton();
                Thread.Sleep(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Predict");
                await CostBrainPage_mavryck.CLickOnPredictButton1();

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