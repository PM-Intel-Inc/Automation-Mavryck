using AventStack.ExtentReports;
using Microsoft.Playwright;
using Mavryck_TimeManager.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
//using Mavryck_TimeManager.Tests.EnterpriseDirectoryTests;


namespace Mavryck_TimeManager.Pages
{
    internal class LoginPage_mavryck : Base
    {
        private readonly IPage page;

        private const string EmailInput = "//input[@placeholder='Email']";
        private const string PasswordInput = "//input[@placeholder='Password']";
        private const string LoginButton = "//button[text()='Login to Mavryck']";
        private const string Dashboard = "//h2[text()=' Mavryck Apps']";
        private const string AlertMessage = "//div[text()='Invalid email or password']";
        private const string RememberMeCheckbox = "//input[@type='checkbox']";
        private const string ForgotPassword = "//a[text()='Forgot Password?']";
        private const string UpdateButton = "//button[text()='Update Password']";
        private const string Profile = "//button[text()='Mavryck Interal']";
        private const string SignOutButton = "//button[text()='Sign Out']";
        private const string LoginDashboard = "//h4[text()='Welcome to the revolution']";
        private const string SignUpLink = "//a[text()='Sign Up']";
        private const string LoginWithMicrosoftButton = "//span[text()='Sign in with Microsoft']";

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
            Thread.Sleep(100000);


            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify that the <b> Mavryck Dashboard</b>  is displaying"));
            Assert.True(await VerifyDashboardPageIsVisible());

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


        public async Task<bool> VerifyDashboardPageIsVisible()
        {
            return await WaitForElementVisible(page, Dashboard, 100000);
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