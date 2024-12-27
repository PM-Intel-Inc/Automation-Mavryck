using AventStack.ExtentReports;
using Microsoft.Playwright;
using Mavryck_TimeManager.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mavryck_TimeManager.Pages
{
    internal class DashboardPage_mavryck : Base
    {
        private readonly IPage page;

        private const string TimeManager = "//span[text()='Time Manager']";
        private const string OpenEnterpriseDirectory = "//button[text()='Open Enterprise Directory']";


        public DashboardPage_mavryck(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnTimeManager()
        {
            await page.ClickAsync(TimeManager);
        }

        public async Task ClickOnOpenEnterpriseDirectory()
        {
            await page.ClickAsync(OpenEnterpriseDirectory);
        }

    }
}