using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using System;
using System.Threading.Tasks;
//using PlanNotePlaywrite;
using System.Collections;
using AventStack.ExtentReports.Reporter.Filter;
using System.Threading;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Collections.Generic;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.VisualStudio.TestPlatform.TestHost;


namespace Mavryck_TimeManager.Tests.EnterpriseDirectoryTests
{
    [Order(1)]

    public class EnterpriseProjectTest_mavryck : Base
    {


        //[Test, Order(1)]
        //[Parallelizable]
        public async Task VerifyThe_NewProjectRequirements()
        {
            var Test = Extent.CreateTest("Verify Required Fields For Project Creation.");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

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
        //[Parallelizable]
        public async Task VerifyUserCan_CreateProject()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Create The Project");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
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

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                testSteps.AddRange(await EnterpriseProjectPage_mavryck.CreateProject(step, projectName, industry, location, currency, status));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $" ** Verify the <b>Project : " + projectName + "</b> Details ***");

                Test.Log(Status.Info, $"Step {++step}: Verify Industry ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyListViewRequirementsIsVisible(industry));

                Test.Log(Status.Info, $"Step {++step}: Verify Location ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyListViewRequirementsIsVisible(location));

                Test.Log(Status.Info, $"Step {++step}: Verify Currency ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyListViewRequirementsIsVisible(currency));

                Test.Log(Status.Info, $"Step {++step}: Verify Edit Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyThreeDot());

                Test.Log(Status.Info, $" ** Verify All the  <b>Project : " + projectName + "</b> Application Icons ** ");

                Test.Log(Status.Info, $"Step {++step}: Verify Vivclima Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons(vivclimaIcon));

                Test.Log(Status.Info, $"Step {++step}: Verify Time Manager Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Verify Cost Brain Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons(cost));


                Test.Log(Status.Info, $"Step {++step}: Verify SAIF Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons(saif));

                Test.Log(Status.Info, $"Step {++step}: Verify Estimator Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons(estimation));




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
        [Parallelizable]
        public async Task VerifyProjectDetails_In_ListView_Tab()

        {
            var Test = Extent.CreateTest("Verify Details of Created Project In List View Tab");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
         
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string projectName = "Mavryck Automation Project";
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
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $" ** Verify the  <b>Project : " + projectName + "</b> details ** ");

                Test.Log(Status.Info, $"Step {++step}: Verify Industry ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyListViewRequirementsIsVisible(industry));

                Test.Log(Status.Info, $"Step {++step}: Verify Location ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyListViewRequirementsIsVisible(location));

                Test.Log(Status.Info, $"Step {++step}: Verify Currency ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyListViewRequirementsIsVisible(currency));

                Test.Log(Status.Info, $"Step {++step}: Verify Edit Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyThreeDot());

                Test.Log(Status.Info, $" ** Verify All the  <b>Project : " + projectName + "</b> Application Icons ** ");

                Test.Log(Status.Info, $"Step {++step}: Verify Vivclima Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons(vivclimaIcon));

                Test.Log(Status.Info, $"Step {++step}: Verify Time Manager Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons(timeManager));

                Test.Log(Status.Info, $"Step {++step}: Verify Cost Brain Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons2(cost));


                Test.Log(Status.Info, $"Step {++step}: Verify SAIF Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons2(saif));

                Test.Log(Status.Info, $"Step {++step}: Verify Estimator Icon ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons2(estimation));

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
        //[Parallelizable]
        public async Task VerifyUserCannot_CreateProject_WithEmptyFields()
        {
            var Test = Extent.CreateTest("Verify User Unable To Create The Project With Empty Fields");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Create New Project </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnCreateProjectButton();

                Test.Log(Status.Info, $"Step {++step}: Click <b> Save Button <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnSaveButton();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Error Popup </b> is displaying"));
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyErrorPopup());


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
        [Parallelizable]
        public async Task Verify_Apps_Functionality_OfProject()
        {
            var Test = Extent.CreateTest("Verify Application Icons Are Functionaing Properly Of Project");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
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
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click <b> Vivclima Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons(vivclimaIcon);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(viclimaTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> Time Manager Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons(timeManager);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> Cost Brain Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons2(cost);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> SAIF Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons2(saif);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(saifTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click <b> Estimate Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons2(estimation);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(estimationTitle);
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
        [Parallelizable]
        public async Task Verify_Apps_Functionality_OfProject_ListView()
        {
            var Test = Extent.CreateTest("Verify Application Icons Are Functionaing Properly Of Project From List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
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

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click <b> Vivclima Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons(vivclimaIcon);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(viclimaTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> Time Manager Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons(timeManager);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(timeManagerTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> Cost Brain Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons2(cost);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(costTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Click <b> SAIF Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons2(saif);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(saifTitle);
                await page.GoBackAsync();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click <b> Estimate Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons2(estimation);
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(estimationTitle);
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
        [Parallelizable]
        public async Task Verify_Edit_TheExistingProject()
        {
            var Test = Extent.CreateTest("Verify User Can Edit The Project");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Three Dots </b>");
                await EnterpriseProjectPage_mavryck.ClickOnThreedot();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());

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
        [Parallelizable]
        public async Task Verify_Upload_ScheduleFile_Under_Project()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Schedule File Under The Project");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var Version = "1";
           
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Schedule File <b>" + schedulefileName + " </b>");
                await EnterpriseProjectPage_mavryck.UploadScheduleFile();

                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterpriseProjectPage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterpriseProjectPage_mavryck.ClickUpload();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());



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
        [Parallelizable]
        public async Task Verify_Upload_CostFile_Under_Project()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Cost File Under The Project");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string Version = "1";
          
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Cost File <b>" + costFileName + " </b>");
                await EnterpriseProjectPage_mavryck.UploadCostFile();


                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterpriseProjectPage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterpriseProjectPage_mavryck.ClickUpload();
                Thread.Sleep(10000);


                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());


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
        [Parallelizable]
        public async Task Verify_Upload_ContractFile_Under_Project()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Contract File Under The Project");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string Version = "1";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnViewFilesButton();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Upload Contract File <b>" + contractFile + " </b>");
                await EnterpriseProjectPage_mavryck.UploadContractFile();

                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterpriseProjectPage_mavryck.SelectVersionNumber(Version);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterpriseProjectPage_mavryck.ClickUpload();

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());

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
        [Parallelizable]
        public async Task Verify_Upload_ScheduleFile_Under_Project_FromListView()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Schedule File Under The Project From List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var Version = "1";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Schedule File <b>" + schedulefileName + " </b>");
                await EnterpriseProjectPage_mavryck.UploadScheduleFile();

                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterpriseProjectPage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterpriseProjectPage_mavryck.ClickUpload();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());




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
        [Parallelizable]
        public async Task Verify_Upload_CostFile_Under_Project_FromListView()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Cost File Under The Project From List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string Version = "1";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await DashboardPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Cost File <b>" + costFileName + " </b>");
                await EnterpriseProjectPage_mavryck.UploadCostFile();


                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterpriseProjectPage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterpriseProjectPage_mavryck.ClickUpload();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());

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
        [Parallelizable]
        public async Task Verify_Upload_ContractFile_Under_Project_FromListView()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Contract File Under The Project From List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string Version = "1";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Contract File <b>" + contractFile + " </b>");
                await EnterpriseProjectPage_mavryck.UploadContractFile();


                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterpriseProjectPage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterpriseProjectPage_mavryck.ClickUpload();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());

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
        [Parallelizable]
        public async Task Verify_CancelDeleting_The_Existing_Project()
        {
            var Test = Extent.CreateTest("Verify User Can  Cancel Deleting The Existing Project");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete </b> Icon");
                await EnterpriseProjectPage_mavryck.ClickOnDeleteButton();

                //Test.Log(Status.Info, $"Step {++step}: Click On <b>No </b> button");
                //await EnterpriseProjectPage_mavryck.ClickOnNoButton();

                //Test.Log(Status.Info, $"Step {++step}: Verify <b>" + projectName + " </b> is displaying");
                //Assert.True(await EnterpriseProjectPage_mavryck.VerifyListViewProjectNameIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());

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
        [Parallelizable]
        public async Task Verify_CancelDeleting_The_Existing_Project_ListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Cancel Deleting The Existing Project From List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete </b> Icon");
                await EnterpriseProjectPage_mavryck.ClickOnDeleteButton();


                //Test.Log(Status.Info, $"Step {++step}: Click On <b>No</b> button");
                //await EnterpriseProjectPage_mavryck.ClickOnNoButton();

                //Test.Log(Status.Info, $"Step {++step}: Verify <b>" + projectName + " </b> is displaying");
                //Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectNameIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());

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
        [Parallelizable]
        public async Task Verify_Deleting_The_Existing_Project()
        {
            var Test = Extent.CreateTest("Verify User Can Delete The Existing Project");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete </b> Icon");
                await EnterpriseProjectPage_mavryck.ClickOnDeleteButton();

                //Test.Log(Status.Info, $"Step {++step}: Click On <b>Yes</b> button");
                //await EnterpriseProjectPage_mavryck.ClickOnYesButton();


                Test.Log(Status.Info, $"Step {++step}: Verify <b>Please Contact Your Administrator </b> message is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());



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
        [Parallelizable]
        public async Task Verify_Deleting_The_Existing_Project_From_ListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Delete The Existing Project From List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete </b> Icon");
                await EnterpriseProjectPage_mavryck.ClickOnDeleteButton();


                //Test.Log(Status.Info, $"Step {++step}: Click On <b>Yes</b> button");
                //await EnterpriseProjectPage_mavryck.ClickOnYesButton();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());

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
        [Parallelizable]
        public async Task Verify_The_ApplicationFilters()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Application");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string[] applicationFilter = { "Time Manager", "Vivclima", "s AI f", "AIstimate Pro" };
            string[] applicationIcons = { "projectManager", "vivclima", "CV", "estimation" };

            //string[] applicationFilter = { "Time Manager", "Vivclima", "s AI f", "AIstimate Pro" , "CostBrain" ,"Reporting Manager" , "Contracts Manager" , "Resource Optimizer" , "Risk IQ" };
            //string[] applicationIcons = { "projectManager", "vivclima", "CV", "estimation", "cost"  , "xyz" , "xyz" , "xyz" , "xyz"};

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();


                for (int i = 0; i < applicationFilter.Length; i++)
                {
                    string application = applicationFilter[i];
                    string icon = applicationIcons[i];

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Application </b> Filter And Select <b>{application}</b>");
                    await EnterpriseProjectPage_mavryck.ClickOnApplicationFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(application);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterpriseProjectPage_mavryck.VerifyApplicationFilterProjects(icon))
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
        [Parallelizable]
        public async Task Verify_The_IndustryFilters()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Industry");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string[] industryFilter = { "Education", "Finance", "Healthcare", "IT", "Manufacturing", "Oil & Gas", "Retail", "Transportation", "Other" };
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();


                foreach (var industryfilter in industryFilter)
                {
                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Industry </b> Filter And Select <b> " + industryfilter + " </b>");
                    await EnterpriseProjectPage_mavryck.ClickOnIndustryFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(industryfilter);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterpriseProjectPage_mavryck.VerifyIndustryFilterProjects(industryfilter))
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
        [Parallelizable]
        public async Task Verify_The_StatusFilters()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Status");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string[] statusFilter = { "Active", "Completed" };
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();


                foreach (var statusfilter in statusFilter)
                {

                    Test.Log(Status.Info, $"Step {++step}: Click On <b> Status </b> Filter And Select <b> " + statusfilter + " </b>");
                    await EnterpriseProjectPage_mavryck.ClickOnStatusFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(statusfilter);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterpriseProjectPage_mavryck.VerifyStatusFilterProjects(statusfilter))
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
        [Parallelizable]
        public async Task Verify_The_ApplicationFilters_ListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Application List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string[] applicationFilter = { "Time Manager", "Vivclima", "s AI f", "AIstimate Pro", "CostBrain", "Reporting Manager", "Contracts Manager", "Resource Optimizer", "Risk IQ" };
            string[] applicationIcons = { "projectManager", "vivclima", "CV", "estimation", "cost", "xyz", "xyz", "xyz", "xyz" };

            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();


                for (int i = 0; i < applicationFilter.Length; i++)
                {
                    string application = applicationFilter[i];
                    string icon = applicationIcons[i];

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Application </b> Filter And Select <b>{application}</b>");
                    await EnterpriseProjectPage_mavryck.ClickOnApplicationFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(application);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterpriseProjectPage_mavryck.VerifyApplicationFilterProjects(icon))
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
        [Parallelizable]
        public async Task Verify_The_IndustryFilters_ListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Industry List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string[] industryFilter = { "Education", "Finance", "Healthcare", "IT", "Manufacturing", "Oil & Gas", "Retail", "Transportation", "Other" };
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();


                foreach (var industryfilter in industryFilter)
                {
                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Industry </b> Filter And Select <b> " + industryfilter + " </b>");
                    await EnterpriseProjectPage_mavryck.ClickOnIndustryFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(industryfilter);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterpriseProjectPage_mavryck.VerifyIndustryFilterProjects(industryfilter))
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
        [Parallelizable]
        public async Task Verify_The_StatusFilters_ListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Status List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string[] statusFilter = { "Active", "Completed" };
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();


                foreach (var statusfilter in statusFilter)
                {

                    Test.Log(Status.Info, $"Step {++step}: Click On <b> Status </b> Filter And Select <b> " + statusfilter + " </b>");
                    await EnterpriseProjectPage_mavryck.ClickOnStatusFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(statusfilter);
                    await page.Mouse.DblClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterpriseProjectPage_mavryck.VerifyStatusFilterProjects(statusfilter))
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
        [Parallelizable]
        public async Task Verify_UserCan_FilterThe_Project_UnderListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Under List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            var applicationFilter = "Time Manager";
            var locationFilter = "Canada";
            var industryFilter = "Education";
            var statusFilter = "Completed";
            var currencyFilter = "CAD";
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Application </b> Filter And Select <b>" + applicationFilter + " </b>");
                await EnterpriseProjectPage_mavryck.ClickOnApplicationFilter();
                await EnterpriseProjectPage_mavryck.SelectFilter(applicationFilter);
                await page.Mouse.DblClickAsync(300, 400);

                //Test.Log(Status.Info, $"Step {++step}: Verify <b> Time Manager </b>  Projects are displaying");
                //Assert.True(await EnterpriseProjectPage_mavryck.VerifyListViewProjectNameIsVisible());


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Location </b> Filter And Select <b>" + locationFilter + "</b>");
                await EnterpriseProjectPage_mavryck.ClickOnLocationFilter();
                await EnterpriseProjectPage_mavryck.SelectFilter(locationFilter);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Industry </b> Filter And Select <b> " + industryFilter + " </b>");
                await EnterpriseProjectPage_mavryck.ClickOnIndustryFilter();
                await EnterpriseProjectPage_mavryck.SelectFilter(industryFilter);

                Test.Log(Status.Info, $"Step {++step}: Click On <b>Currency </b> Filter And Select <b> " + currencyFilter + " </b>");
                await EnterpriseProjectPage_mavryck.ClickOnCurrencyFilter();
                await EnterpriseProjectPage_mavryck.SelectFilter(currencyFilter);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Status </b> Filter And Select <b> " + statusFilter + " </b>");
                await EnterpriseProjectPage_mavryck.ClickOnStatusFilter();
                await EnterpriseProjectPage_mavryck.SelectFilter(statusFilter);


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
        //[Parallelizable]
        public async Task VerifyUserCan_CreateProgram()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Create The Program");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string programName = "Automation Program";
            string project = "Andarko Piling Project";
            string status = "Active";

            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterpriseProjectPage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Create Programs </b> button");
                await EnterpriseProjectPage_mavryck.ClickOnCreateAProgram();


                Test.Log(Status.Info, $"Step {++step}: Enter Program Name: <b>" + programName + " </b>");
                await EnterpriseProjectPage_mavryck.EnterProjectName(programName);

                Test.Log(Status.Info, $"Step {++step}: Enter Program Status: <b>" + status + " </b>");
                await EnterpriseProjectPage_mavryck.SelectProgramStatus(status);

                Test.Log(Status.Info, $"Step {++step}: Enter Program Project Status: <b>" + status + " </b>");
                await EnterpriseProjectPage_mavryck.SelectProgramProjectStatus(project);


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Create Program</b>");
                await EnterpriseProjectPage_mavryck.ClickOnCreateProgram();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Program : " + programName + "</b> is created successfully");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProgramIsDisplaying(programName));

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
        [Parallelizable]
        public async Task Verify_Program_Details()
        {
            var Test = Extent.CreateTest("Verify All The Program Details and Requirments");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string programName = "Reno and Upgrade";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterpriseProjectPage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"*** Verify the <b>Program Details </b> *** ");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProgramIsDisplaying(programName));
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyViewProjectButtonIsDisplaying());
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyDeleteButtonIsDisplaying());
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyThreeDot());

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
        [Parallelizable]
        public async Task Verify_Program_Details_FromListView()
        {
            var Test = Extent.CreateTest("Verify All The Program Details and Requirments From List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string programName = "Reno and Upgrade";

            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterpriseProjectPage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"*** Verify the <b>Program Details </b> button");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProgramIsDisplaying(programName));
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyViewProjectButtonIsDisplaying());
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyDeleteButtonIsDisplaying());
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyThreeDot());

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
        [Parallelizable]
        public async Task VerifyUserCan_EditProgram()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Edit The Program");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterpriseProjectPage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Three Dots </b> button");
                await EnterpriseProjectPage_mavryck.ClickOnThreedot();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());

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
        [Parallelizable]
        public async Task VerifyUserCan_EditProgram_ListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Edit The Program From List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterpriseProjectPage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Three Dots </b> button");
                await EnterpriseProjectPage_mavryck.ClickOnThreedot();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());


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
        [Parallelizable]
        public async Task VerifyUserCan_DeleteProgram()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Delete The Program");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterpriseProjectPage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete  </b> Icon");
                await EnterpriseProjectPage_mavryck.ClickOnDeleteButton();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());


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

        [Test, Order(32)]
        [Parallelizable]
        public async Task VerifyUserCan_DeleteProgram_FromListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Delete The Program From List View");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Programs </b>");
                await EnterpriseProjectPage_mavryck.ClickOnProgramsNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Delete  </b> Icon");
                await EnterpriseProjectPage_mavryck.ClickOnDeleteButton();


                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Administrator Permission Required </b> popup is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.PleaseContactAdmin());


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
        [Parallelizable]
        public async Task Verify_Files_Details()
        {
            var Test = Extent.CreateTest("Verify All The Files Details");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;


                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"*** Verify the <b>Files Details </b> ***");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyDateUploaded());
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyLastUpdated());
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyVersion());

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
        [Parallelizable]
        public async Task Verify_UserCan_FilterThe_FilesBy_Application()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Files By Application");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);

            string[] applicationFilter = { "Time Manager", "Vivclima" };
            string[] applicationIcons = { "projectManager", "vivclima" };
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b> from side nav menu");
                await EnterpriseProjectPage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();

                for (int i = 0; i < applicationFilter.Length; i++)
                {
                    string application = applicationFilter[i];
                    string icon = applicationIcons[i];

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Application </b> Filter And Select <b>{application}</b>");
                    await EnterpriseProjectPage_mavryck.ClickOnApplicationFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(application);
                    await page.Mouse.ClickAsync(1000, 400);
                    Thread.Sleep(1000);

                    if (await EnterpriseProjectPage_mavryck.VerifyFilesIcons(icon))
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
        [Parallelizable]
        public async Task Verify_UserCan_FilterThe_FilesBy_Version()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Files By Version");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);

            string[] versions = { "Baseline", "Update 1", "Update 2" };

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b> from side nav menu");
                await EnterpriseProjectPage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();

                foreach (var version in versions)
                {
                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Version</b> Filter and Select <b>{version}</b>");
                    await EnterpriseProjectPage_mavryck.ClickOnVersionFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(version);


                    if (await EnterpriseProjectPage_mavryck.VerifyVersionFiles(version))
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
        [Parallelizable]
        public async Task Verify_UserCan_FilterThe_FilesBy_Project()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Files By Project");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string[] projects = { "Piling Project", "Andarko Piling Project" };

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b> from side nav menu");
                await EnterpriseProjectPage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();

                foreach (var Project in projects)
                {

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Project </b> Filter And Select <b> " + Project + " </b>");
                    await EnterpriseProjectPage_mavryck.ClickOnProjectFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(Project);


                    if (await EnterpriseProjectPage_mavryck.VerifyProjectFiles())
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
        [Parallelizable]
        public async Task Verify_UserCan_FilterThe_FilesBy_Extension()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Files By Extensions");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            string[] extensions = { ".xlsx", ".pdf" };

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button");
                await DashboardPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await DashboardPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Files </b> from side nav menu");
                await EnterpriseProjectPage_mavryck.ClickOnFilesNavMenu();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();

                foreach (var Extension in extensions)
                {

                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Extension </b> Filter And Select <b> " + Extension + " </b>");
                    await EnterpriseProjectPage_mavryck.ClickOnExtensionFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(Extension);


                    if (await EnterpriseProjectPage_mavryck.VerifyExtensionFiles(Extension))
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
            var Test = Extent.CreateTest("Verify The Hover Feature Of Enterprise Project Directory -- Projects");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);

            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count - 1;
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
        [Parallelizable]
        public async Task Verify_Hover_Feature_Of_Enterprise_ProjectDirectory_Programs()
        {
            var Test = Extent.CreateTest("Verify The Hover Feature Of Enterprise Project Directory Programs");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);
            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count - 1;
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
        [Parallelizable]
        public async Task Verify_Hover_Feature_Of_Enterprise_ProjectDirectory_Files()
        {
            var Test = Extent.CreateTest("Verify The Hover Feature Of Enterprise Project Directory Files");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            ArrayList testSteps = new();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var DashboardPage_mavryck = new DashboardPage_mavryck(page, Test);
            var TimeManagerPage_mavryck = new TimeManagerPage_mavryck(page, Test);

            try
            {
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