using AventStack.ExtentReports;
using Microsoft.Playwright;
using Mavryck_TimeManager.Utils;
using System;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Mavryck_System.Pages
{
    internal class EnterpriseProjectPage_mavryck : Base
    {
        private readonly IPage page;

        private const string CreateProjectButton = "//span[text()='Create a Project ']";
        private const string ProjectName = "//input[@id='projectName']";
        private const string Tooltip = "//div[@role='tooltip']";

        private const string Industry = "//select[@id='industry']";
        private const string Location = "//select[@id='location']";
        private const string GridView = "//button[@data-tooltip-content='Grid View']";
        private const string Filter = "//button[@data-tooltip-content='filter']";
        private const string ListView = "//button[@data-tooltip-content='List View']";
        private const string TableView = "//button[@data-tooltip-content='Table View']";
        private const string Currency = "//select[@id='currency']";
        private const string ProjectStatus = "//select[@id='projectStatus']";
        private const string SaveButton = "//button[text()='Save']";
        private const string SaveProgramButton = "//button[text()='Save Program']";
        private const string ViewProjectButton = "//span[text()='View Projects']";
        private const string CancelButton = "//span[text()='Cancel']";
        private const string DeleteButton = "//img[@src='/images/icons/projectDirectory/Trash.svg']";
        private const string FilterButton = "//button[@data-tooltip-content='filter']";
        private const string EnterpriseDashboard = "//div[text()=' Enterprise Directory']";
        private const string ThreeDot = "(//button[@data-tooltip-content=\"Edit\"])[1]";
        private const string EditSaveButton = "//button[text()='Save']";
        private const string EditProjectName = "//input[@id=\"title\"]";
        private const string ViewFiles = "//span[text()='View Files']";
        private const string BrowseScheduleFile = "(//input[@type='file'])[1]";
        private const string BrowseCostFile = "(//input[@type='file'])[2]";
        private const string BrowseContractFile = "(//input[@type='file'])[3]";
        private const string UploadButton = "//button[text()='Upload']";
        private const string ErrorPopupProject = "//h3[text()='Error']";
        private const string ListViewButton = "(//button[@data-tooltip-id='pmTooltip'])[2]";
        private const string MavryckPrediction = "//span[text()='Mavryck Prediction']";
        private const string NoButton = "//button[text()='No']";
        private const string YesButton = "//button[text()='Yes']";
        private const string DeleteProgram = "//button[text()='Delete Program']";
        private const string ApplicationFilter = "//input[@placeholder='Application']";
        private const string FilterCancel = "//img[contains(@class ,'closeIcon')]";
        private const string LocationFilter = "//input[@placeholder='Location']";
        private const string IndustryFilter = "//input[@placeholder='Industry']";
        private const string VersionFilter = "//input[@placeholder='Version']";
        private const string ExtensionFilter = "//input[@placeholder='Extension']";
        private const string ProjectFilter = "//input[@placeholder='Project']";
        private const string CurrencyFilter = "//input[@placeholder='Currency']";
        private const string StatusFilter = "//input[@placeholder='Status']";
        private const string ProgramsNavMenu = "//span[text()='Programs']";
        private const string FilesNavMenu = "//span[text()='Files']";
        private const string Arrow = "//img[@src='/images/icons/sidebarArrow.svg']";
        private const string CreateAProgram = "//span[text()='Create a Program ']";
        private const string ProgramName = "//span[@id='projectName']";
        private const string programTitle = "//input[@id='title']";
        private const string ProgramStatus = "//select[@name='status']";
        private const string CreateProgram = "//span[text()='Create Program ']";
        private const string DateUploaded = "(//span[text()='Date Uploaded']//following-sibling::span)[1]";
        private const string LastUploaded = "(//span[text()='Last Updated']//following-sibling::span)[1]";
        private const string Version = "(//span[text()='Version']//following-sibling::span)[1]";
        ArrayList testSteps;
        ExtentTest Test;
        public EnterpriseProjectPage_mavryck(IPage page , ExtentTest test)
        {
            this.page = page;
            testSteps = new ArrayList();
            Test = test;
        }

        public async Task<ArrayList> CreateProject(int step, string projectName, string industry, string location, string currency, string status)
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

        public async Task<bool> VerifyHoverTooltip()
        {
            return await WaitForElementVisible(page, Tooltip, 120000);
        }
        public async Task ClickOnCreateProjectButton()
        {
            await page.ClickAsync(CreateProjectButton);
        }

        public async Task ClickOnThreedot()
        {
            await page.ClickAsync(ThreeDot);
        }

        public async Task ClickOnProgramsNavMenu()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(ProgramsNavMenu);
        }

        public async Task ClickOnFilesNavMenu()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(FilesNavMenu);
        }
        public async Task ClickOnTableView()
        {
            await page.ClickAsync(TableView);
        }





        public async Task ClickOnCreateAProgram()
        {
            await page.ClickAsync(CreateAProgram);
        }


        public async Task<bool> VerifyProjectNameIsVisible()
        {
            return await WaitForElementVisible(page, ProjectName, 120000);
        }
        public async Task<bool> VerifyListViewProjectNameIsVisible()
        {
            try
            {
                return await WaitForElementVisible(page, "(//img[@alt='table']//following-sibling::span)[1]", 120000);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task HoverGridView()
        {
            var elementToHover = await page.QuerySelectorAsync(GridView);
            await elementToHover.HoverAsync();
        }
        public async Task HoverFilter()
        {
            var elementToHover = await page.QuerySelectorAsync(Filter);
            await elementToHover.HoverAsync();
        }

        public async Task HoverListView()
        {
            var elementToHover = await page.QuerySelectorAsync(ListView);
            await elementToHover.HoverAsync();
        }
        public async Task HoverTableView()
        {
            var elementToHover = await page.QuerySelectorAsync(TableView);
            await elementToHover.HoverAsync();
        }
        public async Task<bool> VerifyLocationIsVisible()
        {
            return await WaitForElementVisible(page, Location, 120000);
        }

        public async Task<bool> VerifyListViewRequirementsIsVisible(string value)
        {
            return await WaitForElementVisible(page, $"//span[text()='{value}']", 120000);
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

        public async Task<bool> VerifyDeleteButtonIsDisplaying()
        {
            return await WaitForElementVisible(page, DeleteButton, 120000);
        }
        public async Task<bool> VerifyViewProjectButtonIsDisplaying()
        {
            return await WaitForElementVisible(page, ViewProjectButton, 120000);
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


        public async Task<bool> VerifyErrorPopup()
        {
            return await WaitForElementVisible(page, ErrorPopupProject, 120000);
        }

        public async Task<bool> VerifyProjectIsDisplaying(string ProjectName)
        {
            return await WaitForElementVisible(page, "//h3[text()='" + ProjectName + "']", 120000);
        }

        public async Task<bool> VerifyProgramIsDisplaying(string programName)
        {
            return await WaitForElementVisible(page, "//h3[text()='" + programName + "']", 120000);
        }

        public async Task EnterProjectName(string name)
        {
            await page.FillAsync(ProjectName, name);
        }





        public async Task ClickUpload()
        {
            await page.ClickAsync(UploadButton);
        }



        public async Task<bool> PleaseContactAdmin()
        {
            return await WaitForElementVisible(page, "//h2[text()='Administrator Required']", 120000);
        }


        public async Task<bool> VerifyFileUploaded(string fileName)
        {
            return await WaitForElementVisible(page, "//tr[text()='" + fileName + "']", 120000);
        }
        public async Task SelectVersionNumber(string version)
        {
            await page.FillAsync($"(//input[@type='number'])[{version}]", version);
        }

        public async Task<bool> VerifyThreeDot()
        {
            return await WaitForElementVisible(page, ThreeDot, 120000);
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
            await page.SetInputFilesAsync(BrowseContractFile, contractFile);
        }

        public async Task UploadScheduleFile()
        {
            await page.SetInputFilesAsync(BrowseScheduleFile, scheduleFile);
        }
        public async Task ClickOnSaveButton()
        {
            await page.ClickAsync(SaveButton);
        }
        public async Task ClickOnSaveProgramButton()
        {
            await page.ClickAsync(SaveProgramButton);
        }


        public async Task ClickOnEditSaveButton()
        {
            await page.ClickAsync(EditSaveButton);
        }
        public async Task ClickOnCancelButton()
        {
            await page.ClickAsync(CancelButton);
        }

        public async Task ClickOnDeleteButton()
        {
            await page.ClickAsync(DeleteButton);
        }

        public async Task ClickOnFilterButton()
        {
            await page.ClickAsync(FilterButton);
        }

        public async Task ClickOnViewFilesButton()
        {
            await page.ClickAsync(ViewFiles);
        }

        public async Task ClickOnListView()
        {
            await page.ClickAsync(ListViewButton);
        }


        public async Task<bool> VerifyAppDashboardIsDisplaying(string appName)
        {
            return await WaitForElementVisible(page, $"//div[text()=' {appName}']", 120000);

        }




        public async Task<bool> VerifyMavryckPrediction()
        {
            return await WaitForElementVisible(page, MavryckPrediction, 120000);

        }



        public async Task<bool> VerifyVersion()
        {
            return await WaitForElementVisible(page, Version, 120000);

        }

        public async Task<bool> VerifyAppIcons(string appName)
        {
            return await WaitForElementVisible(page, $"(//img[@src='/images/products/{appName}'])[2]", 120000);

        }
        public async Task<bool> VerifyVersionFiles(string version)
        {
            var element = await page.QuerySelectorAsync("(//span[text()='Version']//following-sibling::span)[1]");
            var text = await element.InnerTextAsync();
            if (text.Contains(version))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> VerifyProjectFiles()
        {
            return await WaitForElementVisible(page, $"(//span[text()='Date Uploaded']//following-sibling::span)[1]", 120000);
        }

        public async Task<bool> VerifyExtensionFiles(string extension)
        {
            return await WaitForElementVisible(page, $"//h3[contains(text() , '{extension}')]", 120000);

        }

        public async Task<bool> VerifyFilesIcons(string appName)
        {
            try
            {
                return await WaitForElementVisible(page, $"//img[@src='/images/products/{appName}.svg']", 120000);

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task ClickOnAppIcons(string appName)
        {
            await page.ClickAsync($"(//img[@src='/images/products/{appName}'])[2]");

        }

        public async Task ClickOnAppIcons2(string appName)
        {
            await page.ClickAsync($"(//img[@src = '/images/AppScreen/{appName}'])[2]");

        }

        public async Task<bool> VerifyAppIcons2(string appName)
        {
            return await WaitForElementVisible(page, $"(//img[@src = '/images/AppScreen/{appName}'])[2]", 120000);

        }


        public async Task<bool> VerifyApplicationFilterProjects(string icon)
        {
            try
            {
                var element = await page.QuerySelectorAsync($"//img[@src = '/images/products/{icon}.svg']");
                if (element != null)
                {
                    return true;  // If element is found, return true.
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding application: {ex.Message}");
            }
            try
            {
                var element = await page.QuerySelectorAsync($"//img[@src = '/images/AppScreen/{icon}.svg']");
                if (element != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding application: {ex.Message}");

            }
            try
            {
                var element = await page.QuerySelectorAsync($"//p[text() = 'No Project Found.']");
                if (element != null)
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding application: {ex.Message}");

            }

            return false;

        }
        public async Task<bool> VerifyIndustryFilterProjects(string value)
        {
            try
            {
                var element = await page.QuerySelectorAsync($"//span[text()='Industry']//following-sibling::span[contains(text(),'{value}')]");
                if (element != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding application: {ex.Message}");
            }

            return false;

        }
        public async Task<bool> VerifyStatusFilterProjects(string value)
        {
            try
            {
                var element = await page.QuerySelectorAsync($"//div[contains(text(), '{value}')]");
                if (element != null)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding application: {ex.Message}");
            }
            return false;


        }


        public async Task<bool> VerifyDateUploaded()
        {
            return await WaitForElementVisible(page, DateUploaded, 120000);

        }
        public async Task<bool> VerifyLastUpdated()
        {
            return await WaitForElementVisible(page, LastUploaded, 120000);

        }


        public async Task ClickOnApplicationFilter()
        {
            await page.ClickAsync(ApplicationFilter);
        }
        public async Task ClickOnFilterCancel()
        {
            await page.ClickAsync(FilterCancel);
        }

        public async Task SelectFilter(string filter)
        {
            await ScrollToElement(page, $"//li[text()='{filter}']");
            await page.ClickAsync($"//li[text()='{filter}']");

        }

        public async Task ClickOnLocationFilter()
        {
            await page.ClickAsync(LocationFilter);
        }
        public async Task ClickOnVersionFilter()
        {
            await page.ClickAsync(VersionFilter);
        }

        public async Task ClickOnProjectFilter()
        {
            await page.ClickAsync(ProjectFilter);
        }

        public async Task ClickOnExtensionFilter()
        {
            await page.ClickAsync(ExtensionFilter);
        }

        public async Task ClickOnIndustryFilter()
        {
            await page.ClickAsync(IndustryFilter);
        }

        public async Task ClickOnCurrencyFilter()
        {
            await page.ClickAsync(CurrencyFilter);
        }

        public async Task ClickOnStatusFilter()
        {
            await page.ClickAsync(StatusFilter);
        }

        public async Task ClickOnNoButton()
        {
            await page.ClickAsync(NoButton);
        }

        public async Task ClickOnYesButton()
        {
            await page.ClickAsync(YesButton);
        }

        public async Task ClickOnDeleteProgramButton()
        {
            await page.ClickAsync(DeleteProgram);
        }

        public async Task SelectProgramStatus(string status)
        {
            await page.ClickAsync(ProgramStatus);
            await page.SelectOptionAsync(ProgramStatus, status);

        }

        public async Task SelectProgramProjectStatus(string status)
        {
            await page.ClickAsync(ProjectStatus);
            await page.SelectOptionAsync(ProjectStatus, status);

        }

        public async Task ClickOnCreateProgram()
        {
            await page.ClickAsync(CreateProgram);

        }

        public async Task EnterProgramName(string programName)
        {
            await page.FillAsync(ProgramName, programName);

        }

        public async Task EnterProgramTitle(string programName)
        {
            await page.FillAsync(programTitle, programName);

        }


        public async Task SelectAppFromTopRight_Menu(string app)
        {
            await page.ClickAsync($"(//img[@src='/images/products/{app}.svg'])[2]");

        }

        public async Task SelectAppFromTopRight_Menu1(string app)
        {
            await page.ClickAsync($"(//img[@src='/images/AppScreen/cost.svg'])[3]");

        }




    }

}