using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;

namespace Mavryck_TimeManager.Pages
{
    internal class TimeManagerPage_mavryck : Base
    {
        private readonly IPage page;
        private const string TextAlignmentButton = "(//button[@data-tooltip-id='gridFeatuesTooltip'])[2]";
        private const string Version = "//span[text()='V10']";
        private const string AddFile = "//button[text()='Add File']";
        private const string Date = "//div[text()='20 Mar, 2024']";
        private const string AddMember = "//button[@id='addMember']";
        private const string AvailableROV = " //h3[text()='Available ROVs: ']";
        private const string MissingROV = " //h3[text()='Missing ROVs: ']";
        private const string ActivityGrid = "//div[@grid-id='2']";


        public TimeManagerPage_mavryck(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnTextAllignmentButton()
        {
            await page.ClickAsync(TextAlignmentButton);
        }

    

        public async Task SelectAllignment(string ColumnName , string textAllign)
        {

            await ScrollToElement(page, $"//label[text()='{ColumnName}']//following-sibling::div//div//select");
            await page.SelectOptionAsync($"//label[text()='{ColumnName}']//following-sibling::div//div//select", textAllign);
        }

       

        public async Task<bool> VerifyTextAlign(string expectedAlignment, string columnIndex)
        {
            

            var element = await page.QuerySelectorAsync($"div.ag-cell[aria-colindex='{columnIndex}']");
            var textAlign = await page.EvaluateAsync<string>("element => window.getComputedStyle(element).getPropertyValue('text-align')", element);
            if (textAlign != expectedAlignment)
            {
                Console.Write(textAlign  , expectedAlignment);
                return true;

             }
            return false;
        }

        public async Task<bool> VerifyVersion()
        {
            return await WaitForElementVisible(page, Version, 120000);
        }

        public async Task<bool> VerifyDate()
        {
            return await WaitForElementVisible(page, Date, 120000);

        }

        public async Task<bool> VerifyAdd_File_Button()
        {
            return await WaitForElementVisible(page, AddFile, 120000);

        }

        public async Task<bool> VerifyAdd_Member()
        {
            return await WaitForElementVisible(page, AddMember, 120000);

        }
        public async Task<bool> VerifyAvailable_ROV()
        {
            return await WaitForElementVisible(page, AvailableROV, 120000);

        }

        public async Task<bool> VerifyMissing_ROV()
        {
            return await WaitForElementVisible(page, MissingROV, 120000);

        }

        public async Task<bool> VerifyActivity_Grid()
        {
            return await WaitForElementVisible(page, ActivityGrid, 120000);

        }




        //public async Task<bool> VerifyForwardGoToNextPagePaginationWorkProperly()
        //{
        //    bool status = true;
        //    string val = await GetElementTextContent(page, PaginationPageCount);
        //    int count = int.Parse(await ExtractPageNumberAsync(val));
        //    while (true)
        //    {
        //        count++;
        //        if (await IsButtonDisabled(page, GoToNextPageBtn) != true)
        //        {
        //            await clickOnGoToNextPageButton();
        //            status = await WaitForElementVisible(page, "//span[contains(text(),'Page " + count + "')]");
        //        }
        //        if (count == 5)
        //        {
        //            break;
        //        }
        //    }
        //    return status;
        //}



    }

}
