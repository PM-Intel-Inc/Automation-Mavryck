using System;
using System.Collections;
using System.Drawing;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;

namespace Mavryck_System.Tests.VivclimaTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class ClimateRisk_VivclimaTest_mavryck : Base
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
        public async Task Vivclima_Verify_Header_Of_ClimateRisk()
        {
            var Test = Extent.CreateTest("Vivclima : Verify The Header Requirments Of Climate Risk");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var OculusDvPage_mavryck = new OculusDvPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $" *** Verify The Header Requirments *** ");

            

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
        public async Task Vivclima_Verify_Hover_Feature_Of_ClimateRisk()
        {
            var Test = Extent.CreateTest("Vivclima: Verify The Hover Feature Of Climate Risk");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            byte[] screenshotBytes = null;

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Climate Risk ***");
                await VivclimaPage_mavryck.HoverClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyHoverTooltip());

                testSteps.AddRange(await VivclimaPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover());
                step = testSteps.Count;

                screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Verified Grid View", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());

            }
            catch (Exception e)
            {
                screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task Vivclima_Verify_PageTitles_WithTooltips_OF_ClimateRisk()
        {
            var Test = Extent.CreateTest("Vivclima : Verify The Page Titles With Tooltips Of Climate Risk");

            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                await VivclimaPage_mavryck.VerifyPageTitleWithTooltip_ClimateRisk();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task ClimateRisk_Verify_TextAllignment_Of_RiskAssessment_ID_Column()
        {
            var Test = Extent.CreateTest("Climate Risk: Verify The Text Allignment Of Risk Assessment ID Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "ID";
            var colIndex = "1";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_Verify_TextAllignment_Of_RiskAssessment_Approches_Column()
        {
            var Test = Extent.CreateTest("Climate Risk: Verify The Text Allignment Of Risk Assessment Approaches Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Approaches";
            var colIndex = "2";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_Verify_TextAllignment_Of_RiskAssessment_Notes_Column()
        {
            var Test = Extent.CreateTest("Climate Risk: Verify The Text Allignment Of Risk Assessment Notes Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Notes";
            var colIndex = "4";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_Verify_TextAllignment_Of_ClimateHazard_ID_Column()
        {
            var Test = Extent.CreateTest("Climate Risk: Verify The Text Allignment Of Climate Hazard ID Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "ID";
            var colIndex = "1";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Hazard Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateHazardTab();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_ClimateHazard_Verify_TextAllignment_Of_ClimateHazard_Column()
        {
            var Test = Extent.CreateTest("Climate Risk (Climate Hazard) : Verify The Text Allignment Of Climate Hazard Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Climate Hazard";
            var colIndex = "2";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Hazard Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateHazardTab();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_Climate_Hazard_Verify_TextAllignment_Of_InfrastructureComponent_Column()
        {
            var Test = Extent.CreateTest("Climate Risk (Climate Hazard ): Verify The Text Allignment Of Infrastructure Component Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Infrastructure Component";
            var colIndex = "3";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Hazard Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateHazardTab();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_ClimateHazard_Verify_TextAllignment_Of_OverAllRiskLevel_Column()
        {
            var Test = Extent.CreateTest("Climate Risk (Climate Hazard): Verify The Text Allignment Of OverAll Risk Level Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Overall Risk Level";
            var colIndex = "4";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Hazard Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateHazardTab();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_RiskMitigationMeasures_Verify_TextAllignment_Of_ID_Column()
        {
            var Test = Extent.CreateTest("Climate Risk (Risk Mitigation Measures) : Verify The Text Allignment Of ID Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "ID";
            var colIndex = "1";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Risk Mitigaiion Measures Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnRiskMitigationMeasures();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_RiskMitigationMeasures_Verify_TextAllignment_Of_RiskReduction_Column()
        {
            var Test = Extent.CreateTest("Climate Risk (Risk Mitigation Measures) : Verify The Text Allignment Of Measures Identified For Risk Reduction Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Measures Identified for Risk Reduction";
            var colIndex = "2";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Risk Mitigaiion Measures Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnRiskMitigationMeasures();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_RiskMitigationMeasures_Verify_TextAllignment_Of_Relevant_Hazard_Infrastructure_Component_Interactions_Column()
        {
            var Test = Extent.CreateTest("Climate Risk (Risk Mitigation Measures) : Verify The Text Allignment Of Relevant Hazard-Infrastructure Component Interactions Column Of Risk Mitigation Measures   ");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Relevant Hazard-Infrastructure Component Interactions";
            var colIndex = "3";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Risk Mitigaiion Measures Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnRiskMitigationMeasures();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_RiskMitigationMeasures_Verify_TextAllignment_Of_Will_The_Measure_Be_Implemented_Column()
        {
            var Test = Extent.CreateTest("Climate Risk ( Risk Mitigation Measures) : Verify The Text Allignment Of Relevant Hazard-Infrastructure Component Interactions Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Will the measure be implemented";
            var colIndex = "4";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Risk Mitigaiion Measures Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnRiskMitigationMeasures();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_RiskMitigationMeasures_Verify_TextAllignment_Of_Name_Resilience_Standard_Employed_For_Implementationd_Column()
        {
            var Test = Extent.CreateTest("Climate Risk ( Risk Mitigation Measures) : Verify The Text Allignment Of Name resilience standard employed for implementation Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Name resilience standard employed for implementation";
            var colIndex = "5";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Risk Mitigaiion Measures Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnRiskMitigationMeasures();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_RiskMitigationMeasures_Verify_TextAllignment_Of_Limitations_Of_The_Standards_Column()
        {
            var Test = Extent.CreateTest("Climate Risk ( Risk Mitigation Measures) : Verify The Text Allignment Of Limitations of the standards(if found) Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Limitations of the standards(if found)";
            var colIndex = "6";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Risk Mitigaiion Measures Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnRiskMitigationMeasures();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task ClimateRisk_RiskMitigationMeasures_Verify_TextAllignment_Of_Estimated_Cost_Of_Applying_Resilience_Measures_Column()
        {
            var Test = Extent.CreateTest("Climate Risk ( Risk Mitigation Measures) : Verify The Text Allignment Of Estimated Cost of Applying Resilience Measures Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var vivclima = "vivclima";
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Estimated Cost of Applying Resilience Measures";
            var colIndex = "7";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Vivclima </b> Button");
                await DashboardPage_mavryck.ClickOnVivclima();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu(vivclima);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Climate Risk</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnClimateRisk();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Risk Mitigaiion Measures Tab</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnRiskMitigationMeasures();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(60000);


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await VivclimaPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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