using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Utils;
using Microsoft.Playwright;

namespace Mavryck_System.Pages 
{
    internal class CommonFeaturesPage_mavryck   : Base
    {
        private readonly IPage page;
        private const string TimeManager = "//span[text()='NeuroDynamiq']";
        private const string CostBrain = "//span[text()='Numetra']";
        private const string Vivclima = "//span[contains(text(), 'VivClima')]";
        private const string Abacus = "//span[contains(text(), 'Abacus')]";
        private const string OptimaRes = "//span[contains(text(), 'OptimaRes')]";
        private const string RiskSentinel = "//span[contains(text(), 'RiskSentinel')]";

        private const string OpenEnterpriseDirectory = "//button[text()='Open Enterprise Directory']";

        ExtentTest Test;

        public CommonFeaturesPage_mavryck(IPage page, ExtentTest test)
        {
            this.page = page;
            Test = test;
        }
        public async Task ClickOnTimeManager()
        {
            await page.ClickAsync(TimeManager);
        }

        public async Task ClickOnCostBrain()
        {
            await page.ClickAsync(CostBrain);
        }

        public async Task ClickOnVivclima()
        {
            await page.ClickAsync(Vivclima);
        }

        public async Task ClickOnAbacus()
        {
            await page.ClickAsync(Abacus);
        }
        public async Task ClickOnRiskSentinel()
        {
            await page.ClickAsync(RiskSentinel);
        }
        public async Task ClickOnOptimaRes()
        {
            await page.ClickAsync(OptimaRes);
        }

        public async Task ClickOnOpenEnterpriseDirectory()
        {
            await page.ClickAsync(OpenEnterpriseDirectory);
        }
        public async Task<bool> VerifyProjectNameIsDisplaying()
        {
           return await WaitForElementVisible(page ,$"//span[text()='{projectName}']");
        }

        public async Task SelectAppFromTopRight_Menu(string app)
        {
            await page.ClickAsync("//img[@alt='Apps']");
            await page.ClickAsync($"//p[text()='{app}']");

        }


        public async Task VerifyPageTitleWithTooltip(string actualTitle)
        {


            Test.Log(Status.Info, "Verify the <b> Page Title</b> ");
            byte[] screenshotBytes = await page.ScreenshotAsync();
            var pagetitleText = await GetPageTitleText();
            if (pagetitleText.Equals(actualTitle))
            {
                Test.Log(Status.Info, "Expected Title:  <b> " + pagetitleText + "  </b> **** Actual Title : <b>"+ actualTitle + "</b> ");
                Test.Pass("Verified Grid Tooltip", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title:  <b> " + pagetitleText + "  </b> **** Actual Title : <b>"+ actualTitle +"</b> ");
                Test.Fail("Verified  Grid Tooltip", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
        }

        public async Task<string> GetPageTitleText()
        {
            var element = await page.QuerySelectorAsync("((//div[contains(@class , \"sidebar\")]//following-sibling::div)//div)[7]//li//p");
            return await element.InnerTextAsync();
        }

    }
}
