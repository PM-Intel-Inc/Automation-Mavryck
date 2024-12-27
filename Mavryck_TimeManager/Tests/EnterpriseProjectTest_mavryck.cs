using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using System;
using System.Threading.Tasks;
using PlanNotePlaywrite;
using System.Collections;

namespace Mavryck_TimeManager.Tests
{
    public class EnterpriseProjectTest_mavryck : Base
    {
        private IPlaywright playwright;
        private IBrowser browser;
        private IBrowserContext context;
        private int step;

        [SetUp]
        public async Task Setup()
        {
            playwright = await PlaywrightConfig.ConfigurePlaywrightAndLaunchBrowser();
            browser = await PlaywrightConfig.LaunchChromiumBrowser(playwright, chromiumExecutablePath, false);
            step = 0;
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

        [Test, Order(1)]
        public async Task VerifyThe_NewProjectRequirements()
        {
            var page = await context.NewPageAsync();
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page);
            ArrayList testSteps = new ArrayList();
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


        [Test, Order(2)]
        public async Task VerifyUserCan_CreateProject()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            ArrayList testSteps = new ArrayList();
            string projectName = "Automation Project";
            string status = "Active";
            string industry = "IT";
            string location = "Canada";
            string currency = "USD";

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

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying"));
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(projectName));


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
        public async Task Verify_Edit_TheExistingProject()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            ArrayList testSteps = new ArrayList();
            string EditedProjectName = "Mavryck Automation Project";
            try
            {
                Test = Extent.CreateTest("Verify User Can Edit The Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count ;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Three Dots </b>"));
                await EnterprisePage_mavryck.ClickOnThreedot();


                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Enter Project Name: <b>"+ EditedProjectName + " </b>"));
                await EnterprisePage_mavryck.EnterEditProjectName(EditedProjectName);

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click <b> Save Button <b> "));
                await EnterprisePage_mavryck.ClickOnEditSaveButton();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify Edited Project is displaying "));
                Assert.True(await EnterprisePage_mavryck.VerifyProjectIsDisplaying(EditedProjectName));

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

        [Test, Order(4)]
        public async Task Verify_Upload_ScheduleFile_Under_Project()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            ArrayList testSteps = new ArrayList();
            try
            {
                Test = Extent.CreateTest("Verify User Can Upload The Schedule File Under The Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>"));
                await EnterprisePage_mavryck.ClickOnViewFilesButton();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Upload Schedule File <b>" + costFile + " </b>"));
                await EnterprisePage_mavryck.UploadCostFile();

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
        public async Task Verify_Upload_CostFile_Under_Project()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            ArrayList testSteps = new ArrayList();
            try
            {
                Test = Extent.CreateTest("Verify User Can Upload The Cost File Under The Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>"));
                await EnterprisePage_mavryck.ClickOnViewFilesButton();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Upload Cost File <b>" + costFile + " </b>"));
                await EnterprisePage_mavryck.UploadCostFile();

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
        public async Task Verify_Upload_ContractFile_Under_Project()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page);
            var EnterprisePage_mavryck = new EnterpriseProjectPage_mavryck(page);
            ArrayList testSteps = new ArrayList();
            try
            {
                Test = Extent.CreateTest("Verify User Can Upload The Contract File Under The Project");

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>"));
                await EnterprisePage_mavryck.ClickOnViewFilesButton();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Upload Contract File <b>" + contractFile + " </b>"));
                await EnterprisePage_mavryck.UploadContractFile();

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