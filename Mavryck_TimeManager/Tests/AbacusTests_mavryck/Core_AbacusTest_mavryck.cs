using System;
using System.Collections;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;
using Mavryck_System.Pages;

namespace Mavryck_System.Tests.AbacusTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class Core_AbacusTest_mavryck : Base
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
        public async Task Abacus_Verify_Hover_Feature_Of_Core()
        {
            var Test = Extent.CreateTest("Core: Verify The Hover Feature");
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


                Test.Log(Status.Info, $" *** Hover The  <b>Overview </b> Of Core ***");
                await AbacusPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Overview  Hover Tooltip </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());


                Test.Log(Status.Info, $" *** Hover The  <b>BenchMarking </b> Of Core ***");
                await AbacusPage_mavryck.HoverBanchMarking();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>BenchMarking  Hover Tooltip </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Gantt Chart </b> Of Core ***");
                await AbacusPage_mavryck.HoverGanttChart();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Gantt Chart  Hover Tooltip </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());

                await AbacusPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover();


                Test.Log(Status.Info, $" *** Hover The  <b>Information</b> Of Grid ***");
                await AbacusPage_mavryck.HoverInformationButton();
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());
                Test.Pass("Verify the <b>Information Tooltip</b> ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());

            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }


        [Test]
        public async Task Abacus_Verify_PageTitles_WithTooltips_OF_Core()
        {
            var Test = Extent.CreateTest("Core : Verify The Page Titles With Tooltips");
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


                await AbacusPage_mavryck.VerifyPageTitleWithTooltip_Core();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task Abacus_Verify_GridResizing_Of_Overview_Grid()
        {
            var Test = Extent.CreateTest("Core : Verify The Grid Resizing Of Core");
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Overview Grid Resize Icon</b> ");
                await AbacusPage_mavryck.ClickOnResizeIcon();
                await Task.Delay(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
        public async Task Core_Verify_TextAllignment_Of_Items_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Items Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Items";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Abacus </b> Button");
                await DashboardPage_mavryck.ClickOnAbacus();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromTopRight_Menu1(abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

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
        public async Task Core_Verify_TextAllignment_Of_UOM_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of UOM Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "UOM";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

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
        public async Task Core_Verify_TextAllignment_Of_OriginalQty_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Original Qty Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Original Qty";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

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
        public async Task Core_Verify_TextAllignment_Of_ClassEstimate_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Class Estimate Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Class Estimate";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

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
        public async Task Core_Verify_TextAllignment_Of_Allowances_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Allowances Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Allowances";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

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
        public async Task Core_Verify_TextAllignment_Of_UnitRate_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Unit Rate Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Unit Rate";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

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
        public async Task Core_Verify_TextAllignment_Of_Total_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Total $ Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Total $";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

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
        public async Task Core_Verify_TextAllignment_Of_ROP_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of ROP Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "ROP";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

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
        public async Task Core_Verify_TextAllignment_Of_TotalManHours_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Total ManHours Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Total Manhours";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await AbacusPage_mavryck.ClickOnTextAllignmentButton();
                await Task.Delay(10000);

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
        public async Task Abacus_Verify_Information_Button_NavigatesTo_Ganttchart()
        {
            var Test = Extent.CreateTest("Core : Verify The Information Icon Navigates To Gantt Chart");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            byte[] screenshotBytes = null;
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Information Icon</b> ");
                await AbacusPage_mavryck.ClickOnInformaitonIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Gantt Chart </b> is opened");
                var pagetitleText = await AbacusPage_mavryck.GetPageTitleText();
                if (pagetitleText.Equals("GanttChart"))
                {
                    Test.Pass("Verified Gantt Chart is opened ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                }
                else
                {
                    Test.Fail("Verified Gantt Chart is not opened", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                }

                screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());


            }

            catch (Exception e)
            {

               screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }


        [Test]
        public async Task Abacus_Verify_Header_Of_CORE_Benchmarking()
        {
            var Test = Extent.CreateTest("Core (Bench Marking) : Verify The Header Requirments");
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



                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $" *** Verify The Header Requirments *** ");

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Estimate  Quality <b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyEstimateQuality1());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Class </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyClass());


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Margin</b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyMargin());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Finish Date </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyFinishDate());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Regions </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyRegions());

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_Code_Column()
        {
            var Test = Extent.CreateTest("Core {BenchMarking (Quality) }: Verify The Text Allignment Of Code Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Code";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_Discipline_Column()
        {
            var Test = Extent.CreateTest("Core {BenchMarking (Quality) }: Verify The Text Allignment Of Discipline Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Discipline";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_SubDiscipline_Column()
        {
            var Test = Extent.CreateTest("Core {BenchMarking (Quality) }: Verify The Text Allignment Of Sub-Discipline Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Sub-Discipline";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_Description_Column()
        {
            var Test = Extent.CreateTest("Core {BenchMarking (Quality) }: Verify The Text Allignment Of Description Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Description";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "4";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_UOM_Column()
        {
            var Test = Extent.CreateTest("Core {BenchMarking (Quality) }: Verify The Text Allignment Of UOM Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "UOM";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "5";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_CurrentProject_Column()
        {
            var Test = Extent.CreateTest("Core {BenchMarking (Quality) }: Verify The Text Allignment Of Current Project Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Current Project";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "6";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Abacus_Verify_GridResizing_Of_BenchMarking_Grid()
        {
            var Test = Extent.CreateTest("Core : Verify The Grid Resizing Of Bench Marking (Quality) Grid");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var region = "North America";

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

                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Quality Grid Resize Icon</b> ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_Code_Column_Cost_Grid()
        {
            var Test = Extent.CreateTest("Core {BenchMarking Cost ($) }: Verify The Text Allignment Of Code Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Code";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "1";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_Discipline_Column_Cost_Grid()
        {
            var Test = Extent.CreateTest("Core {BenchMarking Cost ($) }: Verify The Text Allignment Of Discipline Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Discipline";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "2";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_SubDiscipline_Column_Cost_Grid()
        {
            var Test = Extent.CreateTest("Core {BenchMarking Cost ($) }: Verify The Text Allignment Of Sub-Discipline Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Sub-Discipline";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "3";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_Description_Column_Cost_Grid()
        {
            var Test = Extent.CreateTest("Core {BenchMarking Cost ($) }: Verify The Text Allignment Of Description Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Description";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "4";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_UOM_Column_Cost_Grid()
        {
            var Test = Extent.CreateTest("Core {BenchMarking Cost ($) }: Verify The Text Allignment Of UOM Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "UOM";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "5";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Core_BenchMarking_Verify_TextAllignment_Of_CurrentProject_Column_Cost_Grid()
        {
            var Test = Extent.CreateTest("Core {BenchMarking Cost ($) }: Verify The Text Allignment Of Current Project Column");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var columnName = "Current Project";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "6";
            var region = "North America";

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


                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

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
        public async Task Abacus_Verify_GridResizing_Of_BenchMarking_Cost_Grid()
        {
            var Test = Extent.CreateTest("Core : Verify The Grid Resizing Of Bench Marking Cost($) Grid");
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacus = "estimation";
            var abacusTitle = "Abacus";
            var region = "North America";

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

                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Bench Marking </b>");
                await AbacusPage_mavryck.ClickOnBenchmarking();

                Test.Log(Status.Info, $"Step {++step}: Select  <b> Region </b>");
                await AbacusPage_mavryck.SelectRegion(region);

                Test.Log(Status.Info, $"Step {++step}: Click On   <b> Cost ($) </b>");
                await AbacusPage_mavryck.ClickOnCost();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Quality Grid Resize Icon</b> ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
        public async Task Abacus_Verify_GanttChart()
        {
            var Test = Extent.CreateTest("Core : Verify That Gantt Chart Is Successfully Displaying");
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

                Test.Log(Status.Info, $"Step {++step}: Click On  <b> Gantt Chart </b>");
                await AbacusPage_mavryck.ClickOnGanttchart();
                await Task.Delay(10000);


                Test.Log(Status.Info, $"Step {++step}: Select  <b> Date </b>");
                await AbacusPage_mavryck.SelectDate();


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