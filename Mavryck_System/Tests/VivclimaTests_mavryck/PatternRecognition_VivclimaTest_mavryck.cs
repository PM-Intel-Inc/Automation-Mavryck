using System;
using System.Collections;
using System.Drawing;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;

namespace Mavryck_System.Tests.VivclimaTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class PatternRecognition_VivclimaTest_mavryck : Base
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
        public async Task Vivclima_Verify_Hover_Feature_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("Pattern Recognition: Verify The Hover Feature");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            
            var vivclimaTitle = "Vivclima";
            byte[] screenshotBytes = null;

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

              

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();
                await Task.Delay(10000);

                Test.Log(Status.Info, $" *** Hover The  <b>Trends</b> Of Pattern Recognition ***");
                await VivclimaPage_mavryck.HoverTrendFeature();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Trends Hover Tooltip </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Anomalies</b> Of Andon ***");
                await VivclimaPage_mavryck.HoverAnomaliesFeature();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Anomalies Hover Tooltip </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyHoverTooltip());

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
        public async Task Vivclima_Verify_PageTitles_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("Pattern Recognition : Verify The Page Titles With Tooltips");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var actualTitle = "Pattern Recognition";
            var vivclimaTitle = "Vivclima";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

         
                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));
                await Task.Delay(15000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();


                await CommonFeaturesPage_mavryck.VerifyPageTitleWithTooltip(actualTitle);
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task Viclima_Verify_WordCloud_Chart_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("PatternRecognition: Verify The WordCloud Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            
            var vivclimaTitle = "Vivclima";
            var title = "WordCloud";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Word Cloud</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyWordCloudIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Word Cloud</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Viclima_Verify_MapResizing_Of_WordCloud_Chart_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("PatternRecognition: Verify The WordCloud Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            
            var vivclimaTitle = "Vivclima";
            var title = "WordCloud";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Word Cloud</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyWordCloudIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Word Cloud</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Viclima_Verify_FrequencyDistribution_of_CarbonTax_Chart_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("PatternRecognition: Verify The Frequency Distribution of Carbon Tax Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            
            var vivclimaTitle = "Vivclima";
            var title = "Frequency Distribution of Carbon Tax";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Frequency Distribution of Carbon Tax</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyFrequencyDistributionOfCarboxTaxIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Frequency Distribution of Carbon Tax</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Viclima_Verify_MapResizing_Of_FrequencyDistribution_of_CarbonTax_Chart_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("PatternRecognition: Verify The Frequency Distribution of Carbon Tax Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            
            var vivclimaTitle = "Vivclima";
            var title = "Frequency Distribution of Carbon Tax";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Frequency Distribution of Carbon Tax</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyFrequencyDistributionOfCarboxTaxIsDisplaying());


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Frequency Distribution of Carbon Tax</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Viclima_Verify_FrequencyDistribution_of_CarbonEmission_Chart_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("PatternRecognition: Verify The Frequency Distribution of Carbon Emission Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            
            var vivclimaTitle = "Vivclima";
            var title = "Frequency Distribution of Carbon Emission";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Frequency Distribution of Carbon Emission</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyFrequencyDistributionOfCarbox_Emission_IsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Frequency Distribution of Carbon Emission </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Viclima_Verify_MapResizing_Of_FrequencyDistribution_of_CarbonEmission_Chart_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("PatternRecognition: Verify The Frequency Distribution of Carbon Emission Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            
            var vivclimaTitle = "Vivclima";
            var title = "Frequency Distribution of Carbon Emission";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Frequency Distribution of Carbon Emission</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyFrequencyDistributionOfCarbox_Emission_IsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Frequency Distribution of Carbon Emission </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Viclima_Verify_AnomaliesInCarbonAndMaterials_Chart_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) :  Verify The Frequency Distribution of Carbon Emission Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            
            var vivclimaTitle = "Vivclima";
            var title = "Anomalies in Carbon and Materials";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies </b>");
                await VivclimaPage_mavryck.ClickOnAnomalies();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Anomalies in Carbon and Materials</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyAnomalies_In_Carbon_And_Materials_IsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Anomalies in Carbon and Materials</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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
        public async Task Viclima_Verify_MapResizing_Of_AnomaliesInCarbonAndMaterials_Chart_Of_PatternRecognition()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) :  Verify The Frequency Distribution of Carbon Emission Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            
            var vivclimaTitle = "Vivclima";
            var title = "Anomalies in Carbon and Materials";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Vivclima </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(vivclimaTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Vivclima App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(vivclimaTitle));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition </b>");
                await VivclimaPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies </b>");
                await VivclimaPage_mavryck.ClickOnAnomalies();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Anomalies in Carbon and Materials</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyAnomalies_In_Carbon_And_Materials_IsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Anomalies in Carbon and Materials</b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyChartNameIsDisplaying(title));

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