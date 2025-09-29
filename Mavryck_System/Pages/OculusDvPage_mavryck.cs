using System;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;

namespace  Mavryck_System.Pages
{
    internal class OculusDvPage_mavryck : Base
    {
        private readonly IPage page;
        private const string Schedule_Quality = "//h3[text()='Schedule Quality']";
        private const string ProjectDelayed = "//h3[text()='Project Delayed']";
        private const string StartDate = "//h2[text()='Start Date']";
        private const string Budget = "//h2[text()='Budget (ITD)']";
        private const string Need_Improvements = "//span[text()='Need Improvements']";
        private const string QA_Factor = "//h3[text()='Q Factor']";
        private const string FloatUtitlizationAnalysis = "//h3[text()='Float Utilization Analysis']";
        private const string KnockOnImpact = "//h3[text()='Knock on Impact']";
        private const string Push = "//h3[text()='Push']";
        private const string Pull = "//h3[text()='Pull']";
        private const string ETC = "//h2[text()='Estimated to Complete (ETC) ']";
        private const string ITC = "//h2[text()='Incurred to Date (ITC)']";
        private const string EAC= "//h2[text()='Estimated at Complete (EAC)']";

        
        readonly ExtentTest Test;
        public OculusDvPage_mavryck(IPage page , ExtentTest test)
        {
            this.page = page;
            Test = test;
        }

        public async Task<bool> VerifyScheduleQuality()
        {
            return await WaitForElementVisible(page, Schedule_Quality);

        }

        public async Task<bool> VerifyETC()
        {
            return await WaitForElementVisible(page, ETC);

        }

        public async Task<bool> VerifyEAC()
        {
            return await WaitForElementVisible(page, EAC);

        }

        public async Task<bool> VerifyHeatMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='heatMapDiv']", 120000);

        }

        public async Task<bool> VerifyRealisticETCIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='RealisticETCdiv']", 120000);

        }


        public async Task<bool> VerifyBarChartIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='barchartdiv']", 120000);

        }
        public async Task<bool> VerifyChartNameIsDisplaying(string title)
        {
            await ScrollToElement(page, $"//h3[text()='{title}']");
            return await WaitForElementVisible(page, $"//h3[text()='{title}']", 120000);

        }
        public async Task<bool> VerifyWordMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='Wordcloudchartdiv']", 120000);

        }
        public async Task<bool> VerifyTotalOverRunsIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Task Overruns']");
            return await WaitForElementVisible(page, "//div[@id='tmOdv']", 120000);

        }
        public async Task<bool> VerifyBowWaveIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Bow Wave']");
            return await WaitForElementVisible(page, "//div[@id='bowWaveChart']", 120000);

        }

        public async Task<bool> VerifyBowWaveMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='bowWavediv']", 120000);

        }

        



        public async Task<bool> VerifyTaskCategoriesIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='taskCatChart']", 120000);

        }

        public async Task<bool> VerifyCorrelationHeatmapIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Correlation Heatmap']");

            return await WaitForElementVisible(page, "//div[@id='heatMapDiv']", 120000);

        }

        public async Task<bool> VerifyCriticalActivitiesTrendingMapIsdisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='barchartdiv']", 120000);

        }

        public async Task ClickOnCriticalActivitiesTrendingMapIsdisplaying()
        {
            await page.ClickAsync("//button[text()='Critical Activities Trending']");

        }
        

        public async Task<bool> VerifyITC()
        {
            return await WaitForElementVisible(page, ITC);

        }
        public async Task<bool> VerifyStartDate()
        {
            return await WaitForElementVisible(page, StartDate);

        }

        public async Task<bool> VerifyBudget()
        {
            return await WaitForElementVisible(page, Budget);

        }
        public async Task<bool> VerifyFloatUtilization()
        {
            return await WaitForElementVisible(page, FloatUtitlizationAnalysis);

        }
        public async Task<bool> VerifyNeedImprovements()
        {
            return await WaitForElementVisible(page, Need_Improvements);

        }

        public async Task<bool> VerifyPush()
        {
            return await WaitForElementVisible(page, Push);

        }
        public async Task<bool> VerifyPull()
        {
            return await WaitForElementVisible(page, Pull);

        }

        public async Task<bool> VerifyQAFactor()
        {
            return await WaitForElementVisible(page, QA_Factor);

        }

        public async Task<bool> VerifyProjectDelayed()
        {
            return await WaitForElementVisible(page, ProjectDelayed);

        }

        public async Task<bool> VerifyKnockOnImpact()
        {
            return await WaitForElementVisible(page, KnockOnImpact);

        }




    }



}
