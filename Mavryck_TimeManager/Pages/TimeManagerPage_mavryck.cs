using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AventStack.ExtentReports;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Mavryck_TimeManager.Pages
{
    internal class TimeManagerPage_mavryck : Base
    {
        private readonly IPage page;
        private const string TextAlignmentButton = "(//button[@data-tooltip-content='Show/Hide Column'])[1]";
        private const string Gigo_LogicalFlaw = "//button[@data-tooltip-content='Logical Flaw']";
        private const string TextAlignmentButton2 = "(//button[@data-tooltip-content='Show/Hide Column'])[2]";
        private const string ExitFullScreen = "//button[@data-tooltip-content='Exit Full Screen']";
        private const string Version = "//span[text()='V10']";
        private const string AddFile = "//button[text()='Add File']";
        private const string Date = "//div[text()='20 Mar, 2024']";
        private const string AddMember = "//button[@id='addMember']";
        private const string AvailableROV = " //h3[text()='Available ROVs: ']";
        private const string MissingROV = " //h3[text()='Missing ROVs: ']";
        private const string DownloadGridIcon = "//button[@data-tooltip-content='Download']";
        private const string ShowHideGridIcon = "//button[@data-tooltip-content='Show/Hide Column']";
        private const string IndicatorsGridIcon = "//button[@data-tooltip-content='Indicators']";
        private const string FullScreenGridIcon = "//button[@data-tooltip-content='Full Screen']";
        private const string Arrow = "//img[@alt='arrowIcon']";
        private const string Logo = "//img[@alt='sidebar logo']";
        private const string PredictButton2 = "(//span[text()='Click to Predict'])[1]";
        private const string PredictButton3 = "(//span[text()='Click to Predict'])[2]";
        private const string PredictButton1 = "//button[text()='Predict']";


        private const string PrognosisPredictButton = "(//h3[text()='Prognosis']//following-sibling::div//div//button)[1]";
        private const string PrognosisPhaseButton = "(//h3[text()='Prognosis']//following-sibling::div//div//button)[2]";
        private const string YesPredictButton = "(//button[@type=\"button\"])[2]";
        private const string StartDate = "//small[text()='Start Date']";
        private const string Core = "//span[text()='Core']";
        private const string GridView = "//button[@data-tooltip-content='Overview']";
        private const string KnockOnImpact = "//button[@data-tooltip-content='Knock-on Impact']";
        private const string Indicators = "//button[@data-tooltip-content='Indicators']";
        private const string FullScreen = "//button[@data-tooltip-content='Full Screen']";
        private const string HideUnhideButton = "//button[@data-tooltip-content='Show/Hide Column']";
        private const string DownloadButtonGrid = "//button[@data-tooltip-content='Download']";
        private const string TrendsFeature = "//button[@data-tooltip-content='Trends']";
        private const string CorrelationFeature = "//button[@data-tooltip-content='Correlation']";
        private const string AnomaliesFeature = "//button[@data-tooltip-content='Anomalies']";
        private const string BenchMarkingFeature = "//button[@data-tooltip-content='BenchMarking']";
        private const string DurationFlaw = "//button[@data-tooltip-content='Durarion Flaw']";
        private const string LogicalFlaw = "//button[@data-tooltip-content='Logical Flaw']";
        private const string Probabilities = "//button[@data-tooltip-content='Probabilities']";
        private const string GanttChart = "//button[@data-tooltip-content='Gantt Chart']";
        private const string Oculus = "//span[text()='Oculus DV']";
        private const string Tooltip = "//div[@role='tooltip']";
        private const string Andon = "//span[text()='Andon']";
        private const string GIGO = "//span[text()='GIGO']";
        private const string ScenarioModeling = "//span[text()='Scenario Modeling']";
        private const string PatternRecognition = "//span[text()='Pattern Recognition']";
        private const string Number_Of_DelayEvents = "//button[text()='Number of Delay Events']";
        private const string Diagnostics = "//span[text()='Diagnostics']";

        private const string DeepAnalysis = "//button[@data-tooltip-content='Deep Analysis']";
        private const string ContractAnalysis = "//button[@data-tooltip-content='Contract Analyzer']";
        private const string ReportAnalysis = "//button[@data-tooltip-content='Report Analyzer']";
        private const string Complaince = "//button[@data-tooltip-content='Compliance']";
        private const string Predictions = "//span[text()='Predictions']";
        private const string CompletionGrid = "//button[@data-tooltip-content='Completion Grid']";
        private const string Prognosis = "//button[@data-tooltip-content='Prognosis']";
        private const string RecoverySchedule = "//button[@data-tooltip-content='Recovery Schedule']";
        private const string ChangeOrders = "//button[@data-tooltip-content='Change Orders']";
        ArrayList testSteps;

        ExtentTest Test;

        public TimeManagerPage_mavryck(IPage page , ExtentTest test)
        {
            this.page = page;
            testSteps = new ArrayList();
            Test = test;

        }

        public async Task ClickOnTextAllignmentButton()
        {
            await page.ClickAsync(TextAlignmentButton);
        }

        public async Task ClickOnDiagnostics()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Diagnostics);
        }
        public async Task ClickOnDeepAnalysis()
        {
            await page.ClickAsync(DeepAnalysis);
        }

        public async Task ClickOnReportAnalysis()
        {
            await page.ClickAsync(ReportAnalysis);
        }
        public async Task ClickOnContractAnalysis()
        {
            await page.ClickAsync(ContractAnalysis);
        }
        public async Task ClickOnComplaince()
        {
            await page.ClickAsync(Complaince);
        }

        public async Task ClickOnTextAllignmentButton2()
        {
            await page.ClickAsync(TextAlignmentButton2);
        }



        public async Task ClickOnAndon()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Andon);
        }
        public async Task ClickOnGigo()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(GIGO);
        }
        public async Task ClickOnScenarioModeling()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(ScenarioModeling);

        }
        public async Task ClickOnOculusDV()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Oculus);
        }

        public async Task<bool> VerifyRecoveryScheduleMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='deriskGanttChartdiv']", 120000);

        }
        public async Task<bool> VerifyChartNameIsDisplaying(string title)
        {
            await ScrollToElement(page, $"//h3[text()='{title}']");
            return await WaitForElementVisible(page, $"//h3[text()='{title}']", 120000);

        }

        public async Task ClickOnPredictions()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Predictions);
        }

        public async Task ClickOnRecoverySchedule()
        {
            await page.ClickAsync(RecoverySchedule);
        }
        public async Task ClickOnPrognosis()
        {
            await page.ClickAsync(Prognosis);
        }
        public async Task ClickOnPrognosisPredictButton()
        {
            await page.ClickAsync(PrognosisPredictButton);
            await page.ClickAsync("//input[@id='env-1']");
        }

        public async Task ClickOnPrognosisPhaseButton()
        {
            await page.ClickAsync(PrognosisPhaseButton);
            await page.ClickAsync("//input[@id='trainOption-0']");
        }
        public async Task ClickOnNumberOfDelayEvents()
        {
            await page.ClickAsync(Number_Of_DelayEvents);
        }

        public async Task ClickOnPatternRecognition()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(PatternRecognition);
        }

        public async Task ClickOnBenchMarking()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(BenchMarkingFeature);
        }
        public async Task ClickOnCompletionGrid()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(CompletionGrid);
        }

        public async Task ClickOnChangeOrders()
        {
            await page.ClickAsync(ChangeOrders);
        }

        public async Task ClickOnArrow()
        {
            await page.ClickAsync(Arrow);
        }

        public async Task ClickOnGigoLogicalFlaw()
        {
            await page.ClickAsync(Gigo_LogicalFlaw);
        }

        public async Task ClickOnCorrelation()
        {
            await page.ClickAsync(CorrelationFeature);
        }

        public async Task ClickOnAnamolies()
        {
            await page.ClickAsync(AnomaliesFeature);
        }

        public async Task CLickOnPredictButton2()
        {
            await page.ClickAsync(PredictButton2);
        }

        public async Task CLickOnPredictButton3()
        {
            await page.ClickAsync(PredictButton3);
        }

        public async Task CLickOnPredictButton1()
        {
            await page.ClickAsync(PredictButton1);
        }

        public async Task CLickOnYesPredictButton()
        {
            await page.ClickAsync(YesPredictButton);
        }

        public async Task<bool> VerifyPagination()
        {
            int totalCount = 0;
            for (int rowId = 0; rowId <= 49; rowId++)
            {

                await ScrollToElement(page, $"//div[@row-id='{rowId}']");
                var divIndex = await page.QuerySelectorAllAsync($"//div[@row-id='{rowId}']");
                totalCount += divIndex.Count;
            }
            Console.WriteLine(totalCount);

            if (totalCount == 50)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public async Task SelectPagination(string value)
        {
            await page.SelectOptionAsync($"select[class*='border-gray-300']", value);

        }

        public async Task ClickOnResizeIcon()
        {
            await page.ClickAsync(FullScreen);

        }
        public async Task ClickOnResizeIcon1()
        {
            await page.ClickAsync("(//button[@data-tooltip-content='Full Screen'])[2]");

        }


        public async Task SelectAllignment(string ColumnName, string textAllign)
        {

            await ScrollToElement(page, $"//label[text()='{ColumnName}']//following-sibling::div//div//select");
            await page.SelectOptionAsync($"//label[text()='{ColumnName}']//following-sibling::div//div//select", textAllign);
        }
        public async Task SelectAllignment_andon(string ColumnName, string textAllign)
        {
            await ScrollToElement(page, $"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[2]");
            await page.SelectOptionAsync($"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[2]", textAllign);

        }

        public async Task SelectAllignment_andon_1(string ColumnName, string textAllign)
        {
            await ScrollToElement(page, $"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[1]");
            await page.SelectOptionAsync($"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[1]", textAllign);

        }



        public async Task<bool> VerifyTextAlign(string expectedAlignment, string columnIndex)
        {


            var element = await page.QuerySelectorAsync($"div.ag-cell[aria-colindex='{columnIndex}']");
            var textAlign = await page.EvaluateAsync<string>("element => window.getComputedStyle(element).getPropertyValue('text-align')", element);
            if (textAlign != expectedAlignment)
            {
                Console.Write(textAlign, expectedAlignment);
                return true;

            }
            return false;
        }


        public async Task<bool> VerifyBowWaveIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='bowWavediv']", 120000);

        }

        public async Task<bool> VerifyCurveGraphIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='sCurveGraphdiv']", 120000);

        }

        public async Task<bool> VerifyNumberOfDelayEventsGraph()
        {
            return await WaitForElementVisible(page, "//div[@id='scatterPlotDivNoDE']", 120000);

        }

        public async Task<bool> VerifyFullScreenOfGridIsDisplaying()
        {
            return await WaitForElementVisible(page, ExitFullScreen, 120000);

        }

        public async Task<bool> VerifyCorrelationHeatMap()
        {
            return await WaitForElementVisible(page, "//div[@id='heatMapDiv2']", 120000);

        }

        public async Task<bool> VerifyVersion()
        {
            return await WaitForElementVisible(page, Version, 120000);
        }

        public async Task<bool> VerifyDate()
        {
            return await WaitForElementVisible(page, Date, 120000);

        }


        public async Task<bool> VerifyStartDate()
        {
            return await WaitForElementVisible(page, StartDate, 120000);

        }

        public async Task<bool> VerifyCore()
        {
            return await WaitForElementVisible(page, Core, 120000);
        }
        public async Task HoverGridView()
        {
            var elementToHover = await page.QuerySelectorAsync(GridView);
            await elementToHover.HoverAsync();
        }
        public async Task HoverDurationFlaw()
        {
            var elementToHover = await page.QuerySelectorAsync(DurationFlaw);
            await elementToHover.HoverAsync();
        }
        public async Task HoverLogicalFlaw()
        {
            var elementToHover = await page.QuerySelectorAsync(LogicalFlaw);
            await elementToHover.HoverAsync();
        }

        public async Task HoverProbabilites()
        {
            var elementToHover = await page.QuerySelectorAsync(Probabilities);
            await elementToHover.HoverAsync();
        }

        public async Task HoverDownloadButton()
        {
            var elementToHover = await page.QuerySelectorAsync(DownloadButtonGrid);
            await elementToHover.HoverAsync();
        }

        public async Task HoverTrendFeature()
        {
            var elementToHover = await page.QuerySelectorAsync(TrendsFeature);
            await elementToHover.HoverAsync();
        }

        public async Task HoverCorrelationFeature()
        {
            var elementToHover = await page.QuerySelectorAsync(CorrelationFeature);
            await elementToHover.HoverAsync();
        }

        public async Task HoverAnomaliesFeature()
        {
            var elementToHover = await page.QuerySelectorAsync(AnomaliesFeature);
            await elementToHover.HoverAsync();
        }

        public async Task HoverBenchMarkingFeature()
        {
            var elementToHover = await page.QuerySelectorAsync(BenchMarkingFeature);
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

        public async Task HoverGanttChart()
        {
            var elementToHover = await page.QuerySelectorAsync(GanttChart);
            await elementToHover.HoverAsync();
        }

        public async Task HoverKnockOnImpact()
        {
            var elementToHover = await page.QuerySelectorAsync(KnockOnImpact);
            await elementToHover.HoverAsync();
        }

        public async Task HoverCompletionGrid()
        {
            var elementToHover = await page.QuerySelectorAsync(CompletionGrid);
            await elementToHover.HoverAsync();
        }

        public async Task HoverPrognosis()
        {
            var elementToHover = await page.QuerySelectorAsync(Prognosis);
            await elementToHover.HoverAsync();
        }

        public async Task HoverRecoverySchedule()
        {
            var elementToHover = await page.QuerySelectorAsync(RecoverySchedule);
            await elementToHover.HoverAsync();
        }

        public async Task HoverChangeOrders()
        {
            var elementToHover = await page.QuerySelectorAsync(ChangeOrders);
            await elementToHover.HoverAsync();
        }

        public async Task HoverIndicators()
        {
            var elementToHover = await page.QuerySelectorAsync(Indicators);
            await elementToHover.HoverAsync();
        }

        public async Task<bool> VerifyOculusDV()
        {
            return await WaitForElementVisible(page, Oculus, 120000);
        }

        public async Task<bool> VerifyHoverTooltip()
        {
            return await WaitForElementVisible(page, Tooltip, 120000);
        }

        public async Task<ArrayList> Verify_Features_Of_PatternRecognition(int step)
        {
            ArrayList testSteps = new ArrayList();
            testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Trends </b> Feature ***"));
            await HoverTrendFeature();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Trends Tooltip </b> is displaying"));
            Assert.True(await VerifyHoverTooltip());

            testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Correlation Feature</b> ***"));
            await HoverCorrelationFeature();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Correlation Tooltip</b> is displaying"));
            Assert.True(await VerifyHoverTooltip());

            testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>Anomalies Feature</b>  ***"));
            await HoverAnomaliesFeature();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Anomalies Tooltip</b> is displaying"));
            Assert.True(await VerifyHoverTooltip());

            testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>BenchMarking Feature</b>  ***"));
            await HoverBenchMarkingFeature();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> BenchMarking Tooltip</b> is displaying"));
            Assert.True(await VerifyHoverTooltip());

            return testSteps;
        }
        public async Task<bool> VerifyContractAnalysisReport(int step)
        {
            return await WaitForElementVisible(page, $"//h3[text()='Contract Analysis']", 120000);
        }

        public async Task<bool> VerifyReportAnalysisReport(int step)
        {
            return await WaitForElementVisible(page, $"//h3[text()='Report Analysis']", 120000);
        }

        public async Task<ArrayList> VerifyDeepAnalysisReport(int step)
        {
            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Generative Deep Analysis Title</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//h3[text()='Generative Deep Analysis']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project Start Date</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Project Start Date:']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project Finish Date</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Project Finish Date:']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Project Duration</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Total Project Duration :']", 120000));


            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Key Observation Title</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Key Observations']", 120000));


            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Critical Path Analysis</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Critical Path Analysis:']", 120000));


            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project Phases</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Project Phases:']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Duration Analysis</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Duration Analysis: ']", 120000));


            return testSteps;
        }

        public async Task<bool> VerifyAndon()
        {
            return await WaitForElementVisible(page, Andon, 120000);
        }
        public async Task ClickOnExitFullScreen()
        {
            await page.ClickAsync(ExitFullScreen);
        }

        public async Task<bool> VerifyGIGO()
        {
            return await WaitForElementVisible(page, GIGO, 120000);
        }
        public async Task<bool> VerifyScenarioModeling()
        {
            return await WaitForElementVisible(page, ScenarioModeling, 120000);
        }

        public async Task<bool> VerifyProjectLogo()
        {
            return await WaitForElementVisible(page, Logo, 120000);

        }

        public async Task VerifyTextAlignment(string columnName, string textAllig_left, string textAllig_right, string textAllig_center, string colIndex, int step)
        {
            Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment(columnName, textAllig_left);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_left, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment(columnName, textAllig_right);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_right, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            await SelectAllignment(columnName, textAllig_center);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_center, colIndex));

        }

        public async Task VerifyTextAlignment_andon(string columnName, string textAllig_left, string textAllig_right, string textAllig_center, string colIndex, int step)
        {
            Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment_andon(columnName, textAllig_left);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_left, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment_andon(columnName, textAllig_right);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_right, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            await SelectAllignment_andon(columnName, textAllig_center);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_center, colIndex));

        }

        public async Task VerifyTextAlignment_andon_1(string columnName, string textAllig_left, string textAllig_right, string textAllig_center, string colIndex, int step)
        {
            Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment_andon_1(columnName, textAllig_left);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_left, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment_andon_1(columnName, textAllig_right);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_right, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            await SelectAllignment_andon_1(columnName, textAllig_center);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_center, colIndex));

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

        public async Task<bool> VerifyDownload_GridIcon()
        {
            return await WaitForElementVisible(page, DownloadGridIcon, 120000);

        }


        public async Task<bool> VerifyShowHide_GridIcon()
        {
            return await WaitForElementVisible(page, ShowHideGridIcon, 120000);

        }

        public async Task<bool> Verify_FullScreen_GridIcon()
        {
            return await WaitForElementVisible(page, FullScreenGridIcon, 120000);

        }


        public async Task<bool> VerifyIndicators_GridIcon()
        {
            return await WaitForElementVisible(page, IndicatorsGridIcon, 120000);

        }



        public async Task<ArrayList> VerifyDownload_FullScreen_HideUnhide_Hover(int step)
        {
            Test.Log(Status.Info, $" *** Hover The  <b>Download Button</b> Of Grid ***");
            await HoverDownloadButton();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Download Tooltip </b> is displaying"));
            Assert.True(await VerifyHoverTooltip());

            Test.Log(Status.Info, $" *** Hover The  <b>Hide/Unhide Button</b> Of Grid ***");
            await HoverHideUnHideButton();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Hide/UnHide Button Tooltip </b> is displaying"));
            Assert.True(await VerifyHoverTooltip());

            Test.Log(Status.Info, $" *** Hover The  <b>Full Screen</b> Of Grid ***");
            await HoverFullScreenButton();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Full Screen Tooltip</b> is displaying"));
            Assert.True(await VerifyHoverTooltip());

            return testSteps;
        }
    }

}
