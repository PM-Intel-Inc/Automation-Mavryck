using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanNotePlaywrite
{
    internal class PlaywrightConfig
    {
        public static async Task<IPlaywright> ConfigurePlaywrightAndLaunchBrowser()
        {
            // Always create a new instance of Playwright.
            return await Playwright.CreateAsync();
        }

        public static async Task<IBrowser> LaunchChromiumBrowser(IPlaywright playwright, string executablePath, bool headless)
        {
            return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = headless,
                Timeout = 60000,
                Args = new List<string> { "--start-maximized" }
            });
        }

    }
}
