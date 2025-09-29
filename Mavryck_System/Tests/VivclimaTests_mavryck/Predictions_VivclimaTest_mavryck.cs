using System;
using System.Collections;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;
using Mavryck_System.Pages;

namespace Mavryck_System.Tests.VivclimaTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class Predictions_VivclimaTest_mavryck : Base
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
        public async Task Predictions_Verify_Hover_Feature()
        {
            var Test = Extent.CreateTest("Predictions: Verify The Hover Feature");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $" *** Hover The  <b>Trends Feature</b> Of Predictions ***");
                await VivclimaPage_mavryck.HoverTrendFeature();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Trends Hover Tooltip </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Recommendations </b> Of Predictions ***");
                await VivclimaPage_mavryck.HoverRecommendationsFeature();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Recommendations Hover Tooltip </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyHoverTooltip());


                Test.Log(Status.Info, $" *** Hover The  <b>Air Quality Feature </b> Of Predictions ***");
                await VivclimaPage_mavryck.HoverAirQuality();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Air Quality  Hover Tooltip </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyHoverTooltip());

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Verified Grid View", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());

            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task Vivclima_Verify_PageTitle_Of_Predictions()
        {
            var Test = Extent.CreateTest("Predictions : Verify The Page Title");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
            var actualTitle = "Predictions";
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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                await CommonFeaturesPage_mavryck.VerifyPageTitleWithTooltip(actualTitle) ;
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task Predictions_Verify_TotalPredicted_CarbonTax_Chart()
        {
            var Test = Extent.CreateTest("Predictions: Verify The Total Predicted Carbon Tax Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Total Predicted Carbon Tax";

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
                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Predicted Carbon Tax</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyTotal_Predicted_Carbon_TaxIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Total Predicted Carbon Tax</b> is displaying");
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
        public async Task Predictions_Verify_MapResizing_Of_TotalPredicted_CarbonTax_Chart()
        {
            var Test = Extent.CreateTest("Predictions: Verify The Map Resizing Of Total Predicted Carbon Tax Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Total Predicted Carbon Tax";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Predicted Carbon Tax</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyTotal_Predicted_Carbon_TaxIsDisplaying());


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Total Predicted Carbon Tax</b> is displaying");
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
        public async Task Predictions_Verify_TotalPredicted_Emission_Chart()
        {
            var Test = Extent.CreateTest("Predictions: Verify The Total Predicted Emission Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Total Predicted Emission";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();
                await Task.Delay(1000);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Total Predicted Emission</b> ");
                await VivclimaPage_mavryck.ClickOnTotalPredictedEmission();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Predicted Emission</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyTotal_Predicted_Carbon_TaxIsDisplaying());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Total Predicted Emission</b> is displaying");
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
        public async Task Predictions_Verify_MapResizing_Of_TotalPredicted_Emission_Chart()
        {
            var Test = Extent.CreateTest("Predictions: Verify The Map Resizing Of Total Predicted Emission Chart");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var title = "Total Predicted Emission";

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
                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Total Predicted Emission</b>");
                await VivclimaPage_mavryck.ClickOnTotalPredictedEmission();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Predicted Emission</b> is visible");
                Assert.True(await VivclimaPage_mavryck.VerifyTotal_Predicted_Carbon_TaxIsDisplaying());


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                Test.Log(Status.Info, $"Step {++step}: Verify the Map  Title: <b>Total Predicted Emission</b> is displaying");
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
        public async Task Predictions_Verify_TextAllignment_Of_Phase_Column()
        {
            var Test = Extent.CreateTest("Predictions (Recommendations) :  Verify The Text Allignment Of Phase Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Phase";
            var colIndex = "1";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_TextAllignment_Of_Discipline_Column()
        {
            var Test = Extent.CreateTest("Predictions (Recommendations) :  Verify The Text Allignment Of Discipline Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Discipline";
            var colIndex = "2";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_TextAllignment_Of_EmittingActivity_Column()
        {
            var Test = Extent.CreateTest("Predicitons (Recommendations ):  Verify The Text Allignment Of EmittingActivity Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Emitting Activity";
            var colIndex = "3";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_TextAllignment_Of_EmissionFactorCategory_Column()
        {
            var Test = Extent.CreateTest("Predictions (Recommendations):  Verify The Text Allignment Of Emission Factor Category Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Emission Factor Category";
            var colIndex = "4";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_TextAllignment_Of_ConsumptionUnit_Column()
        {
            var Test = Extent.CreateTest("Predictions (Recommendations):  Verify The Text Allignment Of Consumption Unit Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Consumption Unit";
            var colIndex = "5";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_TextAllignment_Of_Consumption_Column()
        {
            var Test = Extent.CreateTest("Predicitons (Recommendation):  Verify The Text Allignment Of Consumption Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Consumption";
            var colIndex = "6";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_TextAllignment_Of_CarbonEmission_Column()
        {
            var Test = Extent.CreateTest("Predicitons (Recommendations):  Verify The Text Allignment Of Carbon Emission Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Carbon Emission";
            var colIndex = "7";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_TextAllignment_Of_CarbonAfter_Column()
        {
            var Test = Extent.CreateTest("Predicitons (Recommendations):  Verify The Text Allignment Of Emission After Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Emission After";
            var colIndex = "8";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_TextAllignment_Of_Recommendations_Column()
        {
            var Test = Extent.CreateTest("Predicitons (Recommendations):  Verify The Text Allignment Of Recommendations Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Recommendations";
            var colIndex = "9";

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


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_TextAllignment_Of_RecommendationsPercentage_Column()
        {
            var Test = Extent.CreateTest("Predicitons (Recommendations):  Verify The Text Allignment Of Recommendations  Percentage Column");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
            var vivclimaTitle = "Vivclima";
            var textAllig_left = "Left";
            var textAllig_right = "Right";
            var textAllig_center = "Center";
            var columnName = "Recommendations Percentage";
            var colIndex = "10";

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b> ");
                await VivclimaPage_mavryck.ClickOnRecommendations();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Text Allignment </b> Button From Grid");
                await VivclimaPage_mavryck.ClickOnTextAllignmentButton();

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
        public async Task Predictions_Verify_Hover_Feature_Recommendations()
        {
            var Test = Extent.CreateTest("Predictions: Verify The Hover Feature of Recommendations");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b>");
                await VivclimaPage_mavryck.ClickOnRecommendations();


                await VivclimaPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover();


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Verified Grid View", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());

            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task Predictions_Verify_Recommendations_GridResizing()
        {
            var Test = Extent.CreateTest("Predictions:  Verify The Recommendations Grid Resizing");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var VivclimaPage_mavryck = new VivclimaPage_mavryck(page, Test);
           
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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Predictions</b> From Side Nav Menu");
                await VivclimaPage_mavryck.ClickOnPredictions();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Recommendations</b>");
                await VivclimaPage_mavryck.ClickOnRecommendations();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

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
    