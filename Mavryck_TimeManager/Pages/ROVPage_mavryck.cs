using System;
using System.Threading.Tasks;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;

namespace Mavryck_TimeManager.Pages
{

    namespace Mavryck_TimeManager.Pages
    {
        internal class ROVPage_mavryck : Base
        {
            private readonly IPage page;
            private const string ROV_Icon = "//img[@alt='rovIcon']";
            private const string AddNew_ROV_Row = "//button[@data-tooltip-id='addNewRowTooltip']";
            private const string FilterButton = "(//span[@role='presentation'])[1]";
            private const string DeleteButton = "//button[@data-tooltip-content='Delete']";
            private const string YesButton = "//button[text()='Yes, delete it!']";
            private const string ROV_YesButton = "//button[text()='Yes']";
            private const string ROV_NoButton = "//button[text()='No']";
            private const string CancelButton = "//button[text()='Cancel']";
            private const string Filter_Input1 = "//input[@placeholder='Filter...']";
            private const string Filter_Input2 = "(//input[@placeholder='Filter...'])[2]";
            private const string RCA_Icon = "//button[@data-tooltip-content='RCA by Mavryck AI']";
            private const string Theme = "//button[@data-tooltip-content='Theme']";
            private const string Name_ROV = "//span[text()='Double click to Edit']";
            private const string Start_date = "(//input[@type='date'])[1]";
            private const string End_date = "(//input[@type='date'])[2]";
            private const string Variance = "//input[@name='variance']";
            private const string ControlAccount = "//input[@name='controlAccount']";
            private const string AccountManager = "//input[@name='accountManager']";
            private const string Duration = "//p[text()='0']";
            private const string plusRootCauseButton = "//img[@alt='add cause']";
            private const string NextStepButton_RCA = "//button[text()='Next Step']";
            private const string RootCauseToolTip = "//button[@data-tooltip-content='RCA by Mavryck AI']";
            private const string SaveButton = "//button[text()='Save']";
            private const string RootCauseReset = "//button[@data-tooltip-content='Reset']";

            private const string Root_Cause = "(//button[@data-tooltip-content='Root Cause'])[1]";



            public ROVPage_mavryck(IPage page)
            {
                this.page = page;
            }

            public async Task ClickOnROV_Icon()
            {
                await page.ClickAsync(ROV_Icon);

            }
            public async Task ClickOnRootCause_Reset()
            {
                await page.ClickAsync(RootCauseReset);

            }

            public async Task ClickOnROV_YesButton()
            {
                await page.ClickAsync(ROV_YesButton);
            }

            public async Task ClickOnROV_NoButton()
            {
                await page.ClickAsync(ROV_NoButton);
            }


            public async Task ClickOnExistingROV()
            {
                await page.ClickAsync(ROV_Icon);
                await page.ClickAsync(FilterButton);
                await page.FillAsync(Filter_Input1, "Automation");
                await page.FillAsync(Filter_Input2, "ROV Test");
                await page.ClickAsync(Root_Cause);
            }
            public async Task Click_On_NewRow()
            {
                await page.ClickAsync(AddNew_ROV_Row);
            }

            public async Task Click_On_Filter()
            {
                await page.ClickAsync(FilterButton);

            }
            public async Task Click_On_RootCauseToolTip()
            {
                await page.ClickAsync(RootCauseToolTip);

            }
            public async Task Click_On_Delete()
            {
                await page.ClickAsync(DeleteButton);

            }
            public async Task Click_On_Yes()
            {
                await page.ClickAsync(YesButton);
            }
            public async Task Click_On_Cancel()
            {
                await page.ClickAsync(CancelButton);
            }

            public async Task Enter_ROV_Name()
            {
                await page.DblClickAsync(Name_ROV);
                await page.FillAsync("//input[@aria-label='Input Editor']", "Automation ROV Test");
                await page.Keyboard.PressAsync("Enter");

            }

            public async Task Click_ON_RootCause()
            {
                await page.ClickAsync(Root_Cause);

            }

            public async Task ClickOnSaveButton()
            {
                await page.ClickAsync(SaveButton);

            }

            public async Task Enter_StartDate()
            {
                DateTime today = DateTime.Now; 
                await page.FillAsync(Start_date, today.ToString("yyyy-MM-dd"));
            }
            public async Task Enter_EndDate()
            {
                DateTime today = DateTime.Now;
                DateTime tenDaysLater = today.AddDays(10);
                await page.FillAsync(End_date, tenDaysLater.ToString("yyyy-MM-dd"));

            }
            public async Task Enter_Variance(string variance)
            {
                await page.FillAsync(Variance, variance);

            }

            public async Task Enter_ControlAccount(string controlAccount)
            {
                await page.FillAsync(ControlAccount, controlAccount);

            }

            public async Task Enter_ControlAccountManager(string controlAccount_manager)
            {
                await page.FillAsync(AccountManager, controlAccount_manager);

            }

            public async Task EnterDuration(string duration)
            {
                await page.FillAsync(Duration, duration);

            }

            public async Task Enter_filterInput1(string input)
            {
                await page.FillAsync(Filter_Input1, input);

            }
            public async Task Enter_filterInput2(string input)
            {
                await page.FillAsync(Filter_Input2, input);

            }
            public async Task<bool> VerifyFilteredOuput()
            {
                return await WaitForElementVisible(page ,"//p[text()='Automation ROV Test']");

            }

            public async Task<bool> VerifyROVDeleted()
            {
                return await WaitForElementVisible(page, "//h2[text()='Deleted!']");

            }

            public async Task<bool> VerifyRootCauseAnalysis_Why1()
            {
                await ScrollToElement(page, "//textarea[@placeholder='WHY 1?']");
                return await WaitForElementVisible(page, "//textarea[@placeholder='WHY 1?']");


            }

            public async Task<bool> VerifyCorrectiveActionWhy()
            {
                var element= await page.QuerySelectorAsync("//textarea[@placeholder='Add corrective action.']");
                if (element.InnerTextAsync() != null)
                {
                    return true;
                }

                return false;
            }

            public async Task<bool> VerifyRootCauseWhy()
            {
                var element = await page.QuerySelectorAsync("//textarea[@placeholder='WHY 1?']");
                if (element.InnerTextAsync() != null)
                {
                    return true;
                }

                return false;
            }



            public async Task SelectTheme(string theme)
            {
                await page.ClickAsync(Theme);
                await page.ClickAsync($"//label[text()='{theme}']");

            }
            public async Task ClickOnRCAIcon()
            {
                await page.ClickAsync(RCA_Icon);

            }





            public async Task Enter_RootCauseWhy()
            {
                for(int i=1; i <=5; i++)
                {
                    await page.FillAsync($"//textarea[@placeholder='WHY {i}?']" , "Automtion Root Cause 1");
                    if (i== 5)
                    {
                        break;
                       
                    }
                    await page.ClickAsync(plusRootCauseButton);
                }
            }

            public async Task Enter_CorrectiveActionRootCause()
            {
                for (int i = 1; i <= 5; i++)
                {
                    await page.FillAsync($"(//textarea[@placeholder='Add corrective action.'])[{i}]", "Automtion Corrective Root Cause 1 ");
                }
            }
            
            public async Task ClickOnNextStep_RCA()
            {
                    await page.ClickAsync(NextStepButton_RCA);
                
            }


        }

    }

}
