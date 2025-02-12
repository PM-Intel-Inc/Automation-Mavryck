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

namespace Mavryck_TimeManager.Tests.CostBrainTests_mavryck
{

    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class Core_CostBrainTest_mavryck : Base
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
        public async Task Verify_AllRequirments_Of_costbrain()
        {
            var Test = Extent.CreateTest("Verify All The Requirements Of costbrain");
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Version</b> Icon");
                Assert.True(await CostBrainPage_mavryck.VerifyVersion());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Date</b>");
                Assert.True(await CostBrainPage_mavryck.VerifyDate());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Add File</b> Button");
                Assert.True(await CostBrainPage_mavryck.VerifyAdd_File_Button());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Users</b> Button");
                Assert.True(await CostBrainPage_mavryck.VerifyAdd_Member());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid's Icon</b>");
                Assert.True(await CostBrainPage_mavryck.VerifyDownload_GridIcon());
                Assert.True(await CostBrainPage_mavryck.VerifyShowHide_GridIcon());
                Assert.True(await CostBrainPage_mavryck.Verify_FullScreen_GridIcon());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Available ROV's</b>");
                Assert.True(await CostBrainPage_mavryck.VerifyAvailable_ROV());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Missing ROV's</b>");
                Assert.True(await CostBrainPage_mavryck.VerifyMissing_ROV());


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
        public async Task Core_Verify_TextAllignment_Of_WBS_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of WBS Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";
            var columnName = " WBS ";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Core_Verify_TextAllignment_Of_ActivityName_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Activity Name Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";
            var columnName = "Activity Name";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Core_Verify_TextAllignment_Of_Budget_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Budget Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Budget ";
            var colIndex = "3";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Core_Verify_TextAllignment_Of_IncurredToDate_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Incurred To Date Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Incurred To Date ";
            var colIndex = "4";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Core_Verify_TextAllignment_Of_ETC_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of ETC Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var columnName = " ETC ";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "5";
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Core_Verify_TextAllignment_Of_EAC_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of EAC Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " EAC ";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Core_Verify_TextAllignment_Of_ReasonOfVariance_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Reason Of Variance Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Reason of Variance";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Core_Verify_TextAllignment_Of_CostPerDay_Column()
        {
            var Test = Extent.CreateTest("Verify The Text Allignment Of Cost Per Day Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Cost per day ";
            var colIndex = "8";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Verify_TextAllignment_Of_Labor_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Labor Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Labor ";
            var colIndex = "9";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";
        
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>costbrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Core_Verify_TextAllignment_Of_Material_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Material Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Material ";
            var colIndex = "10";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Verify_TextAllignment_Of_Equipment_Column()
        {
            var Test = Extent.CreateTest("Verify The Text Allignment Of Equipment Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Equipment ";
            var colIndex = "11";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";
         
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Verify_TextAllignment_Of_Direct_Column()
        {
            var Test = Extent.CreateTest("Verify The Text Allignment Of Direct Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Direct ";
            var colIndex = "10";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(60000);

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
        public async Task Verify_TextAllignment_Of_Indirect_Column()
        {
            var Test = Extent.CreateTest("Verify The Text Allignment Of Indirect Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Indirect ";
            var colIndex = "11";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Verify_TextAllignment_Of_Commitments_Column()
        {
            var Test = Extent.CreateTest("Verify The Text Allignment Of Commitments Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Commitments ";
            var colIndex = "12";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Verify_TextAllignment_Of_ChangeOrder_Column()
        {
            var Test = Extent.CreateTest("Verify The Text Allignment Of Change Order Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = " Change order ";
            var colIndex = "13";
            var CostBrainPage_mavryck = new CostBrainPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

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
        public async Task Verify_RequirementsOf_SideNavMenu_of_Costbrain()
        {
            var Test = Extent.CreateTest("Verify The Requirements Of Side Navigation Requirements Of Cost Brain");
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
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Arrow </b> To Open Side Nav");
                await CostBrainPage_mavryck.ClickOnArrow();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project Logo </b>");
                Assert.True(await CostBrainPage_mavryck.VerifyProjectLogo());


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Budget</b>");
                Assert.True(await CostBrainPage_mavryck.VerifyBudget());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>EAC</b>");
                Assert.True(await CostBrainPage_mavryck.VerifyEAC());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>ETC</b>");
                Assert.True(await CostBrainPage_mavryck.VerifyETC());


                Test.Log(Status.Info, $" *** Verify the <b>Capabilities Of Cost Brain</b> ***");
                Assert.True(await CostBrainPage_mavryck.VerifyCore());
                Assert.True(await CostBrainPage_mavryck.VerifyOculusDV());
                Assert.True(await CostBrainPage_mavryck.VerifyAndon());
                Assert.True(await CostBrainPage_mavryck.VerifyGIGO());
                Assert.True(await CostBrainPage_mavryck.VerifyScenarioModeling());


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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Core ***");
                await CostBrainPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await CostBrainPage_mavryck.VerifyHoverTooltip());


                Test.Log(Status.Info, $" *** Hover The  <b>Gantt Chart</b> Of Core ***");
                await CostBrainPage_mavryck.HoverGanttChart();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await CostBrainPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Download Button</b> Of Grid ***");
                await CostBrainPage_mavryck.HoverDownloadButton();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Download Tooltip </b> is displaying");
                Assert.True(await CostBrainPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Hide/Unhide Button</b> Of Grid ***");
                await CostBrainPage_mavryck.HoverHideUnHideButton();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Hide/UnHide Button Tooltip </b> is displaying");
                Assert.True(await CostBrainPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Full Screen</b> Of Grid ***");
                await CostBrainPage_mavryck.HoverFullScreenButton();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Full Screen Tooltip</b> is displaying");
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
        public async Task Verify_Grid_Resizing()
        {
            var Test = Extent.CreateTest("Core: Verify The Grid Is Successfully Resized");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var costbrain = "cost";
            var costBrainTitle = "CostBrain";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> Cost Brain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Cost Brain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();
                await Task.Delay(10000);

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