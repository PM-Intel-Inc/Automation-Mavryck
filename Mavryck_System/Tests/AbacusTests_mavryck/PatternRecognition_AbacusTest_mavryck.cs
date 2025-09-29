using System;
using System.Collections;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Pages;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using PlanNotePlaywrite;

namespace Mavryck_System.Tests.AbacusTests_mavryck
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]

    public class PatternRecognition_AbacusTest_mavryck : Base
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
        public async Task PatternRecognition_Verify_TotalFloatIndex_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends) : Verify The Total Float Index Chart");
            int step = 0;   
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var testSteps = new ArrayList();
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "Total Float Index";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Float Index Map </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyTotalFloat_Index_Map());

                Test.Log(Status.Info, $"Step {++step}: Verify the Bar Chart Title: <b>Total Float Index</b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_TotalFloatIndex_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends)  : Verify The Resizing Of Total Float Index Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));




                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Float Index Map </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyTotalFloat_Index_Map());


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose(); 
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_CriticalActivitiesTrending_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends)  : Verify The Critical Activities Trending Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var title = "Critical Activities Trending";
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Critical Activities Trending</b>");
                await AbacusPage_mavryck.ClickOnCriticalActivitiesTrending();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Critical Activities Trending Map </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyCriticalActivitiesTrendingMap());

                Test.Log(Status.Info, $"Step {++step}: Verify the Bar Chart Title: <b>Critical Activities Trending</b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_CriticalActivitiesTrending_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends)  : Verify The Resizing Of  Critical Activities Trending Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));




                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Critical Activities Trending</b>");
                await AbacusPage_mavryck.ClickOnCriticalActivitiesTrending();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Critical Activities Trending Map </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyCriticalActivitiesTrendingMap());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_SCurve_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends) : Verify The S Curve Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "S Curve Graph";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>S Curve Map </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifySCurveGraph());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>S Curve Graph</b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_SCurve_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends) : Verify The Resizing Of S Curve Chart");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>S Curve Map </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifySCurveGraph());


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }



        [Test]
        public async Task PatternRecognition_Verify_RollingAverage_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends)  : Verify The Rolling Average Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "Rolling Average";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));




                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Rolling Average </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyRollingAverage());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b> Rolling Average </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }



        [Test]
        public async Task PatternRecognition_Verify_Resizing_OF_RollingAverage_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends): Verify The Resizing Of  Rolling Average Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));




                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Rolling Average </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyRollingAverage());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }
      


        [Test]
        public async Task PatternRecognition_Verify_PolynomialTrendLine_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends) : Verify The Polynomial Trend Line Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "Polynomial Trend Line";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Polynomial Trend Line </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyPolynomialTrendLine());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b> Polynomial Trend Line </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_PolynomialTrendLine_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends) : Verify The Resizing Of Polynomial Trend Line Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));




                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Polynomial Trend Line </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyPolynomialTrendLine());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }

        [Test]
        public async Task PatternRecognition_Verify_LinearTrendLine_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends) : Verify The Linear Trend Line Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "Linear Trend Line";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));




                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Linear Trend Line </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyLinearTrendLine());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b> Linear Trend Line </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }

        [Test]

        public async Task PatternRecognition_Verify_ResizingOf_LinearTrendLine_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Trends): Verify The Resizing Of Linear Trend Line Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Linear Trend Line </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyLinearTrendLine());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }



        [Test]
        public async Task PatternRecognition_Verify_Task_Over_Runs_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Task Over Runs  Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "Task Over Runs";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b> ");
                await AbacusPage_mavryck.ClickOnAnomalies();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Task Over Runs </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyTaskOverRuns());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b> Task Over Runs  </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_Task_Over_Runs_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Resizing Of Task Over Runs  Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b> ");
                await AbacusPage_mavryck.ClickOnAnomalies();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Task Over Runs </b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyTaskOverRuns());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_Number_Of_DelayEvents_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Number Of Delay Events Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "Number of Delay Events";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));




                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b> ");
                await AbacusPage_mavryck.ClickOnAnomalies();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Number Of Delay Events</b> ");
                await AbacusPage_mavryck.ClickOnNumberOfDelayEvents();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Number Of Delay Events</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyNumberOfDelayEvents());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b> Number Of Delay Events  </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_Number_Of_DelayEvents_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Resizing Of Number Of Delay Events Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b> ");
                await AbacusPage_mavryck.ClickOnAnomalies();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Number Of Delay Events</b> ");
                await AbacusPage_mavryck.ClickOnNumberOfDelayEvents();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Number Of Delay Events</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyNumberOfDelayEvents());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_Z_Score_AnomalyDetection_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Z Score Anomaly Detection Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "Z-Score Anomaly Detection";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b> ");
                await AbacusPage_mavryck.ClickOnAnomalies();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Z-Score Anomaly Detection</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyZScoreAnomalyDetection());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b> Z-Score Anomaly Detection</b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }

        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_Z_Score_AnomalyDetection_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Resizing Of Z Score Anomaly Detection Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b> ");
                await AbacusPage_mavryck.ClickOnAnomalies();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Z-Score Anomaly Detection</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyZScoreAnomalyDetection());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }

        [Test]
        public async Task PatternRecognition_Verify_IsolationForest_AnomalyDetection_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Isolation Forest Anomaly Detection Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "Isolation Forest Anomaly Detection";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));




                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b> ");
                await AbacusPage_mavryck.ClickOnAnomalies();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Isolation Forest Anomaly Detection</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyIsolationForestAnomalyDetection());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Isolation Forest Anomaly Detection </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }

        [Test]
        public async Task PatternRecognition_Verify_ResizingOf_IsolationForest_AnomalyDetection_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Resizing Of Isolation Forest Anomaly Detection Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));




                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Anomalies</b> ");
                await AbacusPage_mavryck.ClickOnAnomalies();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Isolation Forest Anomaly Detection</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyIsolationForestAnomalyDetection());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());


                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_CorrelationHeat_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Correlation Heat Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";
            var title = "Correlation heat map";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Correlation</b> ");
                await AbacusPage_mavryck.ClickOnCorrelation();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Heat Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyCorrelationHeatMap2());

                Test.Log(Status.Info, $"Step {++step}: Verify the Map Title: <b>Correlation Heat Map </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyChartNameIsDisplaying(title));

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }



        [Test]
        public async Task PatternRecognition_Verify_Resizing_Of_CorrelationHeat_Map()
        {
            var Test = Extent.CreateTest("Pattern Recognition (Anomalies) : Verify The Resizing Of Correlation Heat Map");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b>Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Correlation</b> ");
                await AbacusPage_mavryck.ClickOnCorrelation();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Heat Map</b> is visible");
                Assert.True(await AbacusPage_mavryck.VerifyCorrelationHeatMap2());

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> Of Overview Grid ");
                await AbacusPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await AbacusPage_mavryck.VerifyFullScreenOfGridIsDisplaying());



                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await browser.CloseAsync();
                playwright.Dispose();
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
                await browser.CloseAsync();
                playwright.Dispose();
            }
        }


        [Test]
        public async Task PatternRecognition_Verify_Hover_Feature()
        {
            var Test = Extent.CreateTest("Abacus (Pattern Recognition) : Verify The Hover Feature");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();
                await Task.Delay(10000);

                Test.Log(Status.Info, $" *** Hover The  <b> Trends </b> ***");
                await AbacusPage_mavryck.HoverTrends();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Trends Hover Tooltip </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b> Correlation </b> ***");
                await AbacusPage_mavryck.HoverCorrelation();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Hover Tooltip </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b> Anomalies </b> ***");
                await AbacusPage_mavryck.HoverAnomalies();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Anomalies Hover Tooltip </b> is displaying");
                Assert.True(await AbacusPage_mavryck.VerifyHoverTooltip());

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
        public async Task PatternRecognition_Verify_PageTitles_WithTooltips()
        {
            var Test = Extent.CreateTest("Pattern Recognition: Verify The Page Titles With Tooltips");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var Abacus = "Abacus";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(Abacus);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(Abacus));



                Test.Log(Status.Info, $"Step {++step}: Click On <b> Pattern Recognition</b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnPatternRecognition();


                await AbacusPage_mavryck.VerifyPageTitleWithTooltip_PatternRecognition();
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