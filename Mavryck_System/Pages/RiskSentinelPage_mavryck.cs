using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Mavryck_System.Utils;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Mavryck_System.Pages 
{
    internal class RiskSentinelPage_mavryck : Base
    { 
            private readonly IPage page;
            private const string RiskLog = "//button[@data-tooltip-content='Risk Log']";
            private const string RiskMatrix = "//button[@data-tooltip-content='Risk Matrix']";
            private const string Tooltip = "//div[@role='tooltip']";
            private const string FullScreen = "//button[@data-tooltip-content='Full Screen']";
            private const string ExitFullScreen = "//button[@data-tooltip-content='Exit Full Screen']";
            private const string HideUnhideButton = "//button[@data-tooltip-content='Show/Hide Column']";
            private const string DownloadButtonGrid = "//button[@data-tooltip-content='Download']";
            private const string TextAlignmentButton = "(//button[@data-tooltip-content='Show/Hide Column'])[1]";
            private const string TextAlignmentButton2 = "(//button[@data-tooltip-content='Show/Hide Column'])[2]";
            private const string Arrow = "//img[@alt='arrowIcon']";
            private const string Oculus = "//span[text()='Oculus DV']";
            private const string Andon = "//span[text()='Andon']";
            private const string Schedule_Quality = "//h2[text()='Schedule Quality ']";
            private const string ProjectDuration = "//h2[text()='Project Duration']";
            private const string StartDate = "//h2[text()='Start Date']";
            private const string FinishDate = "//h2[text()='Finish Date']";
            private const string DownloadGridIcon = "//button[@data-tooltip-content='Download']";
            private const string Indicators = "//button[@data-tooltip-content='Indicators']";
            private const string ShowHideGridIcon = "//button[@data-tooltip-content='Show/Hide Column']";
            private const string IndicatorsGridIcon = "//button[@data-tooltip-content='Indicators']";
            private const string FullScreenGridIcon = "//button[@data-tooltip-content='Full Screen']";
            private const string GridView = "//button[@data-tooltip-content='Overview']";
            private const string KnockOnImpact = "//button[@data-tooltip-content='Knock-on Impact']";

            ArrayList testSteps;
            byte[] screenshotBytes = null;
            ExtentTest Test;

            public RiskSentinelPage_mavryck(IPage page, ExtentTest test)
            {
                this.page = page;
                testSteps = new ArrayList();
                Test = test;

            }

        public async Task HoverRiskLog()
        {
            var elementToHover = await page.QuerySelectorAsync(RiskLog);
            await elementToHover.HoverAsync();
        }
        public async Task HoveRiskMatrix()
        {
            var elementToHover = await page.QuerySelectorAsync(RiskMatrix);
            await elementToHover.HoverAsync();
        }
        public async Task ClickOnRiskMatrix()
        {
            await page.ClickAsync(RiskMatrix);
        }
        public async Task ClickOnOculusDV()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Oculus);
        }

        public async Task ClickOnAndon()
        {
            await page.ClickAsync(Arrow);
            await page.ClickAsync(Andon);
        }

        public async Task<bool> VerifyHoverTooltip()
        {
            return await WaitForElementVisible(page, Tooltip, 120000);
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
        public async Task<bool> VerifyDownload_GridIcon()
        {
            return await WaitForElementVisible(page, DownloadGridIcon, 120000);

        }
        public async Task SelectAllignment_andon(string ColumnName, string textAllign)
        {
            await ScrollToElement(page, $"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[2]");
            await page.SelectOptionAsync($"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[2]", textAllign);

        }
        public async Task HoverIndicators()
        {
            var elementToHover = await page.QuerySelectorAsync(Indicators);
            await elementToHover.HoverAsync();
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
   
        public async Task HoverKnockOnImpact()
        {
            var elementToHover = await page.QuerySelectorAsync(KnockOnImpact);
            await elementToHover.HoverAsync();
        }
        public async Task ClickOnKnockOnImpact()
        {
            await page.ClickAsync(KnockOnImpact);
        }

        public async Task ClickOnResizeIcon1()
        {
            await page.ClickAsync("(//button[@data-tooltip-content='Full Screen'])[2]");

        }

        public async Task ClickOnExitFullScreen()
        {
            await page.ClickAsync(ExitFullScreen);
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
        public async Task ClickOnTextAllignmentButton()
        {
            await page.ClickAsync(TextAlignmentButton);
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

        public async Task ClickOnResizeIcon()
        {
            await page.ClickAsync(FullScreen);

        }
        public async Task<bool> VerifyFullScreenOfGridIsDisplaying()
        {
            return await WaitForElementVisible(page, ExitFullScreen, 120000);
        }

        public async Task<bool> VerifyContingenciesDrawDownMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='conDrwDwnGraphdiv']", 120000);

        }
        public async Task<bool> VerifyOpenActionsMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='OpenActionsGraph']", 120000);

        }

        public async Task<bool> VerifyQRAMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='QRAGraphDiv']", 120000);

        }
        public async Task<bool> VerifyPhaseMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='CLCChartdiv']", 120000);

        }

        public async Task<bool> VerifyExposureMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='ExposureGraph']", 120000);

        }
        public async Task<bool> VerifyClassificationMapIsDisplaying()
        {
            return await WaitForElementVisible(page, "//div[@id='claOwnerDiv']", 120000);

        }

        public async Task<bool> VerifyScheduleQuality()
        {
            return await WaitForElementVisible(page, Schedule_Quality);

        }
        public async Task<bool> VerifyStartDate()
        {
            return await WaitForElementVisible(page, StartDate);

        }
        public async Task<bool> VerifyProjectDuration()
        {
            return await WaitForElementVisible(page, ProjectDuration);

        }

        public async Task<bool> VerifyFinishDate()
        {
            return await WaitForElementVisible(page, FinishDate);

        }

        public async Task<bool> VerifyChartNameIsDisplaying(string title)
        {
            await ScrollToElement(page, $"//h3[text()='{title}']");
            return await WaitForElementVisible(page, $"//h3[text()='{title}']", 120000);

        }
        public async Task ClickOnTextAllignmentButton2()
        {
            await page.ClickAsync(TextAlignmentButton2);
        }


        public async Task SelectAllignment_andon_1(string ColumnName, string textAllign)
        {
            await ScrollToElement(page, $"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[1]");
            await page.SelectOptionAsync($"(//label[text()='{ColumnName}']//following-sibling::div//div//select)[1]", textAllign);

        }
        public async Task HoverGridView()
        {
            var elementToHover = await page.QuerySelectorAsync(GridView);
            await elementToHover.HoverAsync();
        }


        public async Task VerifyPageTitleWithTooltip_Andon()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>Grid</b> ***");
            await HoverGridView();

            Test.Log(Status.Info, "Verify the <b> Grid Tooltip  With Page Title</b> ");
            byte[] screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title:  <b> " + tooltip + "  </b> **** Actual Title : <b>  " + pagetitleText + "</b> ");
                Test.Pass("Verified Grid Tooltip", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title:  <b> " + tooltip + "  </b> **** Actual Title : <b>  " + pagetitleText + "</b> ");
                Test.Fail("Verified  Grid Tooltip", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            Test.Log(Status.Info, $" *** Hover The  <b>Knock On Impact</b> ***");
            await ClickOnKnockOnImpact();
            await HoverKnockOnImpact();

            Test.Log(Status.Info, "Verify the <b> Knock On Impact Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            tooltip = await GetTootlTipText();
            pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title:  <b> " + tooltip + "  </b> **** Actual Title : <b>  " + pagetitleText + "</b> ");
                Test.Pass("Verified Knock On Impact Tooltip", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title:  <b> " + tooltip + "  </b> **** Actual Title : <b>  " + pagetitleText + "</b> ");
                Test.Fail("Verified Knock On Impact Tooltip", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

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


        public async Task VerifyPageTitleWithTooltip_Core()
        {

            Test.Log(Status.Info, $" *** Hover The  <b>Risk Log Icon</b> ***");
            await HoverRiskLog();

            Test.Log(Status.Info, "Verify the <b> Risk Log Icon Tooltip  With Page Title</b> ");
            screenshotBytes = await page.ScreenshotAsync();
            var tooltip = await GetTootlTipText();
            var pagetitleText = await GetPageTitleText();
            if (tooltip.Equals(pagetitleText))
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Pass("Verified  Risk Log ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }
            else
            {
                Test.Log(Status.Info, "Expected Title: " + tooltip + "  **** Actual Title : " + pagetitleText);
                Test.Fail("Verified  Risk Log", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Convert.ToBase64String(screenshotBytes)).Build());
            }

            Test.Log(Status.Info, $" *** Hover The  <b> Risk Matrix Icon</b> ***");
            await ClickOnRiskMatrix();
            await HoveRiskMatrix();

            Test.Log(Status.Info, "Verify the <b> Risk Matrix Icon Tooltip  With Page Title</b> ");
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


    }
}
