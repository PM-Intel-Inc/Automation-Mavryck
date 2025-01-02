using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.XPath;
using AventStack.ExtentReports;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Mavryck_TimeManager.Utils
{
    public class Base : Constants
    {
        public static async Task<bool> WaitForElementVisible(IPage page, string selector)
        {
            try
            {
                // Wait for the element to be loaded
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                // Check if the element is visible
                var elementHandle = await page.WaitForSelectorAsync(selector);
                await Task.Delay(3000);
                return await elementHandle.IsVisibleAsync();
            }
            catch (PlaywrightException)
            {
                return false; // Element is not visible within the timeout
            }
        }

        public static async Task loadURL(IPage page, string url)
        {
            try
            {

                await page.GotoAsync(url);
                Thread.Sleep(10000);
           

            }
            catch (Exception e)
            {
                await page.GotoAsync(url);
            }
            
        }

        public static async Task<bool> WaitForElementVisible(IPage page, string selector, int timeoutMilliseconds)
        {
            try
            {
                // Wait for the element to be loaded
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                page.SetDefaultTimeout(timeoutMilliseconds);

                // Create a task for WaitForSelectorAsync
                var waitForSelectorTask = page.WaitForSelectorAsync(selector);

                // Wait for either the selector to be ready or the timeout
                var completedTask = await Task.WhenAny(waitForSelectorTask, Task.Delay(timeoutMilliseconds));

                // If the selector task completed, check if the element is visible
                if (completedTask == waitForSelectorTask)
                {
                    var elementHandle = await waitForSelectorTask;
                    return await elementHandle.IsVisibleAsync();
                }
                else
                {
                    // Timeout occurred
                    return false;
                }
            }
            catch (PlaywrightException)
            {
                return false; // Element is not visible or not found within the timeout
            }
        }

       



        public void DeleteImagesFromFolder()
        {
            try
            {
                // Get all files with a specific extension (e.g., .png) from the folder
                string[] files = Directory.GetFiles(ScreenshotPath, "*.png");

                // Delete each file
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting images: {ex.Message}");
                // Handle the exception as needed
            }
        }


        public static async Task<string> GetElementBackgroundColorAsync(IPage page, string xpath)
        {
            // Use your method to wait for the element to be present
            await WaitForElementVisible(page, xpath);

            // Execute JavaScript to get the background color
            string backgroundColor = await page.EvaluateAsync<string>(@"
       async function(xpath) {
            var element = document.evaluate(xpath, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
            if (element) {
                var computedStyle = window.getComputedStyle(element);
                
                // If border-color is not available, try outline-color
                var outlineColor = computedStyle.getPropertyValue('outline-color');
                if (outlineColor !== '' && outlineColor !== 'invert') {
                    return outlineColor;
                }
            }
            return null;
        }
        ", xpath);

            return backgroundColor;
        }



        public static async Task ScrollToElement(IPage page, string element)
        {
            var elementHandle = await page.QuerySelectorAsync(element);
            await elementHandle.ScrollIntoViewIfNeededAsync();
            await Task.Delay(2000);
        }
     
    }
}
