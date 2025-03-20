using AventStack.ExtentReports;
using Microsoft.Playwright;
using Mavryck_TimeManager.Utils;
using System.Threading.Tasks;


namespace Mavryck_System.Pages
{
    internal class DashboardPage_mavryck : Base
    {
        private readonly IPage page;

        private const string TimeManager = "//span[text()='NeuroDynamiq']";
        private const string CostBrain = "//span[text()='CostBrain']";
        private const string Vivclima = "//span[contains(text(), 'VivClima')]";
        private const string OpenEnterpriseDirectory = "//button[text()='Open Enterprise Directory']";



        public DashboardPage_mavryck(IPage page ,ExtentTest test)
        {
            this.page = page;
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



        public async Task ClickOnOpenEnterpriseDirectory()
        {
            await page.ClickAsync(OpenEnterpriseDirectory);
        }


    }
}