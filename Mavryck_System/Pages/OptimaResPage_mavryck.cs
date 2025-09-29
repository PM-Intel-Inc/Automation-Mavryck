using System;
using System.Collections;
using System.Reactive.Joins;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Mavryck_System.Pages
{
    internal class OptimaResPage_mavryck : Base
    {
        private readonly IPage page;
        private const string GridView = "//button[@data-tooltip-content='Overview']";
        private const string ResourceInput = "//button[@data-tooltip-content='Resource Input']";
        private const string Dashboard = "//button[@data-tooltip-content='Dashboard']";
        private const string Scheduling = "//button[@data-tooltip-content='Scheduling']";
        private const string Workfronts = "//button[@data-tooltip-content='Workfronts']";
        private const string Charts = "//button[@data-tooltip-content='Charts']";
        private const string DataGrids = "//button[@data-tooltip-content='Data Grids']";    
        private const string SummaryHeading = "//button[text()='Summary']";
        private const string ExcavationHeading = "//button[text()='Excavation P6']";
        private const string PilingHeading = "//button[text()='Piling P6']";
        private const string CutAndCapHeading = "//button[text()='Cut & Cap P6']";
        private const string ROP = "//button[@data-tooltip-content='ROP']";
        private const string WaitingResources = "//h2[text()='# of Waiting Resources']//following-sibling::h3";
        private const string WaitingWorkfront = "//h2[text()='# of Waiting WorkFront']//following-sibling::h3";
        private const string ForecastedDate = "//h2[text()='Forecasted Date']//following-sibling::h3";
        private const string TotalSalaryOfResources = "//h2[text()='Total Salary of Resources']//following-sibling::h3";
        private const string Tooltip = "//div[@role='tooltip']";
        private const string FullScreen = "//button[@data-tooltip-content='Full Screen']";
        private const string HideUnhideButton = "//button[@data-tooltip-content='Show/Hide Column']";
        private const string DownloadButtonGrid = "//button[@data-tooltip-content='Download']";
        private const string GanttChart = "//button[@data-tooltip-content='Gantt Chart']";
        private const string ExitFullScreen = "//button[@data-tooltip-content='Exit Full Screen']";
        private const string Anomalies = "//button[@data-tooltip-content='Anomalies']";
        private const string Correlation = "//button[@data-tooltip-content='Correlation']";
        private const string PredictIcon = "//button[@data-tooltip-content='Predict']";
        private const string Trends = "//button[@data-tooltip-content='Trends']";
        private const string Core = "//span[text()='Core']";
        private const string Oculus = "//span[text()='Oculus DV']";
        private const string Resources = "//span[text()='Resources']";
        private const string ProgressTracker = "//span[text()='Progress Tracker']";
        private const string Andon = "//span[text()='Andon']";
        private const string PatternRecognition = "//span[text()='Pattern Recognition']";
        private const string Diagnostics = "//span[text()='Diagnostics']";
        private const string Predictions = "//span[text()='Predictions']";
        private const string Arrow = "//img[@alt='arrowIcon']";
        private const string Equipments = "//input[@id='toggleResEquip']//following-sibling::span";
        private const string TextAlignmentButton = "(//button[@data-tooltip-content='Show/Hide Column'])[1]";
        private const string Excavation = "//button[text()='Excavation']";
        private const string CutAndCap = "//button[text()='Cut and Cap']";
        private const string CriticalActivitiesTrending = "//button[text()='Critical Activities Trending']";


        ArrayList testSteps;
        byte[] screenshotBytes = null;

        ExtentTest Test;

        public OptimaResPage_mavryck(IPage page, ExtentTest test)
        {
            this.page = page;
            testSteps = new ArrayList();
            Test = test;

        }


        public async Task ClickOnProgressTracker()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(ProgressTracker);
        }

        public async Task ClickOnExcavation()
        {
            await page.ClickAsync(Excavation);
        }

        public async Task ClickOnCutandCap()
        {
            await page.ClickAsync(CutAndCap);
        }

        public async Task ClickOnOculusDV()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Oculus);
        }

        public async Task ClickOnResources()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Resources);
        }

        public async Task ClickOnScheduling()
        {
            await page.ClickAsync(Scheduling);
        }
        public async Task ClickOnWorkfronts()
        {
            await page.ClickAsync(Workfronts);
        }

        public async Task ClickOnDashboard()
        {
            await page.ClickAsync(Dashboard);
        }

        public async Task ClickOnCriticalActivitiesTrending()
        {
            await page.ClickAsync(CriticalActivitiesTrending);
        }

        public async Task ClickOnDiagnostics()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Diagnostics);
        }


        public async Task ClickOnPatternRecognition()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(PatternRecognition);
        }
        public async Task ClickOnPredictions()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Predictions);
        }

        public async Task ClickOnAnomalies()
        {
            await page.ClickAsync(Anomalies);
        }

        public async Task ClickOnCorrelation()
        {
            await page.ClickAsync(Correlation);
        }


        public async Task ClickOnAndon()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Andon);
        }

        public async Task HoverGridView()
        {
            var elementToHover = await page.QuerySelectorAsync(GridView);
            await elementToHover.HoverAsync();
        }
        public async Task HoverResourceInput()
        {
            var elementToHover = await page.QuerySelectorAsync(ResourceInput);
            await elementToHover.HoverAsync();
        }
        public async Task HoverDashboard()
        {
            var elementToHover = await page.QuerySelectorAsync(Dashboard);
            await elementToHover.HoverAsync();
        }
        public async Task HoverScheduling()
        {
            var elementToHover = await page.QuerySelectorAsync(Scheduling);
            await elementToHover.HoverAsync();
        }
        public async Task HoverWorkfronts()
        {
            var elementToHover = await page.QuerySelectorAsync(Workfronts);
            await elementToHover.HoverAsync();
        }

        public async Task HoverTrends()
        {
            var elementToHover = await page.QuerySelectorAsync(Trends);
            await elementToHover.HoverAsync();
        }
        public async Task HoverCorrelation()
        {
            var elementToHover = await page.QuerySelectorAsync(Correlation);
            await elementToHover.HoverAsync();
        }

        public async Task HoverPredictIcon()
        {
            var elementToHover = await page.QuerySelectorAsync(PredictIcon);
            await elementToHover.HoverAsync();
        }

        public async Task HoverAnomalies()
        {
            var elementToHover = await page.QuerySelectorAsync(Anomalies);
            await elementToHover.HoverAsync();
        }


        public async Task HoverCharts()
        {
            var elementToHover = await page.QuerySelectorAsync(Charts);
            await elementToHover.HoverAsync();
        }
        public async Task HoverDataGrids()
        {
            var elementToHover = await page.QuerySelectorAsync(DataGrids);
            await elementToHover.HoverAsync();
        }
        public async Task HoverROP()
        {
            var elementToHover = await page.QuerySelectorAsync(ROP);
            await elementToHover.HoverAsync();
        }

        public async Task<bool> VerifySummaryHeading()
        {
            return await WaitForElementVisible(page, SummaryHeading, 120000);
        }
        public async Task<bool> ClickOnExcavationHeading()
        {
            return await WaitForElementVisible(page, ExcavationHeading, 120000);
        }
        public async Task<bool> ClickOnPilingHeading()
        {
            return await WaitForElementVisible(page, PilingHeading, 120000);
        }
        public async Task<bool> ClickOnCutAndCapHeading()
        {
            return await WaitForElementVisible(page, CutAndCapHeading, 120000);
        }

        public async Task<bool> VerifyExcavationHeading()
        {
            return await WaitForElementVisible(page, ExcavationHeading, 120000);
        }
        public async Task<bool> VerifyPilingHeading()
        {
            return await WaitForElementVisible(page, PilingHeading, 120000);
        }

        public async Task<bool> VerifyCutAndCapHeading()
        {
            return await WaitForElementVisible(page, CutAndCapHeading, 120000);
        }


        public async Task ClickOnTextAllignmentButton()
        {
            await page.ClickAsync(TextAlignmentButton);
        }
        public async Task<bool> VerifyHoverTooltip()
        {
            return await WaitForElementVisible(page, Tooltip, 120000);
        }

        public async Task<bool> Verify_Resources_Of_Cost_Performance()
        {
            return await WaitForElementVisible(page, "//div[@id='chartdiv']", 120000);

        }
        public async Task<bool> Verify_Equipment_UsagePerWeek()
        {
            return await WaitForElementVisible(page, "//div[@id='chartdiv']", 120000);

        }

        public async Task<bool> Verify_Workfronts_Map()
        {
            await ScrollToElement(page, "//h3[text()='Work Fronts']");
            return await WaitForElementVisible(page, "//div[@id='conDrwDwnGraphdiv']", 120000);

        }
        public async Task<bool> Verify_No_Of_Equipments_PerTask()
        {
            return await WaitForElementVisible(page, "//div[@id='ENchartdiv']", 120000);

        }
        public async Task<bool> VerifyPillingMap()
        {
            return await WaitForElementVisible(page, "//div[@class='chartDiv']", 120000);

        }

        public async Task<bool> VerifyTaskChart_Map()
        {
            return await WaitForElementVisible(page, "//div[@id='taskchartdiv']", 120000);

        }

        public async Task<bool> VerifyResources_Active_Workload_Map()
        {
            await ScrollToElement(page, "//h3[text()='Resource Active Workload']");
            return await WaitForElementVisible(page, "//div[@id='barchartdiv']", 120000);

        }

        public async Task<bool> VerifyTotalFloat_Index_Map()
        {
            return await WaitForElementVisible(page, "//div[@id='barchartdiv']", 120000);
        }
        public async Task<bool> VerifyPredictionMap()
        {
            return await WaitForElementVisible(page, "//div[@id='ROPchartdiv']", 120000);
        }

        public async Task<bool> VerifySCurveGraph()
        {
            await ScrollToElement(page, "//h3[text()='S Curve Graph']");
            return await WaitForElementVisible(page, "//div[@id='sCurveGraphdiv']", 120000);
        }

        public async Task<bool> VerifyCriticalActivitiesTrendingMap()
        {
            return await WaitForElementVisible(page, "//div[@id='tfttdiv']", 120000);
        }

        public async Task<bool> VerifyNumberOfDelayEventsMap()
        {
            return await WaitForElementVisible(page, "//div[@id='scatterPlotDivNoDE']", 120000);
        }

        public async Task<bool> VerifyCorrelationHeatMap()
        {
            return await WaitForElementVisible(page, "//div[@id='heatMapDiv']", 120000);
        }

        public async Task<bool> VerifyCorrelationHeatMap_2()
        {
            return await WaitForElementVisible(page, "//div[@id='heatMapDiv2']", 120000);
        }


        public async Task<bool> VerifyChartNameIsDisplaying(string title)
        {
            await ScrollToElement(page, $"//h3[text()='{title}']");
            return await WaitForElementVisible(page, $"//h3[text()='{title}']", 120000);

        }



        public async Task<bool> VerifyNo_of_WaitingResources()
        {
            return await WaitForElementVisible(page, WaitingResources, 120000);
        }
        public async Task<bool> VerifyForecastedDate()
        {
            return await WaitForElementVisible(page, ForecastedDate, 120000);
        }
        public async Task<bool> VerifySalaryOfResources()
        {
            return await WaitForElementVisible(page, TotalSalaryOfResources, 120000);
        }


        public async Task<bool> VerifyNo_of_Workfront()
        {
            return await WaitForElementVisible(page, WaitingWorkfront, 120000);
        }





        public async Task VerifyTextAlignment(string columnName, string textAllig_left, string textAllig_right, string textAllig_center, string colIndex, int step)
        {
            Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment(columnName, textAllig_left);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_left, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment(columnName, textAllig_right);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": Right</b> ");
            Assert.True(await VerifyTextAlign(textAllig_right, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment(columnName, textAllig_center);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": Center</b> ");
            Assert.True(await VerifyTextAlign(textAllig_center, colIndex));

        }
        public async Task<bool> VerifyTextAlign(string expectedAlignment, string columnIndex)
        {


            var element = await page.QuerySelectorAsync($"div.ag-cell[aria-colindex='{columnIndex}']");
            var textAlign = await page.EvaluateAsync<string>("element => window.getComputedStyle(element).getPropertyValue('text-align')", element);
            if (textAlign != expectedAlignment)
            {
                return true;

            }
            return false;
        }

        public async Task SelectAllignment(string ColumnName, string textAllign)
        {

            await ScrollToElement(page, $"//label[text()='{ColumnName}']//following-sibling::div//div//select");
            await page.SelectOptionAsync($"//label[text()='{ColumnName}']//following-sibling::div//div//select", textAllign);
        }
        public async Task<ArrayList> VerifyDownload_FullScreen_HideUnhide_Hover()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>Download Button</b> Of Grid ***");
            await HoverDownloadButton();
            screenshotBytes = await page.ScreenshotAsync();
            Assert.True(await VerifyHoverTooltip());
            Test.Pass("Verify the <b>Download Tooltip </b> ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());


            Test.Log(Status.Info, $" *** Hover The  <b>Hide/Unhide Button</b> Of Grid ***");
            await HoverHideUnHideButton();
            screenshotBytes = await page.ScreenshotAsync();
            Assert.True(await VerifyHoverTooltip());
            Test.Pass("Verify the <b>Hide/UnHide Button Tooltip </b>  ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());


            Test.Log(Status.Info, $" *** Hover The  <b>Full Screen</b> Of Grid ***");
            await HoverFullScreenButton();
            screenshotBytes = await page.ScreenshotAsync();
            Assert.True(await VerifyHoverTooltip());
            Test.Pass("Verify the <b>Full Screen Tooltip</b> ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());

            return testSteps;
        }

        public async Task HoverDownloadButton()
        {
            var elementToHover = await page.QuerySelectorAsync(DownloadButtonGrid);
            await elementToHover.HoverAsync();
        }

        public async Task HoverHideUnHideButton()
        {
            var elementToHover = await page.QuerySelectorAsync(HideUnhideButton);
            await elementToHover.HoverAsync();
        }


        public async Task HoverFullScreenButton()
        {
            var elementToHover = await page.QuerySelectorAsync(FullScreen);
            await elementToHover.HoverAsync();
        }


        public async Task ToggleOnEquipments()
        {
            await page.ClickAsync(Equipments);

        }

        public async Task ClickOnDataGrids()
        {
            await page.ClickAsync(DataGrids);


        }

        public async Task ClickOnROP()
        {
            await page.ClickAsync(ROP);
        }

        public async Task ClickOnCore()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Core);
        }

        public async Task VerifyPageTitleWithTooltip_OculusDV()
        {

            Test.Log(Status.Info, $" *** Hover The  <b> Over View Icon</b> ***");
            await HoverGridView();

            Test.Log(Status.Info, "Verify the <b> Over View Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified OverView ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified OverView", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
        }

        public async Task VerifyPageTitleWithTooltip_Resources()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>Resource Input Icon</b> ***");
            await HoverResourceInput();

            Test.Log(Status.Info, "Verify the <b> Resource Input Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Resource Input ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Resource Input", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }


            Test.Log(Status.Info, $" *** Hover The  <b>Dashboard Icon</b> ***");
            await ClickOnDashboard();
            await HoverDashboard();

            Test.Log(Status.Info, "Verify the <b> Dashboard Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Dashboard ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Dashboard", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            Test.Log(Status.Info, $" *** Hover The  <b>Scheduling Icon</b> ***");
            await ClickOnScheduling();
            await HoverScheduling();

            Test.Log(Status.Info, "Verify the <b> Scheduling Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Scheduling ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Scheduling", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            Test.Log(Status.Info, $" *** Hover The  <b>Workfronts Icon</b> ***");
            await ClickOnWorkfronts();
            await HoverWorkfronts();

            Test.Log(Status.Info, "Verify the <b> Workfronts Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Workfronts ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Workfronts", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
        }

        public async Task VerifyPageTitleWithTooltip_Core()
        {

            Test.Log(Status.Info, $" *** Hover The  <b> Over View Icon</b> ***");
            await HoverGridView();

            Test.Log(Status.Info, "Verify the <b> Over View Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified OverView ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified OverView", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            Test.Log(Status.Info, $" *** Hover The  <b> Gantt Chart Icon</b> ***");
            await ClickOnGanttchart();
            await HoverGanttChart();

            Test.Log(Status.Info, "Verify the <b> Gantt Chart Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Gantt Chart ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Gantt Chart", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

        }

        public async Task VerifyPageTitleWithTooltip_ProgressTracker()
        {

            Test.Log(Status.Info, $" *** Hover The  <b> Charts Icon</b> ***");
            await HoverCharts();

            Test.Log(Status.Info, "Verify the <b> Charts Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Charts ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Charts", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            Test.Log(Status.Info, $" *** Hover The  <b> Data Grids Icon</b> ***");
            await ClickOnDataGrids();
            await HoverDataGrids();

            Test.Log(Status.Info, "Verify the <b>Data Grids Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Data Grids ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Data Grids", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            Test.Log(Status.Info, $" *** Hover The  <b> Data Grids Icon</b> ***");
            await ClickOnROP();
            await HoverROP();

            Test.Log(Status.Info, "Verify the <b>ROP Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified ROP ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified ROP", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }


        }

        public async Task<string> GetTootlTipText()
        {
            var element = await page.QuerySelectorAsync(Tooltip);
            return await element.InnerTextAsync();

        }

        public async Task<string> GetPageTitleText()
        {
            var element = await page.QuerySelectorAsync("//div[@class='title-version']//h1");
            return await element.InnerTextAsync();
        }

        public async Task<bool> VerifyGanttChart()
        {
            var element = await page.QuerySelectorAsync("//div[contains(text(), 'Name')]");
            return await element.IsVisibleAsync();
        }

        

        public async Task ClickOnGanttchart()
        {
            await page.ClickAsync(GanttChart);
        }

        public async Task HoverGanttChart()
        {
            var elementToHover = await page.QuerySelectorAsync(GanttChart);
            await elementToHover.HoverAsync();
        }

        public async Task ClickOnResizeIcon()
        {
            await page.ClickAsync(FullScreen);

        }

        public async Task<bool> VerifyFullScreenOfGridIsDisplaying()
        {
            return await WaitForElementVisible(page, ExitFullScreen, 120000);

        }

        public async Task VerifyPageTitleWithTooltip_Andon()
        {

            Test.Log(Status.Info, $" *** Hover The  <b> OverView  Icon</b> ***");
            await HoverGridView();

            Test.Log(Status.Info, "Verify the <b>OverView Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified OverView", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified OverView", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
        }

        public async Task VerifyPageTitleWithTooltip_PatternRecognition()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>Trends</b> ***");
            await HoverTrends();

            Test.Log(Status.Info, "Verify the <b> Trends Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Trends", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Trends", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            Test.Log(Status.Info, $" *** Hover The  <b>Correlation</b> ***");
            await ClickOnCorrelation();
            await HoverCorrelation();

            Test.Log(Status.Info, "Verify the <b> Correlation Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Correlation", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            else
            {

                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Correlation", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            Test.Log(Status.Info, $" *** Hover The  <b>Anomalies</b> ***");
            await ClickOnAnomalies();
            await HoverAnomalies();

            Test.Log(Status.Info, "Verify the <b> Anomalies Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Anomalies", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            else
            {

                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Anomalies", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

           
        }

        public async Task<ArrayList> VerifyDeepAnalysisReport(int step)
        {
            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Generative Deep Analysis Title</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//h3[text()='Generative Deep Analysis']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Equipment Details</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Equipment Details:']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Description</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Description:']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Tasks</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Tasks:']", 120000));


            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Asset Code</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Asset Code:']", 120000));



            return testSteps;
        }


        public async Task VerifyPageTitleWithTooltip_Predictions()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>OverView</b> ***");
            await HoverGridView();

            Test.Log(Status.Info, "Verify the <b> OverView Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified OverView", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified OverView", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
        }



    }


}