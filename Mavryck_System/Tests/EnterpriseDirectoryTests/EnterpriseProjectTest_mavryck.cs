using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_System.Pages;
using Mavryck_System.Utils;
using System;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using PlanNotePlaywrite;


namespace Mavryck_System.Tests.EnterpriseDirectoryTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class EnterpriseProjectTest_mavryck : Base
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
        public async Task VerifyProjectDetails_In_ListView_Tab()

        {
            var Test = Extent.CreateTest("Verify Details of Project In List View Tab");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeatuesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string industry = "construction";
            string location = "Canada";
            string currency = "INR";
            string vivclimaIcon = "Vivclima";
            string neuroDynamiq = "NeuroDynamiq";
     
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Neurodynamiq </b> Button");
                await CommonFeatuesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeatuesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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


                Test.Log(Status.Info, $"Step {++step}: Verify the Application Icons of " + projectName);
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons2(vivclimaIcon) , "Vivclima App Icon is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyAppIcons2(neuroDynamiq), "NeuroDynamiq App Icon is displaying");

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
        public async Task Verify_Apps_Functionality_OfProject()
        {
            var Test = Extent.CreateTest("Verify Application Icons Are Functioning Properly Of Project");  
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string vivclimaIcon = "vivclima";
            string viclimaTitle = "Vivclima";
            string neuroDynamiq = "neuroDynamiq";
            string neuroDynamiqTitle = "NeuroDynamiq";

           


            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click <b> Vivclima Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons(vivclimaIcon);
                await EnterpriseProjectPage_mavryck.ClickOnCloseIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> " +viclimaTitle+ "</b> is displaying");
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(viclimaTitle);

                byte [] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass(viclimaTitle, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await page.GoBackAsync();


                Test.Log(Status.Info, $"Step {++step}: Click <b> NeuroDynamiq Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons(neuroDynamiq);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> " + neuroDynamiqTitle + "</b> is displaying");
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(neuroDynamiqTitle);
                Test.Pass(neuroDynamiqTitle, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());

         
            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        [Test]
        public async Task Verify_Apps_Functionality_OfProject_ListView()
        {
            var Test = Extent.CreateTest("Verify Application Icons Are Functionaing Properly Of Project From List View");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string viclimaTitle = "Vivclima";
            string neuroDynamiqTitle = "NeuroDynamiq";


            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project : " + projectName + "</b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectIsDisplaying(projectName));

                Test.Log(Status.Info, $"Step {++step}: Click <b> Vivclima Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons2(viclimaTitle);
                await EnterpriseProjectPage_mavryck.ClickOnCloseIcon();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> " + viclimaTitle + "</b> is displaying");
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(viclimaTitle);

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass(viclimaTitle, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                await page.GoBackAsync();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View  Again</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click <b> NeuroDynamiq Icon <b> ");
                await EnterpriseProjectPage_mavryck.ClickOnAppIcons2(neuroDynamiqTitle);

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> " + neuroDynamiqTitle + "</b> is displaying");
                await EnterpriseProjectPage_mavryck.VerifyAppDashboardIsDisplaying(neuroDynamiqTitle);
                Test.Pass(neuroDynamiqTitle, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());


            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }

       

        [Test]
        public async Task Verify_Upload_ScheduleFile_Under_Project()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Schedule File Under The Project"); 
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var Version = "1";
           
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Schedule File <b>" + schedulefileName + " </b>");
                await EnterpriseProjectPage_mavryck.UploadScheduleFile();

                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterpriseProjectPage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterpriseProjectPage_mavryck.ClickUpload();
                await Task.Delay(1000);

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

        [Test]
        public async Task Verify_Upload_CostFile_Under_Project()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Cost File Under The Project");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string Version = "1";
          
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnViewFilesButton();

                Test.Log(Status.Info, $"Step {++step}: Upload Cost File <b>" + costFileName + " </b>");
                await EnterpriseProjectPage_mavryck.UploadCostFile();


                Test.Log(Status.Info, $"Step {++step}: Select Version <b>" + Version + " </b>");
                await EnterpriseProjectPage_mavryck.SelectVersionNumber(Version);


                Test.Log(Status.Info, $"Step {++step}: Click On <b>Upload </b> button");
                await EnterpriseProjectPage_mavryck.ClickUpload();
                await Task.Delay(1000);


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

        [Test]
        public async Task Verify_Upload_ContractFile_Under_Project()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Contract File Under The Project");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string Version = "1";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> View Files </b>");
                await EnterpriseProjectPage_mavryck.ClickOnViewFilesButton();
                await Task.Delay(1000);

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


        [Test]
        public async Task Verify_Upload_ScheduleFile_Under_Project_FromListView()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Schedule File Under The Project From List View");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            var Version = "1";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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
                await Task.Delay(1000);

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

        [Test]
        public async Task Verify_Upload_CostFile_Under_Project_FromListView()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Cost File Under The Project From List View"); 
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string Version = "1";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Time Manager </b> Button"));
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button"));
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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
                await Task.Delay(1000);

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

        [Test]
        public async Task Verify_Upload_ContractFile_Under_Project_FromListView()
        {
            var Test = Extent.CreateTest("Verify User Can Upload The Contract File Under The Project From List View");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string Version = "1";
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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
                await Task.Delay(1000);

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

    
    

        //[Test]
        public async Task Verify_The_ApplicationFilters()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Application");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            byte[] screenshotBytes1 = await page.ScreenshotAsync();

            string[] applicationFilter = { "NeuroDynamiq", "Vivclima", "s AI f", "Abacus", "Numetra", "Reporting Manager", "Contracts Manager", "OptimaRes", "RiskSentinel" };
            string[] applicationIcons = { "projectManager", "vivclima", "CV", "estimation", "cost"  , "xyz" , "xyz" , "xyz" , "xyz"};

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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
                    await Task.Delay(10000);

                    if (await EnterpriseProjectPage_mavryck.VerifyApplicationFilterProjects(icon))
                    {
                        Test.Log(Status.Info, $"Project Displayed after filtering by Application: {application}");
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(application+ " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();


                    }
                    else
                    {
                        Test.Log(Status.Info, $"No project displayed after filtering by Application: {application}");
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(application+ " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();

                    }
                }
                screenshotBytes1 = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
            }
            catch (Exception e)
            {
                screenshotBytes1 = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                Assert.True(false);
            }

        }

        //[Test]
        public async Task Verify_The_IndustryFilters()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Industry");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string[] industryFilter = { "Education", "Finance", "Healthcare", "IT", "Manufacturing", "Oil & Gas", "Retail", "Transportation", "Other" };


            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();


                foreach (var industryfilter in industryFilter)
                {
                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Industry </b> Filter And Select <b> " + industryfilter + " </b>");
                    await EnterpriseProjectPage_mavryck.ClickOnIndustryFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(industryfilter);
                    await page.Mouse.DblClickAsync(2000, 400);
                    await Task.Delay(1000);

                    if (await EnterpriseProjectPage_mavryck.VerifyIndustryFilterProjects(industryfilter))
                    {
                        Test.Log(Status.Info, "Project Displayed after filtering by industry: " + industryfilter);
                        byte[] screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(industryfilter + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();
                    }
                    else
                    {
                        Test.Log(Status.Info, "No project displayed after filtering by industry: " + industryfilter);
                        byte[] screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(industryfilter + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();
                    }

                }

                
            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        //[Test]
        public async Task Verify_The_StatusFilters()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Status");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string[] statusFilter = { "Active", "Completed" };
            byte[] screenshotBytes1 = null;
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(statusfilter + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();
                    }
                    else
                    {
                        Test.Log(Status.Info, "No project displayed after filtering by status: " + statusfilter);
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(statusfilter + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();
                    }

                }
                screenshotBytes1 = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        //[Test]
        public async Task Verify_The_ApplicationFilters_ListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Application List View");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string[] applicationFilter = { "NeuroDynamiq", "Vivclima", "s AI f", "Abacus", "Numetra", "Reporting Manager", "Contracts Manager", "OptimaRes", "RiskSentinel" };
            string[] applicationIcons = { "projectManager", "vivclima", "CV", "estimation", "cost", "xyz", "xyz", "xyz", "xyz" };
            byte[] screenshotBytes1 = null;
            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(application + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();
                }
                    else
                    {
                        Test.Log(Status.Info, $"No project displayed after filtering by Application: {application} with Icon: {icon}");
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(application + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();
                    } 
                }

                screenshotBytes1 = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        //[Test]
        public async Task Verify_The_IndustryFilters_ListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Industry List View");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string[] industryFilter = { "Education", "Finance", "Healthcare", "IT", "Manufacturing", "Oil & Gas", "Retail", "Transportation", "Other" };
            byte[] screenshotBytes1= null;
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> List View</b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnListView();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Filter </b> Button");
                await EnterpriseProjectPage_mavryck.ClickOnFilterButton();


                foreach (var industryfilter in industryFilter)
                {
                    Test.Log(Status.Info, $"Step {++step}: Click On <b>Industry </b> Filter And Select <b> " + industryfilter + " </b>");
                    await EnterpriseProjectPage_mavryck.ClickOnIndustryFilter();
                    await EnterpriseProjectPage_mavryck.SelectFilter(industryfilter);
                    await page.Mouse.DblClickAsync(2000, 400);
                    Thread.Sleep(1000);

                    if (await EnterpriseProjectPage_mavryck.VerifyIndustryFilterProjects(industryfilter))
                    {
                        Test.Log(Status.Info, "Project Displayed after filtering by Location: " + industryfilter);
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(industryfilter + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();
                    }
                    else
                    {
                        Test.Log(Status.Info, "No project displayed after filtering by Location: " + industryfilter);
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(industryfilter + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();
                    }

                }

               screenshotBytes1 = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }


        //[Test]
        public async Task Verify_The_StatusFilters_ListView()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Filter The Projects Of Specific Status List View"); 
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string[] statusFilter = { "Active", "Completed" };
            byte[] screenshotBytes1 = await page.ScreenshotAsync();
            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(statusfilter + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();

                    }
                    else
                    {
                        Test.Log(Status.Info, "No project displayed after filtering by Status: " + statusfilter);
                        screenshotBytes1 = await page.ScreenshotAsync();
                        Test.Pass(statusfilter + " Filter", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
                        await EnterpriseProjectPage_mavryck.ClickOnFilterCancel();

                    }

                }
                screenshotBytes1 = await page.ScreenshotAsync();
                Test.Pass("Test passed Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes1)).Build());
            }
            catch (Exception e)
            {
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }
        



        [Test]
        public async Task Verify_Program_Details()
        {
            var Test = Extent.CreateTest("Verify All The Program Details and Requirments");     
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string programName = "Reno and Upgrade";

            try
            {
                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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


        [Test]
        public async Task Verify_Program_Details_FromListView()
        {
            var Test = Extent.CreateTest("Verify All The Program Details and Requirments From List View");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);
            string programName = "Reno and Upgrade";

            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

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

        [Test]
        public async Task Verify_Hover_Feature_Of_Enterprise_ProjectDirectory_Projects()
        {
            var Test = Extent.CreateTest("Verify The Hover Feature Of Enterprise Project Directory -- Projects");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);

            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count - 1;
                await Task.Delay(1000);

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();
                await Task.Delay(1000);

                Test.Log(Status.Info, $" *** Hover The  <b>Grid View</b> Of Projects ***");
                await EnterpriseProjectPage_mavryck.HoverGridView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Grid View Hover Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());
                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Pass("Grid View Tooltip", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());



                Test.Log(Status.Info, $" *** Hover The  <b>List View</b> Of Projects ***");
                await EnterpriseProjectPage_mavryck.HoverListView();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> List View Hover Tooltip </b> is displaying");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyHoverTooltip());

         

                
                Test.Pass("List View Tooltip", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            catch (Exception e)
            {

                byte[] screenshotBytes = await page.ScreenshotAsync();
                Test.Fail($"Test failed Screenshot: {e.Message}", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
                Assert.True(false);
            }
        }



        [Test]
        public async Task Verify_SideNavBar_Of_EnterpriseProjectDirectory()
        {
            var Test = Extent.CreateTest("Verify The Side Nav Bar Of Enterprise Project Directory");
            int step = 0;
            var testSteps = new ArrayList();
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var EnterpriseProjectPage_mavryck = new EnterpriseProjectPage_mavryck(page, Test);
            var CommonFeaturesPage_mavryck = new CommonFeaturesPage_mavryck(page, Test);

            try
            {

                testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Launching the app"));
                await loadURL(page, Constants.BaseUrl);

                testSteps.AddRange(await loginPage_mavryck.Login(step));
                step = testSteps.Count;

                Test.Log(Status.Info, $"Step {++step}: Click On <b> NeuroDynamiq </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnTimeManager();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Open Enterprise Directory </b> Button");
                await CommonFeaturesPage_mavryck.ClickOnOpenEnterpriseDirectory();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Side Nav Bar Options</b>");
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectsAndProgramIsDispalying());
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyGlobalAdminIsDispalying());
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyProjectAdminIsDispalying());
                Assert.True(await EnterpriseProjectPage_mavryck.VerifyOrganizationAdminIsDispalying());


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