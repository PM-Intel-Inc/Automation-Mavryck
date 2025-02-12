using System;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Mavryck_TimeManager.Pages
{
    internal class OculusDvPage_mavryck : Base
    {
        private readonly IPage page;
        private const string Schedule_Quality = "//h2[text()='Schedule Quality ']";
        private const string ProjectDuration = "//h2[text()='Project Duration']";
        private const string StartDate = "//h2[text()='Start Date']";
        private const string Budget = "//h2[text()='Budget']";
        private const string FinishDate = "//h2[text()='Finish Date']";
        private const string Need_Improvements = "//span[text()='Need Improvements']";
        private const string QA_Factor = "//h2[text()='Q Factor:']";
        private const string Baseline = "//h3[text()='Baseline']";
        private const string Current = "//h3[text()='Current']";
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
            return await WaitForElementVisible(page, "//div[@id='scatterPlotDiv']", 120000);

        }
        public async Task<bool> VerifyBowWaveIsDisplaying()
        {
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
            return await WaitForElementVisible(page, "//div[@id='heatMapDiv']", 120000);

        }

        public async Task<bool> VerifyCriticalActivitiesTrendingMapIsdisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='tfttdiv']", 120000);

        }

        public async Task ClickOnCriticalActivitiesTrendingMapIsdisplaying()
        {
            await page.ClickAsync("//button[text()='Critical Activities Trending']");

        }

        public async Task<bool> VerifyProjectDuration()
        {
            return await WaitForElementVisible(page, ProjectDuration);

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
        public async Task<bool> VerifyFinishDate()
        {
            return await WaitForElementVisible(page, FinishDate);

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

        public async Task<bool> VerifyBaseLine()
        {
            return await WaitForElementVisible(page, Baseline);

        }

        public async Task<bool> VerifyCurrent()
        {
            return await WaitForElementVisible(page, Current);

        }




    }



}
