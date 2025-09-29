
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

    public class BuildYourBid_AbacusTest_mavryck : Base
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
        public async Task BuildYourBid_VerifyTransferTheProject_navigates_To_Core()
        {
            var Test = Extent.CreateTest("Build Your Bid: Verify That Transfer The Project Navigates To The Core Grid");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacusTitle = "Abacus";
         

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Build Your Bid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnBuildYourBid();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Transfer Icon </b> ");
                await AbacusPage_mavryck.ClickOnTransfer();

                Test.Log(Status.Info, $"Step {++step}: <b>  Select Project </b> ");
                await AbacusPage_mavryck.SelectTransferProject();

                Test.Log(Status.Info, $"Step {++step}: <b>  Select Version </b> ");
                await AbacusPage_mavryck.SelectTransferVersion();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Transfer Button </b> ");
                await AbacusPage_mavryck.ClickOnTransferButton();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>User Is Navigated To Core Grid </b>");
                Assert.True(await AbacusPage_mavryck.VerifyCoreTitle());

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
        public async Task BuildYourBid_Verify_Details_Of_Setup_Grid()
        {
            var Test = Extent.CreateTest("Build Your Bid: Verify The Details Of Setup Grid");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacusTitle = "Abacus";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Build Your Bid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnBuildYourBid();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Labor Grid Header</b>");
                Assert.True(await AbacusPage_mavryck.VerifyLaborGridHeader());
                //await AbacusPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover();


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
        public async Task BuildYourBid_Verify_Details_Of_Build_Grid()
        {
            var Test = Extent.CreateTest("Build Your Bid: Verify The Details Of Build Grid");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacusTitle = "Abacus";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Build Your Bid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnBuildYourBid();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Build </b> ");
                await AbacusPage_mavryck.ClickOnBuild();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Build Grid Header</b>");
                Assert.True(await AbacusPage_mavryck.VerifyBuildGridHeader());
                await AbacusPage_mavryck.VerifyDownload_FullScreen_HideUnhide_Hover();

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
        public async Task BuildYourBid_Verify_The_PageTitles_With_Tooltips()
        {
            var Test = Extent.CreateTest("Build Your Bid: Verify The Page Titles With Tooltips");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var AbacusPage_mavryck = new AbacusPage_mavryck(page, Test);
            var abacusTitle = "Abacus";


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Select<b> Abacus </b> App");
                await CommonFeaturesPage_mavryck.SelectAppFromTopRight_Menu(abacusTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Abacus App </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(abacusTitle));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Build Your Bid </b> From Side Nav Menu");
                await AbacusPage_mavryck.ClickOnBuildYourBid();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Build </b> ");
                await AbacusPage_mavryck.ClickOnBuild();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Page Titles With Tooltips</b>");
                await AbacusPage_mavryck.VerifyPageTitleWithTooltip_BuildYourBid();

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