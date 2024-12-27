using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using System;
using System.Threading.Tasks;
using PlanNotePlaywrite;

namespace Mavryck_TimeManager.Tests
{
    public class LoginTest_mavryck : Base
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
        public async Task VerifyThe_LoginDashboardRequirements()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify The Login Dashboard Requirements");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                Test.Log(Status.Info, $"<b> Verify All the Login Screen Requirements <b>");


                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Email</b> and <b> Password </b>  are displaying");
                await loginPage_mavryck.VerifyEmailIsVisible();
                await loginPage_mavryck.VerifyPasswordIsVisible();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Remember Me </b> checkbox is displaying");
                await loginPage_mavryck.VerifyRememberMeCheckboxIsVisible();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Forgot Password </b> link is displaying");
                await loginPage_mavryck.VerifyForgotPasswordIsVisible();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Login In <b> button is displaying");
                Assert.True(await loginPage_mavryck.VerifyLoginButtonIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Login In With Microsoft <b> button is displaying");
                Assert.True(await loginPage_mavryck.VerifySignInWithMicrosoftIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Sign Up</b> link is displaying");
                Assert.True(await loginPage_mavryck.VerifySignUpLinkIsVisible());

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
        public async Task VerifyThat_UserCanLoginWithValidCredentials()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify Login With Valid Credentials");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                Test.Log(Status.Info, $"Step {++step}: Enter Credentials: Email :" + email + " Password: " + password);
                await loginPage_mavryck.EnterLoginCredentials(email, password);
              

                Test.Log(Status.Info, $"Step {++step}: Click On Remember Me Checkbox");
                await loginPage_mavryck.ClickOnRememberMeCheckbox();

                Test.Log(Status.Info, $"Step {++step}: Click On Login Button");
                await loginPage_mavryck.ClickOnSubmitButton();


                Test.Log(Status.Info, $"Step {++step}: Verify that the <b> Mavryck Dashboard</b>  is displaying");
                Assert.True(await loginPage_mavryck.VerifyDashboardPageIsVisible());

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
        public async Task UserUnableLoginWith_InValidCredentials()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var Invalid_email = "test@com.pk";
            var Invalid_password = "123456";
            

            try
            {
                Test = Extent.CreateTest("Verify User Unable To Login With InValid Credentials");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                Test.Log(Status.Info, $"Step {++step}: Enter Credentials: InValid Email :" + email + " InValid Password: " +password);
                await loginPage_mavryck.EnterLoginCredentials(Invalid_email, Invalid_password);


                Test.Log(Status.Info, $"Step {++step}: Click On Remember Me Checkbox");
                await loginPage_mavryck.ClickOnRememberMeCheckbox();

                Test.Log(Status.Info, $"Step {++step}: Click On Login Button");
                await loginPage_mavryck.ClickOnSubmitButton();


                Test.Log(Status.Info, $"Step {++step}: Verify that  <b> Alert Message </b>  is displaying");
                Assert.True(await loginPage_mavryck.VerifyAlertMessageIsVisible());

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
        public async Task UserCanUpdateThe_Password()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify User Can Update The Password");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);


                Test.Log(Status.Info, $"Step {++step}: Click On Forgot Password Button");
                await loginPage_mavryck.ClickOnForgotPassword();

                Test.Log(Status.Info, $"Step {++step}: Enter Email " + email);
                await loginPage_mavryck.EnterForgotPasswordEmail();

                Test.Log(Status.Info, $"Step {++step}: Click On Update Password Button");
                await loginPage_mavryck.ClickOnUpdateButton();

                //Test.Log(Status.Info, $"Step {++step}: Verify that  <b> Alert Message </b>  is displaying");
                //Assert.True(await loginPage_mavryck.VerifyAlertMessageIsVisible());

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
        public async Task UserCan_SignOut_FromMavryck()
        {
            var page = await context.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify User Can Sign Out From Mavryck");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                Test.Log(Status.Info, $"Step {++step}: Enter Credentials: Email :" + email + " Password: " + password);
                await loginPage_mavryck.EnterLoginCredentials(email, password);


                Test.Log(Status.Info, $"Step {++step}: Click On Remember Me Checkbox");
                await loginPage_mavryck.ClickOnRememberMeCheckbox();

                Test.Log(Status.Info, $"Step {++step}: Click On Login Button");
                await loginPage_mavryck.ClickOnSubmitButton();


                Test.Log(Status.Info, $"Step {++step}: Verify that the <b> Mavryck Dashboard</b>  is displaying");
                Assert.True(await loginPage_mavryck.VerifyDashboardPageIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Click On Sign Out Button");
                await loginPage_mavryck.ClickOnSignOutButton();


                Test.Log(Status.Info, $"Step {++step}: Verify that the <b> Mavryck Login Screen</b>  is displaying");
                Assert.True(await loginPage_mavryck.VerifyLoginDashboardPageIsVisible());



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