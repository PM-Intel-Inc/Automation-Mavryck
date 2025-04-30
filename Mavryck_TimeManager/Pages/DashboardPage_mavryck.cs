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

<<<<<<< Updated upstream:Mavryck_TimeManager/Pages/DashboardPage_mavryck.cs
        private const string TimeManager = "//span[text()='Time Manager']";
        private const string CostBrain = "//span[text()='CostBrain']";
=======
        private const string TimeManager = "//span[text()='NeuroDynamiq']";
        private const string CostBrain = "//span[text()='Numetra']";
        private const string Vivclima = "//span[contains(text(), 'VivClima')]";
        private const string Abacus = "//span[contains(text(), 'Abacus')]";
>>>>>>> Stashed changes:Mavryck_System/Pages/DashboardPage_mavryck.cs
        private const string OpenEnterpriseDirectory = "//button[text()='Open Enterprise Directory']";

        ExtentTest Test;

        public DashboardPage_mavryck(IPage page ,ExtentTest test)
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

<<<<<<< Updated upstream:Mavryck_TimeManager/Pages/DashboardPage_mavryck.cs
=======
        public async Task ClickOnVivclima()
        {
            await page.ClickAsync(Vivclima);
        }

        public async Task ClickOnAbacus()
        {
            await page.ClickAsync(Abacus);
        }




>>>>>>> Stashed changes:Mavryck_System/Pages/DashboardPage_mavryck.cs


        public async Task ClickOnOpenEnterpriseDirectory()
        {
            await page.ClickAsync(OpenEnterpriseDirectory);
        }


    }
}