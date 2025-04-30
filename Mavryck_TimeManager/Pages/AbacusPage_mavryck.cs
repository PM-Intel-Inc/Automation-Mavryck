using System;
using System.Collections;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_TimeManager.Utils;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Mavryck_System.Pages
{
    internal class AbacusPage_mavryck : Base
    {
        private readonly IPage page;
        private const string TextAlignmentButton = "(//button[@data-tooltip-content='Show/Hide Column'])[1]";
        private const string Gigo_LogicalFlaw = "//button[@data-tooltip-content='Logical Flaw']";
        private const string IncurredToDateWithCommitments = "//button[text()='Incurred to Date with Commitment']";
        private const string ExitFullScreen = "//button[@data-tooltip-content='Exit Full Screen']";
        private const string Transfer = "//button[@data-tooltip-content='Transfer']";
        private const string TransferButton = "//button[text()='Transfer']";
        private const string TransferHeader = "//h3[text()='Transfer']";
     
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
        private const string Budget = "//small[text()='Budget']";
        private const string EAC = "//small[text()='EAC']";
        private const string ETC = "//small[text()='ETC']";
        private const string Core = "//span[text()='Core']";
        private const string GridView = "//button[@data-tooltip-content='Overview']"; 
        private const string Setup = "//button[@data-tooltip-content='Setup']";
        private const string Build = "//button[@data-tooltip-content='Build']";
        private const string TableView = "//button[@data-tooltip-content='Table View']";
        private const string CarbonAndMaterials = "//button[@data-tooltip-content='Carbon and Materials']";
        private const string BenchMarking = "//button[@data-tooltip-content='Benchmarking']";
        private const string Cost = "//button[text()='Cost ($)']";
        private const string KnockOnImpact1 = "//button[@data-tooltip-content='Knock on Impact']";
        private const string FullScreen = "//button[@data-tooltip-content='Full Screen']";
        private const string InformationButton = "//button[@data-tooltip-content='Information']";
        private const string HideUnhideButton = "//button[@data-tooltip-content='Show/Hide Column']";
        private const string DownloadButtonGrid = "//button[@data-tooltip-content='Download']";
        private const string TrendsFeature = "//button[@data-tooltip-content='Trends']";
        private const string Anomalies = "//button[@data-tooltip-content='Anomalies']";
        private const string RecommendationsFeature = "//button[@data-tooltip-content='Recommendation']";
        private const string CorrelationFeature = "//button[@data-tooltip-content='Correlation']";
        private const string SCurve = "//button[@data-tooltip-content='S-Curve']";
        private const string Scurve = "//button[text()='SCurve']";
        private const string CostFlaw = "//button[@data-tooltip-content='Cost Flaw']";
        private const string GanttChart = "//button[@data-tooltip-content='ganttchart']";
        private const string Oculus = "//span[text()='Oculus DV']";
        private const string Tooltip = "//div[@role='tooltip']";
        private const string Andon = "//span[text()='Andon']";
        private const string ClimateRisk = "//span[text()='Climate Risk']";
        private const string Probabilities = "//button[@data-tooltip-content='Probabilities']";
        private const string CompletionGrid = "//button[@data-tooltip-content='Completion Grid']";
        private const string ClimateHazardTab = "//button[text()='Climate Hazards']";
        private const string RiskMitigationMeasures = "//button[text()='Risk Mitigation Measures']";
        private const string EstimateQuality = "//h2[text()='Estimate Quality']";
        private const string EstimateQuality1 = "//h2[text()='Estimate Quality ']";
        private const string Class = "//h2[text()='Class']";
        private const string Margin = "//h2[contains(text(), 'Margin')]";
        private const string FinishDate = "//h2[text()='Finish Date']";
        private const string Regions = "//p[text()='Regions:']//following-sibling::div";
        private const string PatternRecognition = "//span[text()='Pattern Recognition']";
        private const string Number_Of_DelayEvents = "//button[text()='Number of Delay Events']";
        private const string Diagnostics = "//span[text()='Diagnostics']";
        private const string Staff = "//button[@data-tooltip-content='Staff']";
        private const string AirQualityTooltip = "//button[@data-tooltip-content='Air Quality']";
        private const string ClimateRiskTooltip = "//button[@data-tooltip-content='Table View']";
        private const string OculusDV = "//button[@data-tooltip-content='Overview']";
        private const string ContractAnalysis = "//button[@data-tooltip-content='Contract Analyzer']";
        private const string ReportAnalysis = "//button[@data-tooltip-content='Report Analyzer']";
        private const string Complaince = "//button[@data-tooltip-content='Compliance']";
        private const string Predictions = "//span[text()='Predictions']";
        private const string BuildYourBid = "//span[text()='Build your Bid']";
        private const string Costforecast = "//button[@data-tooltip-content='Cost Forecast']";
        private const string Prognosis = "//button[@data-tooltip-content='Prognosis']";
        private const string RecoverySchedule = "//button[@data-tooltip-content='Recovery Schedule']";
        private const string ChangeOrders = "//button[@data-tooltip-content='Change Orders']";
        
        ArrayList testSteps;
        byte[] screenshotBytes = null;

        ExtentTest Test;

        public AbacusPage_mavryck(IPage page, ExtentTest test)
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

        public async Task ClickOnBenchmarking()
        {
            await page.ClickAsync(BenchMarking);
        }

        public async Task ClickOnCost()
        {
            await page.ClickAsync(Cost);
        }
        public async Task ClickOnGanttchart()
        {
            await page.ClickAsync(GanttChart);
        }

        public async Task SelectRegion(String value)
        {
            await page.ClickAsync(Regions);
            var region=await page.QuerySelectorAsync($"//li[text()='{value}']");
            await region.ClickAsync();            
        }

      
        public async Task HoverCompletionGrid()
        {
            var elementToHover = await page.QuerySelectorAsync(CompletionGrid);
            await elementToHover.HoverAsync();
        }

        public async Task<bool> VerifyPrognosisGrid()
        {
            return await WaitForElementVisible(page, "//div[@role='presentation']", 120000);

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
        
        public async Task ClickOnOculusDV()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Oculus);
        }
        public async Task<bool> VerifyEstimateQuality()
        {
            return await WaitForElementVisible(page, EstimateQuality);

        }

        public async Task<bool> VerifyEstimateQuality1()
        {
            return await WaitForElementVisible(page, EstimateQuality1);

        }

        public async Task<bool> VerifyClass()
        {
            return await WaitForElementVisible(page, Class);

        }

        public async Task ClickOnCompletionGrid()
        {
            await page.ClickAsync(CompletionGrid);
        }

        public async Task HoverProbabilites()
        {
            var elementToHover = await page.QuerySelectorAsync(Probabilities);
            await elementToHover.HoverAsync();
        }

        public async Task SelectTransferProject()
        {
            await page.ClickAsync("//div[text()='Select Project']//following-sibling::div");
            await page.ClickAsync("//div[text()='Andarko Piling Project']");

        }
        public async Task SelectTransferVersion()
        {
            await page.ClickAsync("//div[text()='Select Version']//following-sibling::div");
            await page.ClickAsync("//div[text()='Baselin']");

        }

        public async Task ClickOnTransferButton()
        {
            await page.ClickAsync(TransferButton);

        }


        public async Task<bool> VerifyMargin()
        {
            return await WaitForElementVisible(page, Margin);

        }

        public async Task<bool> VerifyFinishDate()
        {
            return await WaitForElementVisible(page, FinishDate);

        }
        public async Task<bool> VerifyRegions()
        {
            return await WaitForElementVisible(page, Regions);

        }

        public async Task SelectDate()
        {
            await page.FillAsync("input[type='date']", "2025-04-22");

        }




        public async Task<bool> VerifyCarboxEmissionIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Total Carbon Emission']");
            return await WaitForElementVisible(page, "//div[@id='ECWEdiv']", 120000);

        }

        public async Task<bool> VerifyTornadoEmissionComparisonChartIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Tornado Emission Comparison Chart']");
            return await WaitForElementVisible(page, "//div[@id='TECdiv']", 120000);

        }

        public async Task<bool> VerifyTotal_Predicted_Carbon_TaxIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='ECWEChart']", 120000);

        }
        public async Task<bool> VerifyTotalEmissionChartIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Total Emission']");
            return await WaitForElementVisible(page, "//div[@id='CLCChartdiv']", 120000);

        }

        public async Task<bool> VerifyEmissionActivityFullFlowChartIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Emission Activity Full Flow']");
            return await WaitForElementVisible(page, "//div[contains(@class, 'EAFFinrDiv')]", 120000);

        }

        public async Task<bool> VerifyGraph1IsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Graph 1']");
            return await WaitForElementVisible(page, "//div[contains(@class, 'Linechartdiv')]", 120000);

        }

        public async Task<bool> VerifyWordCloudIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='Wordcloudchartdiv']", 120000);

        }

        public async Task<bool> VerifyFrequencyDistributionOfCarboxTaxIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Frequency Distribution of Carbon Tax']");
            return await WaitForElementVisible(page, "//div[@id='barchartdiv1']", 120000);

        }

        public async Task<bool> VerifyFrequencyDistributionOfCarbox_Emission_IsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Frequency Distribution of Carbon Emission']");
            return await WaitForElementVisible(page, "//div[@id='barchartdiv2']", 120000);

        }

        public async Task<bool> VerifyAnomalies_In_Carbon_And_Materials_IsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='Anomalieschartdiv']", 120000);

        }

        
        public async Task<bool> VerifyAnomaliesInCarbonIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Anomalies in Carbon and Materials']");
            return await WaitForElementVisible(page, "//div[@id= 'Anomalieschartdiv']", 120000);

        }

        public async Task<bool> VerifyGraph2IsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Graph 2']");
            return await WaitForElementVisible(page, "//div[contains(@class, 'LCdiv')]", 120000);

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
        public async Task ClickOnBuildYourBid()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(BuildYourBid);
        }

        public async Task ClickOnRecoverySchedule()
        {
            await page.ClickAsync(RecoverySchedule);
        }
        public async Task ClickOnPrognosis()
        {
            await page.ClickAsync(Prognosis);
        }

        public async Task ClickOnRecommendations()
        {
            await page.ClickAsync(RecommendationsFeature);
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

        public async Task ClickOnScurve()
        {
            await page.ClickAsync(Scurve);
        }


        public async Task<bool> VerifyContingenciesMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='taskCatChart']", 120000);

        }

        public async Task<bool> VerifyCostPerMileMapIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Cost Per Pile']");
            return await WaitForElementVisible(page, "//div[@id='costPerData']", 120000);

        }

        public async Task<bool> VerifyMaterialCostPerMileMapIsDisplaying()
        {
            await ScrollToElement(page, "//h3[text()='Material Cost Per Pile']");
            return await WaitForElementVisible(page, "//div[@id='materialCost']", 120000);

        }

        public async Task<bool> VerifyLabourCostPerHourMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='labourCost']", 120000);

        }

        public async Task<bool> VerifyEquipmentRentalCostMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='equipmentCost']", 120000);

        }

        public async Task<bool> VerifyTransferSidePanelIsOpened()
        {
            return await WaitForElementVisible(page, TransferHeader, 120000);

        }


        public async Task<bool> VerifyClassEstimate()
        {
            return await WaitForElementVisible(page, "//div[@id='barchartdiv']", 120000);

        }
        public async Task<bool> VerifyClassAnomalies()
        {
            return await WaitForElementVisible(page, "//div[@id='scatterPlotDiv']", 120000);

            
        }
        public async Task<bool> VerifyClassAnomalies_NumberOfDelayEvents()
        {
            return await WaitForElementVisible(page, "//div[@id='scatterPlotDivNoDE']", 120000);
        }

        public async Task<bool> VerifyCostVarianceOverTime()
        {
            return await WaitForElementVisible(page, "//div[@id='PolynomialDiv']", 120000);
        }
        public async Task<bool> VerifyBowWaveMap()
        {
            return await WaitForElementVisible(page, "//div[@id='bowWavediv']", 120000);
        }



        public async Task<bool> VerifyScheduleVarianceOverTime()
        {
            return await WaitForElementVisible(page, "//div[@id='PolynomialDiv1']", 120000);
        }

        public async Task<bool> VerifyCostOverrunPredictions()
        {
            await ScrollToElement(page, "//h3[text()='Cost Overrun Predictions']");
            return await WaitForElementVisible(page, "//div[@id='PolynomialDiv5']", 120000);
        }
        public async Task<bool> VerifyForecastAccuracy()
        {
            await ScrollToElement(page, "//h3[text()='Forecast Accuracy']");
            return await WaitForElementVisible(page, "//div[@id='ForecastAccuracyDiv']", 120000);
        }

        public async Task<bool> VerifyLabourResourceConstraints()
        {
            await ScrollToElement(page, "//h3[text()='Labor Resource Constraints']");
            return await WaitForElementVisible(page, "//div[@id='LaborVarianceDiv']", 120000);
        }


        public async Task<bool> VerifyMaterialResourceConstraints()
        {
            await ScrollToElement(page, "//h3[text()='Material Resource Constraints']");
            return await WaitForElementVisible(page, "//div[@id='PolynomialDiv4']", 120000);
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

        public async Task ClickOnTransfer()
        {
            await page.ClickAsync(Transfer);
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
        public async Task ClickOnInformaitonIcon()
        {
            await page.ClickAsync(InformationButton);

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


        public async Task<bool> VerifyCoreTitle()
        {
           return  await WaitForElementVisible(page, "//li[text()='Core']", 12000);
        }

        public async Task<bool> VerifyLaborGridHeader()
        {
            string[] content = { "Labor", "Equipments", "Crews", "Materials", "Tasks" };
            for (int i = 0; i < content.Length; i++)
            {
                Test.Log(Status.Info, $"Verify the <b> {content[i]} </b> is displaying");
                return await WaitForElementVisible(page, $"//button[text()='{content[i]}']", 12000);
            }
            return false;
        }

        public async Task<bool> VerifyBuildGridHeader()
        {
            string[] content = { "Pay Items", "Change Orders", "Bid Pricing", "Price Distribution"};
            for (int i = 0; i < content.Length; i++)
            {
                Test.Log(Status.Info, $"Verify the <b> {content[i]} </b> is displaying");
                return await WaitForElementVisible(page, $"//button[text()='{content[i]}']", 12000);
            }
            return false;
        }

        public async Task VerifyPageTitleWithTooltip_BuildYourBid()
        {

            Test.Log(Status.Info, $" *** Hover The  <b> Setup Icon</b> ***");
            await HoverSetup();

            Test.Log(Status.Info, "Verify the <b> Setup Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Setup ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Setup", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            Test.Log(Status.Info, $" *** Hover The  <b> Build Icon</b> ***");
            await ClickOnBuild();
            await HoverBuild();

            Test.Log(Status.Info, "Verify the <b> Build Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Build ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Build", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
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
           
            Test.Log(Status.Info, $" *** Hover The  <b> Bench Marking Icon</b> ***");
            await ClickOnBenchmarking();
            await HoverBanchMarking();
            
            Test.Log(Status.Info, "Verify the <b> Bench Marking Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Bench Marking ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Bench Marking", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
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

        public async Task VerifyPageTitleWithTooltip_Predictions()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>Probabilities Feature Icon</b> ***");
            await HoverProbabilites();

            Test.Log(Status.Info, "Verify the <b> Probabilities Feature Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Probabilities Feature", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Probabilities Feature", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            Test.Log(Status.Info, $" *** Hover The  <b>Completion Grid Feature Icon</b> ***");
            await ClickOnCompletionGrid();
            await HoverCompletionGrid();
           

            Test.Log(Status.Info, "Verify the <b> Completion Grid Feature Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Completion Grid Feature", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Completion Grid Feature", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            Test.Log(Status.Info, $" *** Hover The  <b>Prognosis Feature Icon</b> ***");
            await ClickOnPrognosis();
            await HoverPrognosis();

            Test.Log(Status.Info, "Verify the <b>Prognosis  Feature Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified  Prognosis Feature", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Prognosis Feature", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
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

        public async Task VerifyPageTitleWithTooltip_PatternRecognition()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>Trends Icon</b> ***");
            await HoverTrendFeature();

            Test.Log(Status.Info, "Verify the <b>Trends Icon Tooltip  With Page Title</b> ");
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
            Test.Log(Status.Info, $" *** Hover The  <b>Anomalies Icon</b> ***");
            await ClickOnAnomalies();
            await HoverAnomaliesFeature();

            Test.Log(Status.Info, "Verify the <b>Anomalies Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified Anomalies", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified Anomalies", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }


        }

        public async Task VerifyPageTitleWithTooltip_Andon()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>Overview Icon</b> ***");
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

        public async Task VerifyPageTitleWithTooltip_OculusDV()
        {
           

            Test.Log(Status.Info, $" *** Hover The  <b> OverView Icon</b> ***");
            await HoverGridView();

            Test.Log(Status.Info, "Verify the <b> OverView Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified  OverView" ,  MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified OverView", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
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

        public async Task HoverSetup()
        {
            var elementToHover = await page.QuerySelectorAsync(Setup);
            await elementToHover.HoverAsync();
        }
        public async Task HoverBuild()
        {
            var elementToHover = await page.QuerySelectorAsync(Build);
            await elementToHover.HoverAsync();
        }

        public async Task ClickOnBuild()
        {
            await page.ClickAsync(Build);

        }


        public async Task HoverTableView()
        {
            var elementToHover = await page.QuerySelectorAsync(TableView);
            await elementToHover.HoverAsync();
        }




        public async Task HoverCarbonAndMaterials()
        {
            var elementToHover = await page.QuerySelectorAsync(CarbonAndMaterials);
            await elementToHover.HoverAsync();
        }


        public async Task ClickOnCarbonAndMaterials()
        {
            await page.ClickAsync(CarbonAndMaterials);


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
        public async Task HoverAirQualityFeature()
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

        public async Task HoverAnomaliesFeature()
        {
            var elementToHover = await page.QuerySelectorAsync(Anomalies);
            await elementToHover.HoverAsync();
        }

        public async Task ClickOnAnomalies()
        {
            await page.ClickAsync(Anomalies);
        }

        public async Task HoverRecommendationsFeature()
        {
            var elementToHover = await page.QuerySelectorAsync(RecommendationsFeature);
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
        public async Task HoverInformationButton()
        {
            var elementToHover = await page.QuerySelectorAsync(InformationButton);
            await elementToHover.HoverAsync();
        }

        public async Task HoverGanttChart()
        {
            var elementToHover = await page.QuerySelectorAsync(GanttChart);
            await elementToHover.HoverAsync();
        }

        public async Task HoverBanchMarking()
        {
            var elementToHover = await page.QuerySelectorAsync(BenchMarking);
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
