using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_System.Pages;
using Mavryck_System.Utils;
using System;
using System.Threading.Tasks;
using PlanNotePlaywrite;
using System.Threading;
using System.Collections;

namespace Mavryck_System.Tests.TimeManagerTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class Diagnostics_Test_mavryck : Base
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
        public async Task Diagnostics_Verify_TextAllignment_Of_ID_Column()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Text Allignment Of ID Column");
            
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
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

             

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                 Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

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


        [Test]
        public async Task Diagnostics_Verify_TextAllignment_Of_Criteria_Column()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Text Allignment Of Criteria Column");
            
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var columnName = "Criteria";
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

              

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                 Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

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


        [Test]
        public async Task Diagnostics_Verify_TextAllignment_Of_Baseline_Column()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Text Allignment Of Baseline Column");
           
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var columnName = "Baseline";
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

             

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                 Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

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


        [Test]
        public async Task Diagnostics_Verify_Hover_Feature_Of_ScheduleQualityIndex()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Hover Feature Of Schedule Quality Index");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

              

                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                 Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu");
                await TimeManagerPage_mavryck.ClickOnDiagnostics();
                

                testSteps.AddRange(await TimeManagerPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

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
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
          

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu"));
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying"));
                 Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu"));
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Deep Analysis </b>"));
                await TimeManagerPage_mavryck.ClickOnDeepAnalysis();

                testSteps.Add(Test.Log(Status.Info, $" <b> **** Wait For Few Seconds (Report is generating ) ****"));
                

                testSteps.AddRange(await TimeManagerPage_mavryck.VerifyDeepAnalysisReport(step));



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
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu"));
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying"));
                 Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu"));
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Complaince </b>"));
                await TimeManagerPage_mavryck.ClickOnComplaince();
               

                testSteps.AddRange(await TimeManagerPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
                await TimeManagerPage_mavryck.ClickOnResizeIcon();

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



        [Test]
        public async Task Diagnostics_Verify_ContractAnalyzer_Report()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Contract Analyzer Report ");            
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

              

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu"));
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying"));
                 Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu"));
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Contract Analyzer </b>"));
                await TimeManagerPage_mavryck.ClickOnContractAnalysis();
                
                testSteps.Add(Test.Log(Status.Info, $" <b> **** Wait For Few Seconds (Report is generating ) ****"));
                await Task.Delay(120000);
                Assert.True(await TimeManagerPage_mavryck.VerifyContractAnalysisReport(step));



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
        public async Task Diagnostics_Verify_ReportAnalyzer_Report()
        {
            var Test = Extent.CreateTest("Diagnostics: Verify The Report Analyzer Report ");
          
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App From Top Right Menu"));
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying"));
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu"));
                await TimeManagerPage_mavryck.ClickOnDiagnostics();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Report Analyzer </b>"));
                await TimeManagerPage_mavryck.ClickOnReportAnalysis();

                testSteps.Add(Test.Log(Status.Info, $" <b> **** Wait For Few Seconds (Report is generating ) ****"));
                await Task.Delay(120000);
                Assert.True(await TimeManagerPage_mavryck.VerifyReportAnalysisReport(step));


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
        public async Task Diagnostics_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Diagnostics : Verify The Page Titles With Tooltips");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var timeManagerTitle = "NeuroDynamiq";
            var actualTitle = "Diagnostics";

            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> NeuroDynamiq </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(timeManagerTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>NeuroDynamiq App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle));

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Diagnostics </b> From Side Nav Menu"));
                await TimeManagerPage_mavryck.ClickOnDiagnostics();


                await CommonFeaturesPage_mavryck.VerifyPageTitleWithTooltip(actualTitle);

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