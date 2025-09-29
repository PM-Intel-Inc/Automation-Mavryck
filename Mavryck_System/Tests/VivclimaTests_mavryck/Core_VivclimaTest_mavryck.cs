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

    public class Core_VivclimaTest_mavryck : Base
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
        public async Task Vivclima_Verify_Hover_Feature_Of_Core()
        {
            var Test = Extent.CreateTest("Core: Verify The Hover Feature");
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


                Test.Log(Status.Info, $" *** Hover The  <b>Table View </b> Of Core ***");
                await VivclimaPage_mavryck.HoverTableView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Table View  Hover Tooltip </b> is displaying");
                Assert.True(await VivclimaPage_mavryck.VerifyHoverTooltip());

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
        public async Task Vivclima_Verify_PageTitles_Of_Core()
        {
            var Test = Extent.CreateTest("Core : Verify The Page Title");

            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var vivclimaTitle = "Vivclima";
            var actualTitle = "Core";

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
        public async Task Vivclima_Verify_GridResizing_OF_Core()
        {
            var Test = Extent.CreateTest("Core : Verify The Grid Resizing Of Core");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Resize Icon</b> ");
                await VivclimaPage_mavryck.ClickOnResizeIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid Size</b> is expanded");
                Assert.True(await VivclimaPage_mavryck.VerifyFullScreenOfGridIsDisplaying());

            }

            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }


        [Test]
        public async Task Vivclima_Verify_OverView_DropdownValues_Of_Core()
        {
            var Test = Extent.CreateTest("Core : Verify The Overview Dropdown Values Of Core");

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> OverView Dropdown </b>");
                await VivclimaPage_mavryck.ClickOnOverViewDropdown();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Values Of Dropdown</b> ");
                Assert.True(await VivclimaPage_mavryck.VerifyDropDownValues());

            }

            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }



        [Test]
        public async Task Vivclima_Verify_PhaseValues_Changes_WhileSelecting_ValueFromOverView_Dropdown_CORE()
        {
            var Test = Extent.CreateTest("Core : Verify Phase Value Changes When Selecting Value From OverView Dropdown");
            string[] dropdownValues = { "Front End Development", "Detailed Engineering", "Procurement", "Construction" };

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

                Test.Log(Status.Info, $"Step {++step}: Click On <b> OverView Dropdown </b>");
                await VivclimaPage_mavryck.ClickOnOverViewDropdown();

                Test.Log(Status.Info, $"Step {++step}: Select <b>Values from Dropdown</b> ");
                for (int i = 0; i < dropdownValues.Length; i++)
                {
                    await VivclimaPage_mavryck.SelectValue(dropdownValues[i]);
                    Assert.True(await VivclimaPage_mavryck.VerifyPhasevalue(dropdownValues[i]));
                }
            }

            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);

            }
        }

        [Test]
        public async Task Vivclima_Verify_TextAllignment_Of_Phase_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Phase Column");
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
        public async Task Vivclima_Verify_TextAllignment_Of_Discipline_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Discipline Column");
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
                await Task.Delay(15000);

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
        public async Task Vivclima_Verify_TextAllignment_Of_EmittingActivity_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Emitting Activity Column");
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
        public async Task Vivclima_Verify_TextAllignment_Of_EmissionFactorCategory_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Emission Factor Category Column");
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
        public async Task Vivclima_Verify_TextAllignment_Of_Consumption_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Consumption Column");
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
        public async Task Vivclima_Verify_TextAllignment_Of_CarbonEmission_Column()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Carbon Emission Column");
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
        public async Task Vivclima_Verify_TextAllignment_Of_CarbonTax_sColumn()
        {
            var Test = Extent.CreateTest("Core: Verify The Text Allignment Of Carbon Tax Column");
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
            var columnName = "Carbon Tax";
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

    }
}