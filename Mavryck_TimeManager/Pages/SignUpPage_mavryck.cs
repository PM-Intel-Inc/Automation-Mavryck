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


namespace Mavryck_TimeManager.Pages
{
    internal class SignUpPage_mavryck : Base
    {
        private readonly IPage page;

        private const string EmailInput = "//input[@type='email']";
        private const string UsernameInput = "//input[@id='username']";
        private const string CompanyInput = "//input[@id='company']";
        private const string PasswordInput = "//input[@id='passwordRegister']";
        private const string SignUpButton = "//span[text()='Sign up to Mavryck']";
        private const string SignUpDashboard = "//h4[text()=' Sign up to Mavryck']";
        private const string AgreeToTerms = "//a[text()=' Terms and Conditions ']";
        private const string PrivacyPolicy = "//a[text()=' Privacy Policy']";
        private const string LoginLink = "//a[text()='Log in']";
        private const string EmailValidation = "//div[text()='Enter a valid email address']";
        private const string UsernameValidation = "//div[text()='Username is required']";
        private const string CompanyValidation = "//div[text()='Company name is required']";
        private const string PasswordValidation = "//div[text()='Password must be at least 6 characters long']";
        private const string TermsAndPolicyValidation = "//div[text()='Please agree to the terms and conditions.']";
        private const string TermsCheckbox = "//input[@id='termsAndPrivacyCheck']";


        public SignUpPage_mavryck(IPage page)
        {
            this.page = page;
        }

      
        public async Task ClickOnSignUpButton()
        {
            await page.ClickAsync(SignUpButton);
        }

        public async Task ClickOnLoginLinkButton()
        {
            await page.ClickAsync(LoginLink);
        }


        public async Task EnterEmail(string email)
        {
            await page.FillAsync(EmailInput, email);
        }
        public async Task EnterUsername(string username)
        {
            await page.FillAsync(UsernameInput, username);
        }
        public async Task EnterPassword()
        {
            await page.FillAsync(PasswordInput, password);
        }

        public async Task EnterCompany(string company)
        {
            await page.FillAsync(CompanyInput, company);
        }
        public async Task ClickOnTermsAndPolicy()
        {
            await page.ClickAsync(TermsCheckbox);
        }

        public async Task ClearContent()
        {
            await page.FillAsync(EmailInput, "");
            await page.FillAsync(UsernameInput, "");
            await page.FillAsync(CompanyInput, "");
            await page.FillAsync(PasswordInput, "");
        }

        public async Task<bool> VerifyEmailValidation()
        {
            return await WaitForElementVisible(page, EmailValidation, 120000);
        }


        public async Task<bool> VerifyUsernameValidation()
        {
            return await WaitForElementVisible(page, UsernameValidation, 360000);
        }

        public async Task<bool> VerifyTermsAndPolicyValidation()
        {
            return await WaitForElementVisible(page, TermsAndPolicyValidation, 120000);
        }


        public async Task<bool> VerifyPasswordValidation()
        {
            return await WaitForElementVisible(page, PasswordValidation, 120000);
        }

        public async Task<bool> VerifyCompanyValidation()
        {
            return await WaitForElementVisible(page, CompanyValidation, 120000);
        }



        public async Task<bool> VerifySignUpDashboardIsVisible()
        {
            return await WaitForElementVisible(page, SignUpDashboard, 120000);
        }

        public async Task<bool> VerifyEmailIsVisible()
        {
            return await WaitForElementVisible(page, EmailInput, 120000);
        }

        public async Task<bool> VerifyUsernameIsVisible()
        {
            return await WaitForElementVisible(page, UsernameInput, 120000);
        }

        public async Task<bool> VerifyAgreeToTermsIsVisible()
        {
            return await WaitForElementVisible(page, AgreeToTerms, 120000);
        }

        public async Task<bool> VerifyPrivacyPolicyIsVisible()
        {
            return await WaitForElementVisible(page, PrivacyPolicy, 120000);
        }

        public async Task<bool> VerifyCompanyIsVisible()
        {
            return await WaitForElementVisible(page, UsernameInput, 120000);
        }

        public async Task<bool> VerifyPasswordIsVisible()
        {
            return await WaitForElementVisible(page, PasswordInput, 120000);
        }
        public async Task<bool> VerifyLoginLinkIsVisible()
        {
            return await WaitForElementVisible(page, LoginLink, 120000);
        }

        public async Task<bool> VerifySignUpButtonIsVisible()
        {
            return await WaitForElementVisible(page, SignUpButton, 120000);
        }

    }
}