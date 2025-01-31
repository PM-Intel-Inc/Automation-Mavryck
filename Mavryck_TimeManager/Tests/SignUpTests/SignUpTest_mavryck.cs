using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using System;
using System.Threading.Tasks;
using PlanNotePlaywrite;
using System.Threading;
using System.Collections;

namespace Mavryck_TimeManager.Tests.SignUpTests
{ 
    [Order(3)]
    public class SignUpTest_mavryck : Base
    {
        

        [Test, Order(1)]
        [Parallelizable]
        public async Task VerifyThe_SignUpDashboardRequirements()
        {
            var Test = Extent.CreateTest("Verify The Sign Up Dashboard Requirements");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var SignUpPage_mavryck = new SignUpPage_mavryck(page, Test);

            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);
                Thread.Sleep(100000);

                Test.Log(Status.Info, $"Step {++step}: Click On Sign Up Button");
                await loginPage_mavryck.ClickOnSignUpButton();

                Test.Log(Status.Info, $"<b> Verify All the Login Screen Requirements <b>");
                Thread.Sleep(100000);

                await SignUpPage_mavryck.ClearContent();
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
        [Parallelizable]
        public async Task VerifyUserCan_SignUpToMavryck()
        {
            var Test = Extent.CreateTest("Verify User Can Successfully Sign Up To The Mavryck");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var SignUpPage_mavryck = new SignUpPage_mavryck(page, Test);
            var company = "mavryck";
            var username = "test";
            try
            {
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);
                Thread.Sleep(100000);


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
        [Parallelizable]
        public async Task Verify_SignUpValidationMessage()
        {
            var Test = Extent.CreateTest("Verify Sign Up Validations");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var SignUpPage_mavryck = new SignUpPage_mavryck(page, Test);
            var company = "mavryck";
            var username = "test";
            try
            {
                Test = Extent.CreateTest("Verify Sign Up Validations");

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);
                Thread.Sleep(100000);


                Test.Log(Status.Info, $"Step {++step}: Click On Sign Up Link");
                await loginPage_mavryck.ClickOnSignUpButton();
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Clear Sign Up Form");
                await SignUpPage_mavryck.ClearContent();
                Thread.Sleep(10000);


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