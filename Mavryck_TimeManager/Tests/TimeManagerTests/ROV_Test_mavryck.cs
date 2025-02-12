using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Pages.Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;

namespace Mavryck_TimeManager.Tests.TimeManagerTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class ROV_Test_mavryck : Base
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
        public async Task Verify_UserCanAddThe_ROV()
        {
            var Test = Extent.CreateTest("Verify User Can Add The Reason Of Variance");
           
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var ROVPage_mavryck = new ROVPage_mavryck(page, Test);

            var timeManager = "Time Manager";
            var variance = "Automation Variance";
            var control_acc = "Automation Control Account";
            var control_acc_manager = "Automation Control Account Manager";
            var theme = "Equipment Failure";


            try
            {
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>ROV</b> Icon");
                await ROVPage_mavryck.ClickOnROV_Icon();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Add Another Row</b>");
                await ROVPage_mavryck.Click_On_NewRow();

                Test.Log(Status.Info, $"Step {++step}: Enter The <b>ROV Name</b>");
                await ROVPage_mavryck.Enter_ROV_Name();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Root Cause</b> Button");
                await ROVPage_mavryck.Click_ON_RootCause();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Start Date</b>");
                await ROVPage_mavryck.Enter_StartDate();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>End Date</b>");
                await ROVPage_mavryck.Enter_EndDate();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Variance</b>");
                await ROVPage_mavryck.Enter_Variance(variance);

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Control Account</b>");
                await ROVPage_mavryck.Enter_ControlAccount(control_acc);

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Control Account Manager</b>");
                await ROVPage_mavryck.Enter_ControlAccountManager(control_acc_manager);

                Test.Log(Status.Info, $"Step {++step}: Click On  <b>Save</b> Button");
                await ROVPage_mavryck.ClickOnSaveButton();

                Test.Log(Status.Info, $" *** Enter The ROOT CAUSE ANALYSIS  **** ");

                Test.Log(Status.Info, $"Step {++step}: Select <b>Theme</b>");
                await ROVPage_mavryck.SelectTheme(theme);
                await page.Mouse.MoveAsync(300, 300);

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Root Cause Why's</b>");
                await ROVPage_mavryck.Enter_RootCauseWhy();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Next Step </b>");
                await ROVPage_mavryck.ClickOnNextStep_RCA();


                Test.Log(Status.Info, $" *** Enter The CORRECTIVE ACTION ROOT CAUSE  **** ");

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Corrective Action Root Cause</b>");
                await ROVPage_mavryck.Enter_CorrectiveActionRootCause();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Next Step </b>");
                await ROVPage_mavryck.ClickOnNextStep_RCA();

                Test.Log(Status.Info, $" *** Assign An Action **** ");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Next Step </b>");
                await ROVPage_mavryck.ClickOnNextStep_RCA();
                await Task.Delay(10000);


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
        public async Task Verify_UserCanEnterThe_ROV_DetailsBy_RCAIcon()
        {
            var Test = Extent.CreateTest("Verify User Can Enter The Reason Of Variance Details By RCA Icon");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var ROVPage_mavryck = new ROVPage_mavryck(page, Test);
            var timeManager = "Time Manager";
            var variance = "Automation Variance";
            var control_acc = "Automation Control Account";
            var control_acc_manager = "Automation Control Account Manager";
            var theme = "Equipment Failure";


            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));
                await Task.Delay(120000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>ROV</b> Icon");
                await ROVPage_mavryck.ClickOnROV_Icon();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Add Another Row</b>");
                await ROVPage_mavryck.Click_On_NewRow();

                Test.Log(Status.Info, $"Step {++step}: Enter The <b>ROV Name</b>");
                await ROVPage_mavryck.Enter_ROV_Name();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Root Cause</b> Button");
                await ROVPage_mavryck.Click_ON_RootCause();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Start Date</b>");
                await ROVPage_mavryck.Enter_StartDate();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>End Date</b>");
                await ROVPage_mavryck.Enter_EndDate();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Variance</b>");
                await ROVPage_mavryck.Enter_Variance(variance);

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Control Account</b>");
                await ROVPage_mavryck.Enter_ControlAccount(control_acc);

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Control Account Manager</b>");
                await ROVPage_mavryck.Enter_ControlAccountManager(control_acc_manager);

                Test.Log(Status.Info, $"Step {++step}: Click On  <b>Save</b> Button");
                await ROVPage_mavryck.ClickOnSaveButton();

                Test.Log(Status.Info, $" *** Enter The ROOT CAUSE ANALYSIS  **** ");

                Test.Log(Status.Info, $"Step {++step}: Click On  <b>RCA Icon</b>");
                await ROVPage_mavryck.ClickOnRCAIcon();
                await Task.Delay(10000);


                Test.Log(Status.Info, $"Step {++step}: Enter <b>Root Cause Why's</b> by clicking on <b> RCA ICON </b>");
                await ROVPage_mavryck.VerifyRootCauseWhy();

                Test.Log(Status.Info, $"Step {++step}: Select <b>Theme</b>");
                await ROVPage_mavryck.SelectTheme(theme);
                await page.Mouse.MoveAsync(300, 300);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Next Step </b>");
                await ROVPage_mavryck.ClickOnNextStep_RCA();


                Test.Log(Status.Info, $" *** Enter The CORRECTIVE ACTION ROOT CAUSE  **** ");

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Corrective Action Root Cause</b> added ");
                await ROVPage_mavryck.VerifyCorrectiveActionWhy();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Next Step </b>");
                await ROVPage_mavryck.ClickOnNextStep_RCA();

                Test.Log(Status.Info, $" *** Assign An Action **** ");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Next Step </b>");
                await ROVPage_mavryck.ClickOnNextStep_RCA();
                await Task.Delay(10000);

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
        public async Task Verify_UserCan_Filter_ROV()
        {
            var Test = Extent.CreateTest("Verify ROV Filter Is Functioning Properly");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var ROVPage_mavryck = new ROVPage_mavryck(page, Test);

            var timeManager = "Time Manager";
            var input1 = "Automation";
            var input2 = "ROV Test";



            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Time Manager </b> App From Top Right Menu");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(timeManager);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Time Manager App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManager));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>ROV</b> Icon");
                await ROVPage_mavryck.ClickOnROV_Icon();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Filter</b> Button");
                await ROVPage_mavryck.Click_On_Filter();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>ROV Input 1</b>");
                await ROVPage_mavryck.Enter_filterInput1(input1);

                Test.Log(Status.Info, $"Step {++step}: Enter <b>ROV Input 2</b>");
                await ROVPage_mavryck.Enter_filterInput2(input2);

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Filtered ROV</b> is displaying");
                Assert.True(await ROVPage_mavryck.VerifyFilteredOuput());

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
        public async Task Verify_UserCancel_Resetting_ROV()
        {
            var Test = Extent.CreateTest("Verify User Can Cancel Resetting The ROV");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var ROVPage_mavryck = new ROVPage_mavryck(page, Test);

            var timeManager = "Time Manager";

            try
            {
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
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Existing ROV</b> Icon");
                await ROVPage_mavryck.ClickOnExistingROV();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Root Cause RCA ToolTip</b> Button");
                await ROVPage_mavryck.Click_On_RootCauseToolTip();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Reset</b> Button");
                await ROVPage_mavryck.ClickOnRootCause_Reset();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>No</b> Button");
                await ROVPage_mavryck.ClickOnROV_NoButton();

                Test.Log(Status.Info, $"Step {++step}: Verify <b>ROV</b> is not reset");
                Assert.True(await ROVPage_mavryck.VerifyRootCauseAnalysis_Why1());

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
        public async Task Verify_UserCan_Reset_ROV()
        {
            var Test = Extent.CreateTest("Verify User Can Reset The ROV");
           
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var ROVPage_mavryck = new ROVPage_mavryck(page, Test);

            var timeManager = "Time Manager";

            try
            {
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Existing ROV</b> Icon");
                await ROVPage_mavryck.ClickOnExistingROV();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Root Cause RCA ToolTip</b> Button");
                await ROVPage_mavryck.Click_On_RootCauseToolTip();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Reset</b> Button");
                await ROVPage_mavryck.ClickOnRootCause_Reset();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Yes</b> Button");
                await ROVPage_mavryck.ClickOnROV_YesButton();

                Test.Log(Status.Info, $"Step {++step}: Verify <b>ROV</b> is reset successfully");
                Assert.True(await ROVPage_mavryck.VerifyRootCauseAnalysis_Why1());

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
        public async Task Verify_UserCan_Delete_ROV()
        {
            var Test = Extent.CreateTest("Verify User Can Delete The ROV");
            
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var ROVPage_mavryck = new ROVPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var timeManager = "Time Manager";

            try
            {
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>ROV</b> Icon");
                await ROVPage_mavryck.ClickOnROV_Icon();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Delete</b> Button");
                await ROVPage_mavryck.Click_On_Delete();

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Yes Delete It </b> Button");
                await ROVPage_mavryck.Click_On_Yes();

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

