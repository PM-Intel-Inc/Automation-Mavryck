using System;
using System.Collections;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Mavryck_System.Pages
{
    internal class VivclimaPage_mavryck : Base
    {
        private readonly IPage page;
        private const string TextAlignmentButton = "(//button[@data-tooltip-content='Show/Hide Column'])[1]";
        private const string Gigo_LogicalFlaw = "//button[@data-tooltip-content='Logical Flaw']";
        private const string TextAlignmentButton2 = "(//button[@data-tooltip-content='Show/Hide Column'])[2]";
        private const string IncurredToDateWithCommitments = "//button[text()='Incurred to Date with Commitment']";
        private const string ExitFullScreen = "//button[@data-tooltip-content='Exit Full Screen']";
        private const string AirPolutionLevelGood = "//h2[text()='Air Pollution Level Good ']";
        private const string AirPolutionLevelModerate = "//h2[text()='Air Pollution Level Moderate']";
        private const string UnhealthyforSensitiveGroups = "//h2[text()='Unhealthy for Sensitive Groups']";
        private const string VeryUnhealthy = "//h2[text()='Very Unhealthy']";
        private const string ExitFullScreen2 = "//button[@data-tooltip-content='Full Screen']";
        private const string Version = "//span[text()='V10']";
        private const string AddFile = "//button[text()=' Add File']";
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
        private const string Budget = "//small[text()='Budget']";
        private const string EAC = "//small[text()='EAC']";
        private const string ETC = "//small[text()='ETC']";
        private const string Core = "//span[text()='Core']";
        private const string GridView = "//button[@data-tooltip-content='Overview']";
        private const string KnockOnImpact = "//button[@data-tooltip-content='Knock-on Impact']";
        private const string KnockOnImpact1 = "//button[@data-tooltip-content='Knock on Impact']";
        private const string FullScreen = "//button[@data-tooltip-content='Full Screen']";
        private const string HideUnhideButton = "//button[@data-tooltip-content='Show/Hide Column']";
        private const string DownloadButtonGrid = "//button[@data-tooltip-content='Download']";
        private const string TrendsFeature = "//button[@data-tooltip-content='Trends']";
        private const string CorrelationFeature = "//button[@data-tooltip-content='Correlation']";
        private const string SCurve = "//button[@data-tooltip-content='S-Curve']";
        private const string Scurve = "//button[text()='SCurve']";
        private const string BenchMarkingFeature = "//button[@data-tooltip-content='BenchMarking']";
        private const string CostFlaw = "//button[@data-tooltip-content='Cost Flaw']";
        private const string GanttChart = "//button[@data-tooltip-content='Gantt Chart']";
        private const string Oculus = "//span[text()='Oculus DV']";
        private const string Tooltip = "//div[@role='tooltip']";
        private const string Andon = "//span[text()='Andon']";
        private const string ClimateRisk = "//span[text()='Climate Risk']";
        private const string ClimateHazardTab = "//button[text()='Climate Hazards']";
        private const string RiskMitigationMeasures = "//button[text()='Risk Mitigation Measures']";
        private const string PercentageGreen = "//h2[text()='Percentage Green']";
        private const string CarbonFootprint = "//h2[text()='Carbon Footprint']";
        private const string IndustryAverage = "//h2[text()='P G: Industry Average']";
        private const string CarbonBudget = "//h3[text()='Carbon Budget']";
        private const string CarbonActual = "//h3[text()='Carbon Actual']";
        private const string AirQuality = "//span[text()='Air Quality']";
        private const string PatternRecognition = "//span[text()='Pattern Recognition']";
        private const string Number_Of_DelayEvents = "//button[text()='Number of Delay Events']";
        private const string Diagnostics = "//span[text()='Diagnostics']";
        private const string Staff = "//button[@data-tooltip-content='Staff']";
        private const string AirQualityTooltip = "//button[@data-tooltip-content='Air Quality']";
        private const string ClimateRiskTooltip = "//button[@data-tooltip-content='Table View']";
        private const string OculusDV = "//button[@data-tooltip-content='Oculus DV']";
        private const string ContractAnalysis = "//button[@data-tooltip-content='Contract Analyzer']";
        private const string ReportAnalysis = "//button[@data-tooltip-content='Report Analyzer']";
        private const string Complaince = "//button[@data-tooltip-content='Compliance']";
        private const string Predictions = "//span[text()='Predictions']";
        private const string Costforecast = "//button[@data-tooltip-content='Cost Forecast']";
        private const string Prognosis = "//button[@data-tooltip-content='Prognosis']";
        private const string RecoverySchedule = "//button[@data-tooltip-content='Recovery Schedule']";
        private const string ChangeOrders = "//button[@data-tooltip-content='Change Orders']";
        ArrayList testSteps;
        byte[] screenshotBytes = null;

        ExtentTest Test;

        public VivclimaPage_mavryck(IPage page, ExtentTest test)
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

        public async Task ClickOnStaff()
        {
            await page.ClickAsync(Staff);
        }

        public async Task ClickOnTextAllignmentButton2()
        {
            await page.ClickAsync(TextAlignmentButton2);
        }

        public async Task ClickOnIncurredToDateWithCommitments()
        {
            await page.ClickAsync(IncurredToDateWithCommitments);
        }


        public async Task ClickOnAndon()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Andon);
        }
        public async Task ClickOnClimateRisk()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(ClimateRisk);
        }
        public async Task ClickOnClimateHazardTab()
        {
            await page.ClickAsync(ClimateHazardTab);
        }

        public async Task ClickOnRiskMitigationMeasures()
        {
            await page.ClickAsync(RiskMitigationMeasures);
        }
        public async Task ClickOnAirQuality()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(AirQuality);

        }
        public async Task ClickOnOculusDV()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Oculus);
        }
        public async Task<bool> VerifyPercentageGreen()
        {
            return await WaitForElementVisible(page, PercentageGreen);

        }

        public async Task<bool> VerifyCarbonfootprint()
        {
            return await WaitForElementVisible(page, CarbonFootprint);

        }

        public async Task<bool> VerifyCarbonActual()
        {
            return await WaitForElementVisible(page, CarbonActual);

        }

        public async Task<bool> VerifyCarbonBudget()
        {
            return await WaitForElementVisible(page, CarbonBudget);

        }

        public async Task<bool> VerifyIndustryAverage()
        {
            return await WaitForElementVisible(page, IndustryAverage);

        }

        public async Task<bool> VerifyAirPolutionLevelGood()
        {
            return await WaitForElementVisible(page, AirPolutionLevelGood);

        }
        public async Task<bool> VerifyAirPolutionLevelModerate()
        {
            return await WaitForElementVisible(page, AirPolutionLevelModerate);

        }

        public async Task<bool> VerifyUnhealthyforSensitiveGroups()
        {
            return await WaitForElementVisible(page, UnhealthyforSensitiveGroups);

        }
        public async Task<bool> VerifyVeryUnhealthy()
        {
            return await WaitForElementVisible(page, VeryUnhealthy);

        }



        public async Task<bool> VerifyCarboxEmissionIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Total Carbon Emission']");
            return await WaitForElementVisible(page, "//div[@id='ECWEdiv']", 120000);

        }

        public async Task<bool> VerifyTornadoEmissionComparisonChartIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Tornado Emission Camparison Chart']");
            return await WaitForElementVisible(page, "//div[@id='TECdiv']", 120000);

        }
        public async Task<bool> VerifyTotalEmissionChartIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Total Emission']");
            return await WaitForElementVisible(page, "//div[@id='CLCChartdiv']", 120000);

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
        public async Task ClickOnScurve()
        {
            await page.ClickAsync(Scurve);
        }


        public async Task<bool> VerifyCarboxTaxIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='Emissionchartdiv']", 120000);

        }

        public async Task<bool> VerifySCurveCarboxTaxIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='sCurveTax']", 120000);

        }




        public async Task ClickOnCostForecast()
        {
            await page.ClickAsync(Costforecast);
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

        public async Task SelectAllignment_potentialClaim(string ColumnName, string textAllign)
        {
            await ScrollToElement(page, $"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[3]");
            await page.SelectOptionAsync($"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[3]", textAllign);

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


        public async Task<bool> VerifyCurveGraphIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='barchartdiv']", 120000);

        }



        public async Task VerifyPageTitleWithTooltip_AirQuality()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>Air Quality Icon</b> ***");
            await HoverAirQuality();

            Test.Log(Status.Info, "Verify the <b> Air Quality Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Air Quality", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Air Quality", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

        }
        public async Task VerifyPageTitleWithTooltip_ClimateRisk()
        {
            
            Test.Log(Status.Info, $" *** Hover The  <b>Climate Risk Icon</b> ***");
            await HoverClimateRisk();

            Test.Log(Status.Info, "Verify the <b>Climate Risk Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Climate Risk", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Climate Risk", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

        }

        public async Task VerifyPageTitleWithTooltip_OculusDV()
        {
           

            Test.Log(Status.Info, $" *** Hover The  <b>Oculus Dv Icon</b> ***");
            await HoverOculusDV();

            Test.Log(Status.Info, "Verify the <b> Oculus DV Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Oculus DV", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Oculus DV", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

        }

        public async Task<bool> VerifyFullScreenOfGridIsDisplaying()
        {
            return await WaitForElementVisible(page, ExitFullScreen, 120000);

        }

        public async Task<bool> VerifyFullScreenOfGridIsDisplaying2()
        {
            return await WaitForElementVisible(page, ExitFullScreen2, 120000);

        }

        public async Task<bool> VerifyCorrelationHeatMap()
        {
            return await WaitForElementVisible(page, "//div[@id='heatMapDiv']", 120000);

        }

        public async Task<bool> VerifyCorrelationHeatMap2()
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

        public async Task<ArrayList> VerifyDeepAnalysisReport(int step)
        {
            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> Generative Deep Analysis Title</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//h3[text()='Generative Deep Analysis']", 120000));

            Test.Log(Status.Info, $" *** Verify the <b>Project Summary Details</b>  *** ");

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Total Budget</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Total Budget: ']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Incurred To Date</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Incurred To Date: ']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Estimated Total Cost</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Estimated Total Cost (ETC): ']", 120000));


            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Earned Value</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Earned Value (EAC): ']", 120000));


            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Project Duration</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Project Duration: ']", 120000));


            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Cost Per Day</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Cost Per Day: ']", 120000));

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b>Activity-wise Analysis</b> is displaying"));
            Assert.True(await WaitForElementVisible(page, $"//b[text()='Activity-wise Analysis: ']", 120000));


            return testSteps;
        }

        public async Task<bool> VerifyBudget()
        {
            return await WaitForElementVisible(page, Budget, 120000);

        }
        public async Task<bool> VerifyEAC()
        {
            return await WaitForElementVisible(page, EAC, 120000);

        }
        public async Task<bool> VerifyETC()
        {
            return await WaitForElementVisible(page, ETC, 120000);

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

        public async Task HoverCostFlaw()
        {
            var elementToHover = await page.QuerySelectorAsync(CostFlaw);
            await elementToHover.HoverAsync();
        }



        public async Task HoverDownloadButton()
        {
            var elementToHover = await page.QuerySelectorAsync(DownloadButtonGrid);
            await elementToHover.HoverAsync();
        }

        public async Task HoverAirQuality()
        {
            var elementToHover = await page.QuerySelectorAsync(AirQualityTooltip);
            await elementToHover.HoverAsync();
        }

        public async Task HoverClimateRisk()
        {
            var elementToHover = await page.QuerySelectorAsync(ClimateRiskTooltip);
            await elementToHover.HoverAsync();
        }

        public async Task HoverOculusDV()
        {
            var elementToHover = await page.QuerySelectorAsync(OculusDV);
            await elementToHover.HoverAsync();
        }

        public async Task HoverCompliance()
        {
            var elementToHover = await page.QuerySelectorAsync(Complaince);
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

        public async Task HoversCurveFeature()
        {
            var elementToHover = await page.QuerySelectorAsync(SCurve);
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

        public async Task HoverKnockOnImpact1()
        {
            var elementToHover = await page.QuerySelectorAsync(KnockOnImpact1);
            await elementToHover.HoverAsync();
        }

        public async Task HoverCostForecast()
        {
            var elementToHover = await page.QuerySelectorAsync(Costforecast);
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



        public async Task<bool> VerifyOculusDV()
        {
            return await WaitForElementVisible(page, Oculus, 120000);
        }

        public async Task<bool> VerifyHoverTooltip()
        {
            return await WaitForElementVisible(page, Tooltip, 120000);
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

            testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>S Curve Feature</b>  ***"));
            await HoversCurveFeature();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> S Curve Tooltip</b> is displaying"));
            Assert.True(await VerifyHoverTooltip());

            testSteps.Add(Test.Log(Status.Info, $" *** Hover The  <b>BenchMarking Feature</b>  ***"));
            await HoverBenchMarkingFeature();

            testSteps.Add(Test.Log(Status.Info, $"Step {++step}: Verify the <b> BenchMarking Tooltip</b> is displaying"));
            Assert.True(await VerifyHoverTooltip());

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

        public async Task<bool> VerifyClimateRisk()
        {
            return await WaitForElementVisible(page, ClimateRisk, 120000);
        }
        public async Task<bool> VerifyAirQuality()
        {
            return await WaitForElementVisible(page, AirQuality, 120000);
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

            Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment(columnName, textAllig_right);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": Right</b> ");
            Assert.True(await VerifyTextAlign(textAllig_right, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment(columnName, textAllig_center);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": Center</b> ");
            Assert.True(await VerifyTextAlign(textAllig_center, colIndex));

        }


        public async Task VerifyTextAlignment_potentialClaim(string columnName, string textAllig_left, string textAllig_right, string textAllig_center, string colIndex, int step)
        {
            Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment_potentialClaim(columnName, textAllig_left);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_left, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment_potentialClaim(columnName, textAllig_right);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": Right</b> ");
            Assert.True(await VerifyTextAlign(textAllig_right, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment_potentialClaim(columnName, textAllig_center);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": Center</b> ");
            Assert.True(await VerifyTextAlign(textAllig_center, colIndex));


        }

        public async Task VerifyTextAlignment_andon_1(string columnName, string textAllig_left, string textAllig_right, string textAllig_center, string colIndex, int step)
        {
            Test.Log(Status.Info, $"Step {++step}: Select <b> Left </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment_andon_1(columnName, textAllig_left);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_left, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Right </b> Text Allignment Of  <b>" + columnName + "</b>");
            await SelectAllignment_andon_1(columnName, textAllig_right);

            Test.Log(Status.Info, $"Step {++step}: Verify the Text Allignment For <b>" + columnName + ": LEFT</b> ");
            Assert.True(await VerifyTextAlign(textAllig_right, colIndex));

            Test.Log(Status.Info, $"Step {++step}: Select <b> Center </b> Text Allignment Of  <b>" + columnName + "</b>");
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
    }

}
