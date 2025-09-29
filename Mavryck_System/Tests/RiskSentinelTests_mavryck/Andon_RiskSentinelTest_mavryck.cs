using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Parameters;
using PlanNotePlaywrite;

namespace Mavryck_System.Tests.RiskSentinelTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class Andon_RiskSentinelTest_mavryck : Base
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
        public async Task Verify_The_HeaderRequirments_Of_Andon()
        {

            var Test = Extent.CreateTest("Verify The Header Requirments Of Andon");
            int step = 0;
            var testSteps = new ArrayList();

            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

              

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();

                Test.Log(Status.Info, $" *** Verify The Header Requirments *** ");

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Schedule Quality</b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyScheduleQuality());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project Duration </b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyProjectDuration());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Start Date </b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyStartDate());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Finish Date </b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyFinishDate());

                Test.Log(Status.Info, $" *** Verify The Grid Icons *** ");
                Assert.True(await RiskSentinelPage_mavryck.VerifyDownload_GridIcon());
                Assert.True(await RiskSentinelPage_mavryck.VerifyShowHide_GridIcon());
                Assert.True(await RiskSentinelPage_mavryck.Verify_FullScreen_GridIcon());
                Assert.True(await RiskSentinelPage_mavryck.VerifyIndicators_GridIcon());


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
        public async Task Andon_Verify_TextAllignment_Of_ID_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of ID Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "ID";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Andon_Verify_TextAllignment_Of_TaskName_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Task Name Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Task Name";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_Verify_TextAllignment_Of_Indicator_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Indicator Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Indicator";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_Verify_TextAllignment_Of_Start_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Start Date Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Start";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Risk Sentinel </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnRiskSentinel();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromMenu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();
                await Task.Delay(15000);



                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);



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
        public async Task Andon_Verify_TextAllignment_Of_Finish_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Finish Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Finish";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Andon_Verify_TextAllignment_Of_Duration_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Duration Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Duration";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_Verify_TextAllignment_Of_Critical_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Critical Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Critical";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_Verify_TextAllignment_Of_EarlyStart_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Early Start Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Early Start";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Andon_Verify_TextAllignment_Of_EarlyFinish_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Early Finish Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Early Finish";
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Risk Sentinel </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnRiskSentinel();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromMenu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Andon_Verify_TextAllignment_Of_LateStart_Column()
        {
            var Test = Extent.CreateTest("Andon:  Verify The Text Allignment Of Late Start Column");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Late Start";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "10";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Risk Sentinel </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnRiskSentinel();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromMenu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();
                await Task.Delay(15000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Andon_Verify_TextAllignment_Of_LateFinish_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Late Finish Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Late Finish";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "11";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_Verify_TextAllignment_Of_TotalFloat_Column()
        {
            var Test = Extent.CreateTest("Andon: Verify The Text Allignment Of Total Float Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Total Float";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var colIndex = "12";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_PotentialCliam_Verify_TextAllignment_Of_Id_Column()
        {
            var Test = Extent.CreateTest("Andon Potential Claim Grid: Verify The Text Allignment Of ID Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "ID";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();

                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton2();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment_andon(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Andon_PotentialClaim_Verify_TextAllignment_Of_TaskName_Column()
        {
            var Test = Extent.CreateTest("Andon Potential Claim Grid: Verify The Text Allignment Of Task Name Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Task Name";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();

                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton2();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment_andon(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Andon_PotentialClaim_Verify_TextAllignment_Of_InRelation_Task_Id_Column()
        {
            var Test = Extent.CreateTest("Andon Potential Claim Grid: Verify The Text Allignment Of InRelation Task Id Column");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "InRelation Task Id";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();

                await ScrollToElement(page, $"//h3[text()='Potential Claims']");


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton2();

                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment_andon_1(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Andon_PotentialClaim_Verify_TextAllignment_Of_InRelation_Task_Column()
        {
            var Test = Extent.CreateTest("Andon Potential Claim Grid: Verify The Text Allignment Of InRelation Task Colum");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "InRelation Task";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();

                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton2();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment_andon_1(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);

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
        public async Task Andon_PotentialClaim_Verify_TextAllignment_Of_Task_Id_Column()
        {
            var Test = Extent.CreateTest("Andon Potential Claim Grid: Verify The Text Allignment Of Task_Id column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Task Id";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton2();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment_andon_1(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_PotentialClaim_Verify_TextAllignment_Of_UpdateNumber_Column()
        {
            var Test = Extent.CreateTest("Andon Potential Claim Grid: Verify The Text Allignment Of Update Number column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Update Number";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton2();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment_andon_1(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_PotentialClaim_Verify_TextAllignment_Of_Reduction_Column()
        {

            var Test = Extent.CreateTest("Andon Potential Claim Grid: Verify The Text Allignment Of Reduction column");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Reduction";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton2();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment_andon_1(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_PotentialClaim_Verify_TextAllignment_Of_Indicators_Column()
        {
            var Test = Extent.CreateTest("Andon Potential Claim Grid: Verify The Text Allignment Of Indicators column");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Indicators";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                await ScrollToElement(page, $"//h3[text()='Potential Claims']");


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton2();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment_andon_1(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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

        public async Task Andon_PotentialClaim_Verify_TextAllignment_Of_TotalFloat_Column()
        {
            var Test = Extent.CreateTest("Andon Potential Claim Grid: Verify The Text Allignment Of Total Float columnAndon Potential Claim Grid: Verify The Text Allignment Of Total Float column");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            var columnName = "Total Float";
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

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await RiskSentinelPage_mavryck.ClickOnTextAllignmentButton2();


                Test.Log(Status.Info, $" *** Verify The Text Alignment Of Columns *** ");
                await RiskSentinelPage_mavryck.VerifyTextAlignment_andon(columnName, textAllig_left, textAllig_right, textAllig_center, colIndex, step);


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
        public async Task Andon_Verify_Requirments_Of_PotentialClaim_Grid()
        {

            var Test = Extent.CreateTest("Andon: Verify The Requirments Of Potential Claim Grid");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
        
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Risk Sentinel </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnRiskSentinel();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await EnterpriseProjectPage_mavryck.SelectAppFromMenu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();
                await Task.Delay(15000);

                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                Test.Log(Status.Info, $" *** Verify The Grid Icons *** ");
                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Download Icon </b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyDownload_GridIcon());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Hide/UnHide Icon </b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.VerifyShowHide_GridIcon());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Full Screen Icon </b> is displaying");
                Assert.True(await RiskSentinelPage_mavryck.Verify_FullScreen_GridIcon());


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
        public async Task Verify_Hover_Feature_Of_Andon()
        {

            var Test = Extent.CreateTest("Andon: Verify The Hover Feature");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
            
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Core ***"));
                await RiskSentinelPage_mavryck.HoverGridView();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying"));
                Assert.True(await RiskSentinelPage_mavryck.VerifyHoverTooltip());

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Knock On Impact</b> Of Core ***"));
                await RiskSentinelPage_mavryck.HoverKnockOnImpact();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Knock Of Impact Hover Tooltip </b> is displaying"));
                Assert.True(await RiskSentinelPage_mavryck.VerifyHoverTooltip());

                testSteps.AddRange(await RiskSentinelPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Indicator</b> Of Grid ***"));
                await RiskSentinelPage_mavryck.HoverIndicators();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Indicator Tooltip</b> is displaying"));
                Assert.True(await RiskSentinelPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" ***  Scroll To <b>Potential Claims</b> *** ");
                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                testSteps.AddRange(await RiskSentinelPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));

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
        public async Task Verify_Grid_Resizing_Of_OverViewGrid_And_PotentialClaim_Grid()
        {
            var Test = Extent.CreateTest("Andon: Verify The Overview And Potential Claim Grid Is Successfully Resized");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel";
       
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Andon </b>");
                await RiskSentinelPage_mavryck.ClickOnAndon();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await RiskSentinelPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await RiskSentinelPage_mavryck.VerifyFullScreenOfGridIsDisplaying());
                await RiskSentinelPage_mavryck.ClickOnExitFullScreen();

                Test.Log(Status.Info, $"Step {++step}: Navigate to <b>Potential Claim</b> Grid");
                await ScrollToElement(page, $"//h3[text()='Potential Claims']");

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await RiskSentinelPage_mavryck.ClickOnResizeIcon1();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await RiskSentinelPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
        public async Task Andon_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Andon : Verify The Page Titles With Tooltips");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var RiskSentinelPage_mavryck = new RiskSentinelPage_mavryck(page, Test);
            var risksentinelTitle = "RiskSentinel"; 


            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Risk Sentinel </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(risksentinelTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Risk Sentinel App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(risksentinelTitle));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Andon</b> From Side Nav Menu");
                await RiskSentinelPage_mavryck.ClickOnAndon();

                await RiskSentinelPage_mavryck.VerifyPageTitleWithTooltip_Andon();


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