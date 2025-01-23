using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using System;
using System.Threading.Tasks;
using PlanNotePlaywrite;
using System.Collections;
using AventStack.ExtentReports.Reporter.Filter;
using System.Threading;

namespace Mavryck_TimeManager.Tests
{
    [Order(3)]
    public class EnterpriseProjectTest_mavryck : Base
    {
        private IPlaywright playwright;
        private IBrowser browser;
        private IBrowserContext context;
        private int step;
        ArrayList testSteps;

        [SetUp]
        public async Task Setup()
        {
            playwright = await PlaywrightConfig.ConfigurePlaywrightAndLaunchBrowser();
            browser = await PlaywrightConfig.LaunchChromiumBrowser(playwright, chromiumExecutablePath, false);
            step = 0;
            testSteps = new ArrayList();

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });
        }

        [TearDown]
        public async Task Teardown()
        {
            await browser.CloseAsync();
        }

        //[Test, Order(1)]
        public async Task VerifyThe_NewProjectRequirements()
        {
            var page = await context.NewPageAsync();
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            try
            {
                Test = Extent.CreateTest("Verify Required Fields For Project Creation.");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count ;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Enterprise Directory</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyEnterpriseDashboardIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Create New Project </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnCreateProjectButton();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project Name</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectNameIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Industry </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyIndustryIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Location <b> button is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyLocationIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Currenct <b>  is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyCurrencyIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Project Status <b>  is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectStatusIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Save Button <b>  is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifySaveButtonIsVisible());


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Cancel Button <b>  is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyCancelButtonIsVisible());



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


        //[Test, Order(2)]

        public async Task VerifyUserCan_CreateProject()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string projectName = "Automation Project";
            string status = "Active";
            string industry = "IT";
            string location = "Canada";
            string currency = "USD";
            string vivclimaIcon = "vivclima.svg";
            string timeManager = "projectManager.svg";
            string cost = "cost.svg";
            string saif = "CV.svg";
            string estimation = "estimation.svg";

            try
            { 
                Test = Extent.CreateTest("Verify User Can Successfully Create The Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count ;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.AddRange(await EnterprisePage_mavryck.CreateProject(step , projectName , industry , location , currency , status));
                step = testSteps.Count ;

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $" ** Verify the <b>Project : " + projectName + "</b> Details ***");

                Test.Log(Status.Info, $"Step {++step}: Verify Industry ");
                Assert.True(await EnterprisePage_mavryck.VerifyListViewRequirementsIsVisible(industry));

                Test.Log(Status.Info, $"Step {++step}: Verify Location ");
                Assert.True(await EnterprisePage_mavryck.VerifyListViewRequirementsIsVisible(location));

                Test.Log(Status.Info, $"Step {++step}: Verify Currency ");
                Assert.True(await EnterprisePage_mavryck.VerifyListViewRequirementsIsVisible(currency));

                Test.Log(Status.Info, $"Step {++step}: Verify Edit Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyThreeDot());

                Test.Log(Status.Info, $" ** Verify All the  <b>Project : " + projectName + "</b> Application Icons ** ");

                Test.Log(Status.Info, $"Step {++step}: Verify Vivclima Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons(vivclimaIcon));

                Test.Log(Status.Info, $"Step {++step}: Verify Time Manager Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Verify Cost Brain Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons(cost));


                Test.Log(Status.Info, $"Step {++step}: Verify SAIF Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons(saif));

                Test.Log(Status.Info, $"Step {++step}: Verify Estimator Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons(estimation));




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

        [Test, Order(3)]
        public async Task VerifyProjectDetails_In_ListView_Tab()

        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string projectName = "Mavryck Automation Project";
            string status = "Paused";
            string industry = "Education";
            string location = "AU";
            string currency = "ANG";
            string vivclimaIcon = "vivclima.svg";
            string timeManager = "projectManager.svg";
            string cost = "cost.svg";
            string saif = "CV.svg";
            string estimation = "estimation.svg";

            try
            {
                Test = Extent.CreateTest("Verify Details of Created Project In List View Tab");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $" ** Verify the  <b>Project : " + projectName + "</b> details ** ");

                Test.Log(Status.Info, $"Step {++step}: Verify Industry ");
                Assert.True(await EnterprisePage_mavryck.VerifyListViewRequirementsIsVisible(industry));

                Test.Log(Status.Info, $"Step {++step}: Verify Location ");
                Assert.True(await EnterprisePage_mavryck.VerifyListViewRequirementsIsVisible(location));

                Test.Log(Status.Info, $"Step {++step}: Verify Currency ");
                Assert.True(await EnterprisePage_mavryck.VerifyListViewRequirementsIsVisible(currency));

                Test.Log(Status.Info, $"Step {++step}: Verify Edit Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyThreeDot());

                Test.Log(Status.Info, $" ** Verify All the  <b>Project : " + projectName + "</b> Application Icons ** ");

                Test.Log(Status.Info, $"Step {++step}: Verify Vivclima Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons(vivclimaIcon));

                Test.Log(Status.Info, $"Step {++step}: Verify Time Manager Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Verify Cost Brain Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons2(cost));


                Test.Log(Status.Info, $"Step {++step}: Verify SAIF Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons2(saif));

                Test.Log(Status.Info, $"Step {++step}: Verify Estimator Icon ");
                Assert.True(await EnterprisePage_mavryck.VerifyAppIcons2(estimation));

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

        // ----- MAVRYCK Team did not allowed the user to create project
        //[Test, Order(4)]
        public async Task VerifyUserCannot_CreateProject_WithEmptyFields()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify User Unable To Create The Project With Empty Fields");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Create New Project </b> Button");
                await EnterprisePage_mavryck.ClickOnCreateProjectButton();

                Test.Log(Status.Info, $"Step {++step}: Click <b> Save Button <b> ");
                await EnterprisePage_mavryck.ClickOnSaveButton();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Error Popup </b> is displaying"));
                Assert.True(await EnterprisePage_mavryck.VerifyErrorPopup());


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


        [Test, Order(5)]
        public async Task Verify_Apps_Functionality_OfProject()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string vivclimaIcon = "vivclima.svg";
            string viclimaTitle = " Vivclima";
            string timeManager = "projectManager.svg";
            string timeManagerTitle = " Time Manager";
            string cost = "cost.svg";
            string costTitle = " CostBrain";
            string saif = "CV.svg";
            string saifTitle = " s AI f";
            string estimation = "estimation.svg";
            string estimationTitle = " AIstimate Pro";
            
            try
            {
                Test = Extent.CreateTest("Verify Application Icons Are Functionaing Properly Of Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click <b> Vivclima Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons(vivclimaIcon);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(viclimaTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> Time Manager Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons(timeManager);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> Cost Brain Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons2(cost);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(costTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> SAIF Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons2(saif);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(saifTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click <b> Estimate Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons2(estimation);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(estimationTitle);
                await page.GoBackAsync();


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


        [Test, Order(6)]
        public async Task Verify_Apps_Functionality_OfProject_ListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string vivclimaIcon = "vivclima.svg";
            string viclimaTitle = " Vivclima";
            string timeManager = "projectManager.svg";
            string timeManagerTitle = " TimeManager";
            string cost = "cost.svg";
            string costTitle = " CostBrain";
            string saif = "CV.svg";
            string saifTitle = " s AI f";
            string estimation = "estimation.svg";
            string estimationTitle = " AIstimate Pro";

            try
            {
                Test = Extent.CreateTest("Verify Application Icons Are Functionaing Properly Of Project From List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View </b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click <b> Vivclima Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons(vivclimaIcon);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(viclimaTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> Time Manager Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons(timeManager);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> Cost Brain Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons2(cost);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(costTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> SAIF Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons2(saif);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(saifTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click <b> Estimate Icon <b> ");
                await EnterprisePage_mavryck.ClickOnAppIcons2(estimation);
                await EnterprisePage_mavryck.VerifyAppDashboardIsDisplaying(estimationTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


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
        
        [Test, Order(7)]
        public async Task Verify_Edit_TheExistingProject()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            try
            {
                Test = Extent.CreateTest("Verify User Can Edit The Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count ;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Three Dots </b>");
                await EnterprisePage_mavryck.ClickOnThreedot();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());

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

        [Test, Order(8)]
        public async Task Verify_Upload_ScheduleFile_Under_Project()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var Version = "1";
            try
            {
                Test = Extent.CreateTest("Verify User Can Upload The Schedule File Under The Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterprisePage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Schedule File <b>" + schedulefileName + " </b>");
                await EnterprisePage_mavryck.UploadScheduleFile();

                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterprisePage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterprisePage_mavryck.ClickUpload();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());



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

        [Test, Order(9)]
        public async Task Verify_Upload_CostFile_Under_Project()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string Version = "1";
            try
            {
                Test = Extent.CreateTest("Verify User Can Upload The Cost File Under The Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterprisePage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Cost File <b>" + costFileName + " </b>");
                await EnterprisePage_mavryck.UploadCostFile();


                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterprisePage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterprisePage_mavryck.ClickUpload();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());


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

        [Test, Order(10)]
        public async Task Verify_Upload_ContractFile_Under_Project()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string Version = "1";
            try
            {
                Test = Extent.CreateTest("Verify User Can Upload The Contract File Under The Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterprisePage_mavryck.ClickOnViewFilesButton();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Upload Contract File <b>" + contractFile + " </b>");
                await EnterprisePage_mavryck.UploadContractFile();

                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterprisePage_mavryck.SelectVersionNumber(Version);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterprisePage_mavryck.ClickUpload();

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());

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


        [Test, Order(11)]
        public async Task Verify_Upload_ScheduleFile_Under_Project_FromListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var Version = "1";
            try
            {
                Test = Extent.CreateTest("Verify User Can Upload The Schedule File Under The Project From List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterprisePage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Schedule File <b>" + schedulefileName + " </b>");
                await EnterprisePage_mavryck.UploadScheduleFile();

                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterprisePage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterprisePage_mavryck.ClickUpload();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());




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

        [Test, Order(12)]
        public async Task Verify_Upload_CostFile_Under_Project_FromListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string Version = "1";
            try
            {
                Test = Extent.CreateTest("Verify User Can Upload The Cost File Under The Project From List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterprisePage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Cost File <b>" + costFileName + " </b>");
                await EnterprisePage_mavryck.UploadCostFile();


                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterprisePage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterprisePage_mavryck.ClickUpload();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());

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

        [Test, Order(13)]
        public async Task Verify_Upload_ContractFile_Under_Project_FromListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string Version = "1";
            try
            {
                Test = Extent.CreateTest("Verify User Can Upload The Contract File Under The Project From List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterprisePage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Contract File <b>" + contractFile + " </b>");
                await EnterprisePage_mavryck.UploadContractFile();


                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterprisePage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterprisePage_mavryck.ClickUpload();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());

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


        [Test, Order(14)]
        public async Task Verify_CancelDeleting_The_Existing_Project()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            try
            {
                Test = Extent.CreateTest("Verify User Can  Cancel Deleting The Existing Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                //Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete </b> Icon");
                //await EnterprisePage_mavryck.ClickOnDeleteButton();

                //Test.Log(Status.Info, $"Step {++step}: Click On <b>No </b> button");
                //await EnterprisePage_mavryck.ClickOnNoButton();

                //Test.Log(Status.Info, $"Step {++step}: Verify <b>" + projectName + " </b> is displaying");
                //Assert.True(await EnterprisePage_mavryck.VerifyListViewProjectNameIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());

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


        [Test, Order(15)]
        public async Task Verify_CancelDeleting_The_Existing_Project_ListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Cancel Deleting The Existing Project From List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                //Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete </b> Icon");
                //await EnterprisePage_mavryck.ClickOnDeleteButton();


                //Test.Log(Status.Info, $"Step {++step}: Click On <b>No</b> button");
                //await EnterprisePage_mavryck.ClickOnNoButton();

                //Test.Log(Status.Info, $"Step {++step}: Verify <b>" + projectName + " </b> is displaying");
                //Assert.True(await EnterprisePage_mavryck.VerifyProjectNameIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());

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

        [Test, Order(16)]
        public async Task Verify_Deleting_The_Existing_Project()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            try
            {
                Test = Extent.CreateTest("Verify User Can Delete The Existing Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                //Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete </b> Icon");
                //await EnterprisePage_mavryck.ClickOnDeleteButton();

                //Test.Log(Status.Info, $"Step {++step}: Click On <b>Yes</b> button");
                //await EnterprisePage_mavryck.ClickOnYesButton();
                

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());



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


        [Test, Order(17)]
        public async Task Verify_Deleting_The_Existing_Project_From_ListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Delete The Existing Project From List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                //Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete </b> Icon");
                //await EnterprisePage_mavryck.ClickOnDeleteButton();


                //Test.Log(Status.Info, $"Step {++step}: Click On <b>Yes</b> button");
                //await EnterprisePage_mavryck.ClickOnYesButton();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());

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
        
        [Test, Order(18)]
        public async Task Verify_The_ApplicationFilters()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] applicationFilter = { "Time Manager", "Vivclima" , "s AI f", "AIstimate Pro" };
            string[] applicationIcons = { "projectManager", "vivclima",  "CV", "estimation" };

            //string[] applicationFilter = { "Time Manager", "Vivclima", "s AI f", "AIstimate Pro" , "CostBrain" ,"Reporting Manager" , "Contracts Manager" , "Resource Optimizer" , "Risk IQ" };
            //string[] applicationIcons = { "projectManager", "vivclima", "CV", "estimation", "cost"  , "xyz" , "xyz" , "xyz" , "xyz"};

            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Application");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();


                for (int i = 0; i < applicationFilter.Length; i++)
                {
                    string application = applicationFilter[i];
                    string icon = applicationIcons[i];

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Application </b> Filter And Select <b>{application}</b>");
                    await EnterprisePage_mavryck.ClickOnApplicationFilter();
                    await EnterprisePage_mavryck.SelectFilter(application);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterprisePage_mavryck.VerifyApplicationFilterProjects(icon))
                    {
                        Test.Log(Status.Info, $"Project Displayed after filtering by Application: {application}");
                    }
                    else
                    {
                        Test.Log(Status.Info, $"No project displayed after filtering by Application: {application}");
                    }
                }

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

        [Test, Order(19)]
        public async Task Verify_The_IndustryFilters()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] industryFilter = { "Education", "Finance", "Healthcare", "IT", "Manufacturing", "Oil & Gas", "Retail", "Transportation", "Other" };
            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Industry");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();


                foreach (var industryfilter in industryFilter)
                {
                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Industry </b> Filter And Select <b> " + industryfilter + " </b>");
                    await EnterprisePage_mavryck.ClickOnIndustryFilter();
                    await EnterprisePage_mavryck.SelectFilter(industryfilter);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterprisePage_mavryck.VerifyIndustryFilterProjects(industryfilter))
                    {
                        Test.Log(Status.Info, "Project Displayed after filtering by industry: " + industryfilter);
                    }
                    else
                    {
                        Test.Log(Status.Info, "No project displayed after filtering by industry: " + industryfilter);
                    }

                }

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


        [Test, Order(20)]
        public async Task Verify_The_StatusFilters()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] statusFilter = { "Active", "Completed" };
            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Status");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();


                foreach (var statusfilter in statusFilter)
                {

                    Test.Log(Status.Info, $"Step {++step}: Click On <b> Status </b> Filter And Select <b> " + statusfilter + " </b>");
                    await EnterprisePage_mavryck.ClickOnStatusFilter();
                    await EnterprisePage_mavryck.SelectFilter(statusfilter);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterprisePage_mavryck.VerifyStatusFilterProjects(statusfilter))
                    {
                        Test.Log(Status.Info, "Project Displayed after filtering by status: " + statusfilter);
                    }
                    else
                    {
                        Test.Log(Status.Info, "No project displayed after filtering by status: " + statusfilter);
                    }

                }
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


        [Test, Order(21)]
        public async Task Verify_The_ApplicationFilters_ListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] applicationFilter = { "Time Manager", "Vivclima", "s AI f", "AIstimate Pro", "CostBrain", "Reporting Manager", "Contracts Manager", "Resource Optimizer", "Risk IQ" };
            string[] applicationIcons = { "projectManager", "vivclima", "CV", "estimation", "cost", "xyz", "xyz", "xyz", "xyz" };

            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Application");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();


                for (int i = 0; i < applicationFilter.Length; i++)
                {
                    string application = applicationFilter[i];
                    string icon = applicationIcons[i];

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Application </b> Filter And Select <b>{application}</b>");
                    await EnterprisePage_mavryck.ClickOnApplicationFilter();
                    await EnterprisePage_mavryck.SelectFilter(application);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterprisePage_mavryck.VerifyApplicationFilterProjects(icon))
                    {
                        Test.Log(Status.Info, $"Project Displayed after filtering by Application: {application} with Icon: {icon}");
                    }
                    else
                    {
                        Test.Log(Status.Info, $"No project displayed after filtering by Application: {application} with Icon: {icon}");
                    }
                }

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


        [Test, Order(22)]
        public async Task Verify_The_IndustryFilters_ListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] industryFilter = { "Education", "Finance", "Healthcare", "IT", "Manufacturing", "Oil & Gas", "Retail", "Transportation", "Other" };
            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Location");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();


                foreach (var industryfilter in industryFilter)
                {
                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Industry </b> Filter And Select <b> " + industryfilter + " </b>");
                    await EnterprisePage_mavryck.ClickOnIndustryFilter();
                    await EnterprisePage_mavryck.SelectFilter(industryfilter);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterprisePage_mavryck.VerifyIndustryFilterProjects(industryfilter))
                    {
                        Test.Log(Status.Info, "Project Displayed after filtering by Location: " + industryfilter);
                    }
                    else
                    {
                        Test.Log(Status.Info, "No project displayed after filtering by Location: " + industryfilter);
                    }

                }

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


        [Test, Order(24)]
        public async Task Verify_The_StatusFilters_ListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] statusFilter = { "Active", "Completed" };
            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Status");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();


                foreach (var statusfilter in statusFilter)
                {

                    Test.Log(Status.Info, $"Step {++step}: Click On <b> Status </b> Filter And Select <b> " + statusfilter + " </b>");
                    await EnterprisePage_mavryck.ClickOnStatusFilter();
                    await EnterprisePage_mavryck.SelectFilter(statusfilter);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterprisePage_mavryck.VerifyStatusFilterProjects(statusfilter))
                    {
                        Test.Log(Status.Info, "Project Displayed after filtering by Status: " + statusfilter);
                    }
                    else
                    {
                        Test.Log(Status.Info, "No project displayed after filtering by Status: " + statusfilter);
                    }

                }
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



        [Test, Order(25)]
        public async Task Verify_UserCan_FilterThe_Project_UnderListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var applicationFilter = "Time Manager";
            var locationFilter = "Canada";
            var industryFilter = "Education";
            var statusFilter = "Completed";
            var currencyFilter = "CAD";
            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Under List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Application </b> Filter And Select <b>" + applicationFilter + " </b>");
                await EnterprisePage_mavryck.ClickOnApplicationFilter();
                await EnterprisePage_mavryck.SelectFilter(applicationFilter);
                await page.Mouse.DblClickAsync(300, 400);

                //Test.Log(Status.Info, $"Step {++step}: Verify <b> Time Manager </b>  Projects are displaying");
                //Assert.True(await EnterprisePage_mavryck.VerifyListViewProjectNameIsVisible());


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Location </b> Filter And Select <b>" + locationFilter + "</b>");
                await EnterprisePage_mavryck.ClickOnLocationFilter();
                await EnterprisePage_mavryck.SelectFilter(locationFilter);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Industry </b> Filter And Select <b> " + industryFilter + " </b>");
                await EnterprisePage_mavryck.ClickOnIndustryFilter();
                await EnterprisePage_mavryck.SelectFilter(industryFilter);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Currency </b> Filter And Select <b> " + currencyFilter + " </b>");
                await EnterprisePage_mavryck.ClickOnCurrencyFilter();
                await EnterprisePage_mavryck.SelectFilter(currencyFilter);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Status </b> Filter And Select <b> " + statusFilter + " </b>");
                await EnterprisePage_mavryck.ClickOnStatusFilter();
                await EnterprisePage_mavryck.SelectFilter(statusFilter);


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


        // ---- MAVRYCK TEAM did not allow the users to create  a program
        //[Test, Order(26)]
        public async Task VerifyUserCan_CreateProgram()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string programName = "Automation Program";
            string project = "Andarko Piling Project";
            string status = "Active";

            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Create The Program");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterprisePage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Create Programs </b> button");
                await EnterprisePage_mavryck.ClickOnCreateAProgram();


                Test.Log(Status.Info, $"Step {++step}: Enter Program Name: <b>" + programName + " </b>");
                await EnterprisePage_mavryck.EnterProjectName(programName);

                Test.Log(Status.Info, $"Step {++step}: Enter Program Status: <b>" + status + " </b>");
                await EnterprisePage_mavryck.SelectProgramStatus(status);

                Test.Log(Status.Info, $"Step {++step}: Enter Program Project Status: <b>" + status + " </b>");
                await EnterprisePage_mavryck.SelectProgramProjectStatus(project);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Create Program</b>");
                await EnterprisePage_mavryck.ClickOnCreateProgram();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Program : " + programName + "</b> is created successfully");
                Assert.True(await EnterprisePage_mavryck.VerifyProgramIsDisplaying(programName));

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


        [Test, Order(27)]
        public async Task Verify_Program_Details()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string programName = "Reno and Upgrade";

            try
            {
                Test = Extent.CreateTest("Verify All The Program Details and Requirments");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterprisePage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"*** Verify the <b>Program Details </b> *** ");
                Assert.True(await EnterprisePage_mavryck.VerifyProgramIsDisplaying(programName));
                Assert.True(await EnterprisePage_mavryck.VerifyViewProjectButtonIsDisplaying());
                Assert.True(await EnterprisePage_mavryck.VerifyDeleteButtonIsDisplaying());
                Assert.True(await EnterprisePage_mavryck.VerifyThreeDot());

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


        [Test, Order(28)]
        public async Task Verify_Program_Details_FromListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string programName = "Reno and Upgrade";
             
            try
            {
                Test = Extent.CreateTest("Verify All The Program Details and Requirments From List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterprisePage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"*** Verify the <b>Program Details </b> button");
                Assert.True(await EnterprisePage_mavryck.VerifyProgramIsDisplaying(programName));
                Assert.True(await EnterprisePage_mavryck.VerifyViewProjectButtonIsDisplaying());
                Assert.True(await EnterprisePage_mavryck.VerifyDeleteButtonIsDisplaying());
                Assert.True(await EnterprisePage_mavryck.VerifyThreeDot());

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

        [Test, Order(29)]
        public async Task VerifyUserCan_EditProgram()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Edit The Program");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

              
                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterprisePage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Three Dots </b> button");
                await EnterprisePage_mavryck.ClickOnThreedot();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());

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


        [Test, Order(30)]
        public async Task VerifyUserCan_EditProgram_ListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
          

            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Edit The Program From List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterprisePage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterprisePage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Three Dots </b> button");
                await EnterprisePage_mavryck.ClickOnThreedot();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());


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



        [Test, Order(31)]
        public async Task VerifyUserCan_DeleteProgram()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);


            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Delete The Program");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterprisePage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete  </b> Icon");
                await EnterprisePage_mavryck.ClickOnDeleteButton();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());


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

        [Test , Order(32)]
        public async Task VerifyUserCan_DeleteProgram_FromListView()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);


            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Delete The Program From List View");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterprisePage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete  </b> Icon");
                await EnterprisePage_mavryck.ClickOnDeleteButton();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterprisePage_mavryck.PleaseContactAdmin());


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


        [Test, Order(33)]
        public async Task Verify_Files_Details()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);           

            try
            {
                Test = Extent.CreateTest("Verify All The Files Details");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b>");
                await EnterprisePage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"*** Verify the <b>Files Details </b> ***");
                Assert.True(await EnterprisePage_mavryck.VerifyDateUploaded());
                Assert.True(await EnterprisePage_mavryck.VerifyLastUpdated());
                Assert.True(await EnterprisePage_mavryck.VerifyVersion());

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


        [Test, Order(34)]
        public async Task Verify_UserCan_FilterThe_FilesBy_Application()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] applicationFilter = { "Time Manager", "Vivclima"};
            string[] applicationIcons = { "projectManager", "vivclima"};
            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Files By Application");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b> from side nav menu");
                await EnterprisePage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();

                for (int i = 0; i < applicationFilter.Length; i++)
                {
                    string application = applicationFilter[i];
                    string icon = applicationIcons[i];

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Application </b> Filter And Select <b>{application}</b>");
                    await EnterprisePage_mavryck.ClickOnApplicationFilter();
                    await EnterprisePage_mavryck.SelectFilter(application);
                    await page.Mouse.ClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterprisePage_mavryck.VerifyFilesIcons(icon))
                    {
                        Test.Log(Status.Info, $"Project Displayed after filtering by Application: {application}");
                    }
                    else
                    {
                        Test.Log(Status.Info, $"No project displayed after filtering by Application: {application}");
                    }
                }
             
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


        [Test, Order(35)]
        public async Task Verify_UserCan_FilterThe_FilesBy_Version()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] versions = {"Baseline", "Update 1", "Update 2"};

            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Files By Version");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b> from side nav menu");
                await EnterprisePage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();

                foreach (var version in versions)
                {
                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Version</b> Filter and Select <b>{version}</b>");
                    await EnterprisePage_mavryck.ClickOnVersionFilter();
                    await EnterprisePage_mavryck.SelectFilter(version);


                    if (await EnterprisePage_mavryck.VerifyVersionFiles(version))
                    {
                        Test.Log(Status.Info, "Program Displayed after filtering by Version: " + version);
                    }
                    else
                    {
                        Test.Log(Status.Info, "No Program displayed after filtering by Version: " + version);
                    }
                }



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

        [Test, Order(36)]
        public async Task Verify_UserCan_FilterThe_FilesBy_Project()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] projects = { "Piling Project", "Andarko Piling Project"};

            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Files By Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b> from side nav menu");
                await EnterprisePage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();

                foreach (var Project in projects)
                {

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Project </b> Filter And Select <b> " + Project + " </b>");
                    await EnterprisePage_mavryck.ClickOnProjectFilter();
                    await EnterprisePage_mavryck.SelectFilter(Project);


                    if (await EnterprisePage_mavryck.VerifyProjectFiles())
                    {
                        Test.Log(Status.Info, "Program Displayed after filtering by Version: " + Project);
                    }
                    else
                    {
                        Test.Log(Status.Info, "No Program displayed after filtering by Version: " + Project);

                    }

                }



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


        [Test, Order(37)]
        public async Task Verify_UserCan_FilterThe_FilesBy_Extension()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            string[] extensions = { ".xlsx", ".pdf" };

            try
            {
                Test = Extent.CreateTest("Verify User Can Successfully Filter The Files By Extensions");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b> from side nav menu");
                await EnterprisePage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterprisePage_mavryck.ClickOnFilterButton();

                foreach (var Extension in extensions)
                {

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Extension </b> Filter And Select <b> " + Extension + " </b>");
                    await EnterprisePage_mavryck.ClickOnExtensionFilter();
                    await EnterprisePage_mavryck.SelectFilter(Extension);


                    if (await EnterprisePage_mavryck.VerifyExtensionFiles(Extension))
                    {
                        Test.Log(Status.Info, "Program Displayed after filtering by Extension: " + Extension);
                    }
                    else
                    {
                        Test.Log(Status.Info, "No Program displayed after filtering by Extension: " + Extension);

                    }
                }



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


        [Test, Order(38)]
        public async Task Verify_Hover_Feature_Of_Enterprise_ProjectDirectory_Projects()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify The Hover Feature Of Enterprise Project Directory -- Projects");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count-1;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Projects ***");
                await EnterpriseProjectPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Filter </b>***");
                await EnterpriseProjectPage_mavryck.HoverFilter();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Filter  Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>List View</b> Of Projects ***");
                await EnterpriseProjectPage_mavryck.HoverListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> List View Hover Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $" *** Hover The  <b>Filter </b>***");
                await EnterpriseProjectPage_mavryck.HoverFilter();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Filter  Tooltip </b> is displaying");
                Assert.True(await TimeManagerPage_mavryck.VerifyHoverTooltip());


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



        [Test, Order(39)]
        public async Task Verify_Hover_Feature_Of_Enterprise_ProjectDirectory_Programs()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify The Hover Feature Of Enterprise Project Directory Programs");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count-1;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterpriseProjectPage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Programs***");
                await EnterpriseProjectPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Table View </b> Of Programs ***");
                await EnterpriseProjectPage_mavryck.HoverTableView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Table View Hover Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());


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


        [Test, Order(40)]
        public async Task Verify_Hover_Feature_Of_Enterprise_ProjectDirectory_Files()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify The Hover Feature Of Enterprise Project Directory Files");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b> from side nav menu");
                await EnterpriseProjectPage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Programs***");
                await EnterpriseProjectPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Filter </b>***");
                await EnterpriseProjectPage_mavryck.HoverFilter();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Filter  Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());

                Test.Log(Status.Info, $" *** Hover The  <b>Table View </b> Of Programs ***");
                await EnterpriseProjectPage_mavryck.HoverTableView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Table View Hover Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());
                await EnterpriseProjectPage_mavryck.ClickOnTableView();

                Test.Log(Status.Info, $" *** Hover The  <b>Filter </b>***");
                await EnterpriseProjectPage_mavryck.HoverFilter();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Filter  Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());


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