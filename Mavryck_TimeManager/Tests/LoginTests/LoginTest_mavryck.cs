using AventStack.ExtentReports;
using Microsoft.Playwright;
using NUnit.Framework;
using Mavryck_TimeManager.Pages;
using Mavryck_TimeManager.Utils;
using System;
using System.Threading.Tasks;
using PlanNotePlaywrite;
using System.Threading;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Constants = Mavryck_TimeManager.Utils.Constants;
using System.Collections;
using Newtonsoft.Json;
using System.IO;


namespace Mavryck_TimeManager.Tests.LoginTests
{
    [Order(2)]
    public class LoginTest_mavryck : Base
    {
       
        [Test]
        [Parallelizable]
        public async Task VerifyThe_LoginDashboardRequirements()
        {
            var Test = Extent.CreateTest("Verify The Login Dashboard Requirements");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            var loginPage_mavryck = new LoginPage_mavryck(page , Test);
            int step = 0;

            try
            {                
                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);

                Test.Log(Status.Info, $"<b> Verify All the Login Screen Requirements <b>");
                Thread.Sleep(100000);

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

        [Test]
        [Parallelizable]
        public async Task VerifyThat_UserCanLoginWithValidCredentials()
        {
            var Test = Extent.CreateTest("Verify Login With Valid Credentials");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            var loginPage_mavryck = new LoginPage_mavryck(page  , Test);

            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);
                Thread.Sleep(100000);


                Test.Log(Status.Info, $"Step {++step}: Enter Credentials: Email :" + email + " Password: " + password);
                await loginPage_mavryck.EnterLoginCredentials(email, password);


                Test.Log(Status.Info, $"Step {++step}: Click On Remember Me Checkbox");
                await loginPage_mavryck.ClickOnRememberMeCheckbox();

                Test.Log(Status.Info, $"Step {++step}: Click On Login Button");
                await loginPage_mavryck.ClickOnSubmitButton();

                Thread.Sleep(100000);
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


        [Test]
        [Parallelizable]
        public async Task UserUnableLoginWith_InValidCredentials()
        {
            var Test = Extent.CreateTest("Verify User Unable To Login With InValid Credentials");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            var Invalid_email = "test@com.pk";
            var Invalid_password = "123456";


            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);
                Thread.Sleep(100000);


                Test.Log(Status.Info, $"Step {++step}: Enter Credentials: InValid Email :" + email + " InValid Password: " + password);
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

        [Test]
        [Parallelizable]
        public async Task UserCanUpdateThe_Password()
        {
            var Test = Extent.CreateTest("Verify User Can Update The Password");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);
            try
            {

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

        [Test]
        [Parallelizable]
        public async Task UserCan_SignOut_FromMavryck()
        {
            var Test = Extent.CreateTest("Verify User Can Sign Out From Mavryck");
            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            int step = 0;
            var loginPage_mavryck = new LoginPage_mavryck(page, Test);

            try
            {

                Test.Log(Status.Info, $"Step {++step}: Launching the app");
                await loadURL(page, Constants.BaseUrl);
                Thread.Sleep(100000);


                Test.Log(Status.Info, $"Step {++step}: Enter Credentials: Email :" + email + " Password: " + password);
                await loginPage_mavryck.EnterLoginCredentials(email, password);


                Test.Log(Status.Info, $"Step {++step}: Click On Remember Me Checkbox");
                await loginPage_mavryck.ClickOnRememberMeCheckbox();

                Test.Log(Status.Info, $"Step {++step}: Click On Login Button");
                await loginPage_mavryck.ClickOnSubmitButton();

                Test.Log(Status.Info, $"Step {++step}: Verify that the <b> Mavryck Dashboard</b>  is displaying");
                Assert.True(await loginPage_mavryck.VerifyDashboardPageIsVisible());
                Thread.Sleep(10000);

                Test.Log(Status.Info, $"Step {++step}: Click On Sign Out Button");
                await loginPage_mavryck.ClickOnSignOutButton();
                Thread.Sleep(10000);


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