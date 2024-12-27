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


namespace Mavryck_TimeManager.Pages
{
    internal class EnterpriseProjectPage_mavryck : Base
    {
        private readonly IPage page;

        private const string CreateProjectButton = "//span[text()='Create a Project ']";
        private const string ProjectName = "//input[@id='projectName']";
        private const string Industry = "//select[@id='industry']";
        private const string Location = "//select[@id='location']";
        private const string Currency = "//select[@id='currency']";
        private const string ProjectStatus = "//select[@id='projectStatus']";
        private const string SaveButton = "//button[text()='Save']";
        private const string CancelButton = "//span[text()='Cancel']";
        private const string EnterpriseDashboard = "//div[text()=' Enterprise Directory']";
        private const string ThreeDot = "(//button[@data-tooltip-content=\"Edit\"])[1]";
        private const string EditSaveButton = "//button[text()='Save']";
        private const string EditProjectName = "//input[@id=\"title\"]";
        private const string ViewFiles = "//span[text()='View Files']";
        private const string BrowseCostFile = "(//input[@type='file'])[2]";
        private const string BrowseContractFile = "(//input[@type='file'])[2]";
        ArrayList testSteps;

        public EnterpriseProjectPage_mavryck(IPage page)
        {
            this.page = page;
            testSteps = new ArrayList();
        }

        public async Task<ArrayList> CreateProject(int step , string projectName , string industry , string location , string currency , string status)
        {

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Enterprise Directory</b> is displaying"));
            Assert.True(await VerifyEnterpriseDashboardIsVisible());

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click On <b> Create New Project </b> Button"));
            await ClickOnCreateProjectButton();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Enter <b>Project Name</b> "));
            await EnterProjectName(projectName);

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select <b>Industry </b>"));
            await SelectIndustry(industry);

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select <b> Location <b> "));
            await SelectLocation(location);

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select <b> Currenct <b> "));
            await SelectCurrency(currency);

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Select <b> Project Status <b> "));
            await SelectProjectStatus(status);

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Click <b> Save Button <b> "));
            await ClickOnSaveButton();


            return testSteps;

        }
        public async Task ClickOnCreateProjectButton()
        {
            await page.ClickAsync(CreateProjectButton);
        }

        public async Task ClickOnThreedot()
        {
            await page.ClickAsync(ThreeDot);
        }


        public async Task<bool> VerifyProjectNameIsVisible()
        {
            return await WaitForElementVisible(page, ProjectName, 120000);
        }
        public async Task<bool> VerifyLocationIsVisible()
        {
            return await WaitForElementVisible(page, Location, 120000);
        }

        public async Task<bool> VerifyIndustryIsVisible()
        {
            return await WaitForElementVisible(page, Industry, 120000);
        }

        public async Task<bool> VerifySaveButtonIsVisible()
        {
            return await WaitForElementVisible(page, SaveButton, 120000);
        }

        public async Task<bool> VerifyCancelButtonIsVisible()
        {
            return await WaitForElementVisible(page, CancelButton, 120000);
        }

        public async Task<bool> VerifyCurrencyIsVisible()
        {
            return await WaitForElementVisible(page, Currency, 120000);
        }


        public async Task<bool> VerifyProjectStatusIsVisible()
        {
            return await WaitForElementVisible(page, ProjectStatus, 120000);
        }

        public async Task<bool> VerifyEnterpriseDashboardIsVisible()
        {
            return await WaitForElementVisible(page, EnterpriseDashboard, 120000);
        }

        public async Task<bool> VerifyProjectIsDisplaying(string ProjectName)
        {
            return await WaitForElementVisible(page, "//h3[text()='"+ProjectName+"']", 120000);
        }


        public async Task EnterProjectName(string name)
        {
            await page.FillAsync(ProjectName , name);
        }


        public async Task EnterEditProjectName(string name)
        {
            await page.FillAsync(EditProjectName, name);
        }

        public async Task SelectIndustry(string industry)
        {
            await page.SelectOptionAsync(Industry, industry);
        }

        public async Task SelectLocation(string location)
        {
            await page.SelectOptionAsync(Location, location);
        }

        public async Task SelectCurrency(string currency)
        {
            await page.SelectOptionAsync(Currency, currency);
        }
        public async Task SelectProjectStatus(string status)
        {
            await page.SelectOptionAsync(ProjectStatus, status);
        }

        public async Task SelectProjectAvatar(string color)
        {
            await page.SelectOptionAsync(ProjectStatus, color);
        }

        public async Task UploadCostFile()
        {
            await page.SetInputFilesAsync(BrowseCostFile, costFile);
        }

        public async Task UploadContractFile()
        {
            await page.FillAsync(BrowseContractFile, contractFile);
        }
        public async Task ClickOnSaveButton()
        {
            await page.ClickAsync(SaveButton);
        }


        public async Task ClickOnEditSaveButton()
        {
            await page.ClickAsync(EditSaveButton);
        }
        public async Task ClickOnCancelButton()
        {
            await page.ClickAsync(CancelButton);
        }

        public async Task ClickOnViewFilesButton()
        {
            await page.ClickAsync(ViewFiles);
        }

    }
}