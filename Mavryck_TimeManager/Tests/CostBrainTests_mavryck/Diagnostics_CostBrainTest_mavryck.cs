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

    public class Diagnostics_CostBrainTest_mavryck : Base
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
        public async Task Diagnostics_Compliance_Verify_TextAllignment_Of_Category_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Compliance: Verify The Text Allignment Of Category Column");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Category";
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Complaince </b>"));
                await CostBrainPage_mavryck.ClickOnComplaince();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await CostBrainPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(15000);

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_Name_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of Name Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Name";
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_Position_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of Position Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Position";
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_PAF_Approved_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of PAF Approved Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "PAF Approved";
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_Per_hour_rate_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of Per Hour Rate Approved Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Per Hour Rate";
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_AllowedHours_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of Allowed Hours Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Allowed Hours";
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_HoursInvoiced_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of Hours Invoiced Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Hours Invoiced";
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_RateExceeded_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of Rate Exceeded Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Rate Exceeded";
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_DuplicateNames_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of Duplicate Names Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Duplicate Names";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_UnapprovedPAFCharged_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of Unapproved PAF Charged Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Unapproved PAF Charged";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Staff_Verify_TextAllignment_Of_Forecasting_Column()
        {
            var Test = Extent.CreateTest("Diagnostics Staff: Verify The Text Allignment Of Forecasting Column");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var columnName = "Forecasting";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>CostBrain </b> Button");
                await DashboardPage_mavryck.ClickOnCostBrain();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> CostBrain </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(costbrain);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>CostBrain App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costBrainTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();

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
        public async Task Diagnostics_Verify_DeepAnalysis_Report()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Deep Analysis Report ");
            
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $" <b> **** Wait For Few Seconds (Report is generating ) ****"));
                Thread.Sleep(10000);
                testSteps.AddRange(await CostBrainPage_mavryck.VerifyDeepAnalysisReport(step));



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
        public async Task Diagnostics_Verify_HoverFeature_Of_Complaince()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Hover Feature Of Complaince");
            
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Complaince </b>"));
                await CostBrainPage_mavryck.ClickOnComplaince();
                await Task.Delay(15000);

                testSteps.AddRange(await CostBrainPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
                await CostBrainPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await CostBrainPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
        public async Task Diagnostics_Verify_HoverFeature_Of_Staff()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Hover Feature Of Staff");

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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await CostBrainPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Staff </b>"));
                await CostBrainPage_mavryck.ClickOnStaff();
                await Task.Delay(15000);

                testSteps.AddRange(await CostBrainPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
                await CostBrainPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await CostBrainPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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