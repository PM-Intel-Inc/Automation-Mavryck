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
    public class SignUpTest_mavryck : Base
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
        public async Task VerifyThe_SignUpDashboardRequirements()
        {
            var page = await context.NewPageAsync();
            var SignUpPage_mavryck = new SignUpPage_mavryck(page);
            var loginPage_mavryck = new LoginPage_mavryck(page);

            try
            {
                Test = Extent.CreateTest("Verify The Login Dashboard Requirements");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                Test.Log(Status.Info, $"Step {++step}: Click On Sign Up Button");
                await loginPage_mavryck.ClickOnSignUpButton();

                Test.Log(Status.Info, $"<b> Verify All the Login Screen Requirements <b>");

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Email</b> is displaying");
                await SignUpPage_mavryck.VerifyEmailIsVisible();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Username</b> is displaying");
                await SignUpPage_mavryck.VerifyUsernameIsVisible();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Company </b>  is displaying");
                await SignUpPage_mavryck.VerifyCompanyIsVisible();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Password </b>  is displaying");
                await SignUpPage_mavryck.VerifyPasswordIsVisible();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Terms and Conditions </b> checkbox is displaying");
                await SignUpPage_mavryck.VerifyAgreeToTermsIsVisible();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b>Privacy Policy </b> is displaying");
                await SignUpPage_mavryck.VerifyPrivacyPolicyIsVisible();

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Sign Up <b> button is displaying");
                Assert.True(await SignUpPage_mavryck.VerifySignUpButtonIsVisible());

                Test.Log(Status.Info, $"Step {++step}: Verify the <b> Login In <b> link is displaying");
                Assert.True(await SignUpPage_mavryck.VerifyLoginLinkIsVisible());


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
        public async Task VerifyUserCan_SignUpToMavryck()
        {
            var page = await context.NewPageAsync();
            var SignUpPage_mavryck = new SignUpPage_mavryck(page);
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var company = "mavryck";
            var username = "test";
            try
            {
                Test = Extent.CreateTest("Verify The Login Dashboard Requirements");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                Test.Log(Status.Info, $"Step {++step}: Click On Sign Up Link");
                await loginPage_mavryck.ClickOnSignUpButton();

                Test.Log(Status.Info, $"Step {++step}: Clear the Sign Up Form");
                await SignUpPage_mavryck.ClearContent();

                Test.Log(Status.Info, $"Step {++step}: Enter  <b>Email</b> ");
                await SignUpPage_mavryck.EnterEmail(email);

                Test.Log(Status.Info, $"Step {++step}: Enter <b>Username</b> ");
                await SignUpPage_mavryck.EnterUsername(username);

                Test.Log(Status.Info, $"Step {++step}: Enter <b> Company </b> ");
                await SignUpPage_mavryck.EnterCompany(company);

                Test.Log(Status.Info, $"Step {++step}: Enter <b> Password </b>  is displaying");
                await SignUpPage_mavryck.EnterPassword();

                Test.Log(Status.Info, $"Step {++step}: Agree to <b>Terms and Conditions </b> and <b> Privacy Policy  </b>");
                await SignUpPage_mavryck.ClickOnTermsAndPolicy();

                Test.Log(Status.Info, $"Step {++step}: Click On <b> Sign Up <b> button");
                await SignUpPage_mavryck.ClickOnSignUpButton();


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
        public async Task Verify_SignUpValidationMessage()
        {
            var page = await context.NewPageAsync();
            var SignUpPage_mavryck = new SignUpPage_mavryck(page);
            var loginPage_mavryck = new LoginPage_mavryck(page);
            var company = "mavryck";
            var username = "test";
            try
            {
                Test = Extent.CreateTest("Verify Sign Up Validations");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                Test.Log(Status.Info, $"Step {++step}: Click On Sign Up Link");
                await loginPage_mavryck.ClickOnSignUpButton();

                Test.Log(Status.Info, $"Step {++step}: Clear Sign Up Form");
                await SignUpPage_mavryck.ClearContent();

                Test.Log(Status.Info, $"Step {++step}: <b> Verify Empty Email Validation Message </b>");
                await SignUpPage_mavryck.ClickOnSignUpButton();
                await SignUpPage_mavryck.VerifyEmailValidation();

                Test.Log(Status.Info, $"Step {++step}: <b> Verify Wrong Email Format Validation Message </b>");
                await SignUpPage_mavryck.EnterEmail("emailtest");
                await SignUpPage_mavryck.ClickOnSignUpButton();
                await SignUpPage_mavryck.VerifyEmailValidation();


                Test.Log(Status.Info, $"Step {++step}: <b> Entering Valid Email To Check Other Validations </b>");
                await SignUpPage_mavryck.EnterEmail(email);


                Test.Log(Status.Info, $"Step {++step}: <b> Verify Empty Username Validation Message </b>");
                await SignUpPage_mavryck.ClickOnSignUpButton();
                await SignUpPage_mavryck.VerifyUsernameValidation();

                Test.Log(Status.Info, $"Step {++step}: <b> Entering Valid Username To Check Other Validations </b>");
                await SignUpPage_mavryck.EnterUsername(username);

                Test.Log(Status.Info, $"Step {++step}: <b> Verify Empty Company Validation Message </b>");
                await SignUpPage_mavryck.ClickOnSignUpButton();
                await SignUpPage_mavryck.VerifyCompanyValidation();

                Test.Log(Status.Info, $"Step {++step}: <b> Entering Valid Company To Check Other Validations </b>");
                await SignUpPage_mavryck.EnterCompany(company);

                Test.Log(Status.Info, $"Step {++step}: <b> Verify Empty Password Validation Message </b>");
                await SignUpPage_mavryck.ClickOnSignUpButton();
                await SignUpPage_mavryck.VerifyPasswordValidation();

                Test.Log(Status.Info, $"Step {++step}: <b> Entering Valid Password To Check Other Validations </b>");
                await SignUpPage_mavryck.EnterPassword();

                Test.Log(Status.Info, $"Step {++step}: <b> Verify Uncheck Agreement Validation Message </b>");
                await SignUpPage_mavryck.ClickOnSignUpButton();
                await SignUpPage_mavryck.VerifyTermsAndPolicyValidation();


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