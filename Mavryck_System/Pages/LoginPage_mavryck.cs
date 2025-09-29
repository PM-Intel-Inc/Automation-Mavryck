using AventStack.ExtentReports;
using Microsoft.Playwright;
using Mavryck_System.Utils;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using static System.Net.WebRequestMethods;


namespace Mavryck_System.Pages
{
    internal class LoginPage_mavryck : Base
    {
        private readonly IPage page;

        private const string EmailInput = "//input[@id='email']";
        private const string PasswordInput = "//input[@id='password']";
        private const string LoginButton = "//button[text()='Login']";
        private const string Dashboard = "//h2[text()=' Mavryck Apps']";
        private const string AlertMessage = "//div[text()='Network error. Please check your connection and try again.']";
        private const string RememberMeCheckbox = "//input[@id='rememberMe']";
        private const string ForgotPassword = "//a[text()='Forgot Password?']";
        private const string UpdateButton = "//button[text()='Update Password']";
        private const string Profile = "//button[text()='Mavryck Interal']";
        private const string SignOutButton = "//button[text()='Sign Out']";
        private const string SubmitOTPButton = "//button[text()='Submit']";
        private const string LoginDashboard = "//h1[text()='Project & Decision Intelligence. Built In.']";
        private const string SignUpLink = "//a[text()='Sign Up']";
        private const string LoginWithMicrosoftButton = "//button[text()='Sign in with Microsoft']";
        private const string OtpScreen = "//label[text()='OTP Code']";


        ArrayList testSteps;
        ExtentTest Test;
        public LoginPage_mavryck(IPage page , ExtentTest test)
        {
            this.page = page;
            testSteps = new ArrayList();
            Test = test;

        }

        public async Task<ArrayList> Login(int step)
        {

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Enter Credentials: Email :" + email + " Password: " + password));
            await EnterLoginCredentials(email, password);


            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On Remember Me Checkbox"));
            await ClickOnRememberMeCheckbox();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On Login Button"));
            await ClickOnSubmitButton();

            Test.Log(Status.Info, $"Step {++step}: Verify that the <b> OTP Screen </b>  is displaying");
            Assert.True(await VerifyOTPScreen());

            Test.Log(Status.Info, $"Step {++step}: Enter <b> OTP Screen </b> " + otp);
            await EnterOTP(otp);

            Test.Log(Status.Info, $"Step {++step}: Click On Submit Button");
            await ClickOnsubmitOtpButton();

            //Test.Log(Status.Info, $"Step {++step}: Verify that the <b> Mavryck Dashboard</b>  is displaying");
            //Assert.True(await VerifyDashboardPageIsVisible());

            return testSteps;


        }

        public async Task EnterLoginCredentials(string username, string password)
        {
            await page.FillAsync(EmailInput, username);
            Thread.Sleep(10000);
            await page.FillAsync(PasswordInput, password);
        }

        public async Task ClickOnSubmitButton()
        {
            await page.ClickAsync(LoginButton);
        }
        public async Task ClickOnRememberMeCheckbox()
        {
            await page.ClickAsync(RememberMeCheckbox);
        }

        public async Task ClickOnForgotPassword()
        {
            await page.ClickAsync(ForgotPassword);
        }

        public async Task EnterForgotPasswordEmail()
        {
            await page.FillAsync(EmailInput, email);
        }

        public async Task ClickOnUpdateButton()
        {
            await page.ClickAsync(UpdateButton);
        }

        public async Task ClickOnSignOutButton()
        {
            await page.ClickAsync(Profile);
            await page.ClickAsync(SignOutButton);
        }

        public async Task ClickOnSignUpButton()
        {
            await page.ClickAsync(SignUpLink);
        }
        public async Task ClickOnsubmitOtpButton()
        {
            await page.ClickAsync(SubmitOTPButton);
        }


        public async Task<bool> VerifyDashboardPageIsVisible()
        {
            return await WaitForElementVisible(page, Dashboard, 100000);
        }
        public async Task EnterOTP(string otp)
        {
            for(int i=1; i<=otp.Length; i++)
            {
                await page.FillAsync($"(//input[@type='text'])[{i}]", otp);
            }


        }
        public async Task<bool> VerifyOTPScreen()
        {
            return await WaitForElementVisible(page, OtpScreen, 100000);
        }

        public async Task<bool> VerifyLoginDashboardPageIsVisible()
        {
            return await WaitForElementVisible(page, LoginDashboard, 100000);

        }

        public async Task<bool> VerifyAlertMessageIsVisible()
        {
            return await WaitForElementVisible(page, AlertMessage, 100000);

        }
        public async Task<bool> VerifyRememberMeCheckboxIsVisible()
        {
            return await WaitForElementVisible(page, RememberMeCheckbox, 120000);
        }
        public async Task<bool> VerifyForgotPasswordIsVisible()
        {
            return await WaitForElementVisible(page, ForgotPassword, 120000);
        }
        public async Task<bool> VerifyEmailIsVisible()
        {
            return await WaitForElementVisible(page, EmailInput, 120000);
        }
        public async Task<bool> VerifyPasswordIsVisible()
        {
            return await WaitForElementVisible(page, PasswordInput, 120000);
        }

        public async Task<bool> VerifyLoginButtonIsVisible()
        {
            return await WaitForElementVisible(page, LoginButton, 120000);
        }
        public async Task<bool> VerifySignUpLinkIsVisible()
        {
            return await WaitForElementVisible(page, SignUpLink, 120000);
        }
        public async Task<bool> VerifySignInWithMicrosoftIsVisible()
        {
            return await WaitForElementVisible(page, LoginWithMicrosoftButton, 120000);
        }







    }
}