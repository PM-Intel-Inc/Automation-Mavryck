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
        public async Task<bool> WaitForElementVisible(IPage page, string selector)
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

        public async Task loadURL(IPage page, string url)
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

        public async Task<bool> WaitForElementVisible(IPage page, string selector, int timeoutMilliseconds)
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


        public async Task<string> GetElementBackgroundColorAsync(IPage page, string xpath)
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

        public string GetRandomLastName(int length)
        {
            string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
            Random random = new Random();
            int randomIndex = random.Next(lastNames.Length);
            string randomLastName = lastNames[randomIndex];

            if (randomLastName.Length > length)
            {
                // Trim the last name to the desired length
                randomLastName = randomLastName.Substring(0, length);
            }

            return randomLastName;
        }

        public static string GenerateRandomSSN()
        {
            Random rand = new Random();

            // Randomly generate each part of the SSN
            int part1 = rand.Next(100, 1000);  // 3 digits
            int part2 = rand.Next(10, 100);    // 2 digits
            int part3 = rand.Next(1000, 10000); // 4 digits

            // Format the SSN as "###-##-####"
            return $"{part1:D3}-{part2:D2}-{part3:D4}";
        }

        public async Task ScrollToElement(IPage page, string element)
        {
            var elementHandle = await page.QuerySelectorAsync(element);
            await elementHandle.ScrollIntoViewIfNeededAsync();
            await Task.Delay(2000);
        }

        public async Task ScrollToElementThroughJS(IPage page, string element)
        {
            await page.EvalOnSelectorAsync(element, "element => element.scrollIntoView()");
            await Task.Delay(2000);
        }

        public async Task<bool> IsButtonDisabled(IPage page, string xpath)
        {
            var buttonElement = await page.QuerySelectorAsync(xpath);

            if (buttonElement != null)
            {
                var isDisabled = await buttonElement.EvaluateAsync<bool>("el => el.classList.contains('rz-state-disabled')");
                return isDisabled;
            }
            else
            {
                return false; // Button not found
            }
        }

        // Custom method to get the text content of an element
        public async Task<string> GetElementTextContent(IPage page, string selector)
        {
            var element = await page.QuerySelectorAsync(selector);
            var textContent = await element.InnerTextAsync();
            return textContent;
        }

        public async Task<string> ExtractPageNumberAsync(string inputString)
        {
            string pattern = @"Page (\d+) of (\d+)";
            Match match = Regex.Match(inputString, pattern);

            if (match.Success && match.Groups.Count >= 2)
            {
                return await Task.FromResult(match.Groups[1].Value);
            }
            else
            {
                return null;
            }
        }

        public string GetRandomEmailAddress()
        {   
            string emailPrefix = "abc";
            string domain = "gmail.com";

            // Generate a random number
            Random random = new Random();
            int randomNumber = random.Next(100, 1000); // Generates a random number between 100 and 999

            // Combine the prefix, random number, and domain to form the email
            string email = $"{emailPrefix}+{randomNumber}@{domain}";
            return email;
        }

        public async Task VerifyEachParticipantsRow(IPage page ,Dictionary<string, string> participants)
        {
            // Find all rows in the table
            var rows = await page.QuerySelectorAllAsync("//table//tbody//tr");

            foreach (var participant in participants)
            {
                string participantKey = participant.Key;
                string expectedValue = participant.Value;
                bool matchFound = false;

                // Loop through each row to find a match for the current participant
                for (int rowIndex = 1; rowIndex <= rows.Count; rowIndex++)
                {
                    try
                    {
                        // Construct XPath for the current row and cell
                        string xpath = $"//table//tbody//tr[{rowIndex}]//td[2]//span//a";
                        var elementHandle = await page.QuerySelectorAsync(xpath);

                        if (elementHandle != null)
                        {
                            // Extract the text content
                            string extractedContent = await elementHandle.InnerTextAsync();
                            string finalParticipant = extractedContent.Split(' ').FirstOrDefault()?.Trim() ?? string.Empty;

                            // Check if the extracted content matches the current participant
                            if (finalParticipant == expectedValue)
                            {
                                Test.Log(Status.Pass, $"Match found for {participantKey} in row {rowIndex}: {finalParticipant}");
                                matchFound = true;
                                break; // Stop checking other rows for this participant
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Test.Log(Status.Error, $"Error processing row {rowIndex} for {participantKey}: {ex.Message}");
                    }
                }

                // Log if no match was found for the participant in any row
                if (!matchFound)
                {
                    Test.Log(Status.Pass, $"No match found for {participantKey} with value {expectedValue} in any row.");
                }
            }
        }


        public async Task VerifyEachParticipantsRow_AddParticipant(IPage page ,Dictionary<string, string> participants)
        { // Find all rows in the table
            var rows = await page.QuerySelectorAllAsync("(//table//tbody)[3]//tr");

            foreach (var participant in participants)
            {
                string participantKey = participant.Key;
                string expectedValue = participant.Value;
                bool matchFound = false;

                // Loop through each row to find a match for the current participant
                for (int rowIndex = 1; rowIndex <= rows.Count; rowIndex++)
                {
                    try
                    {
                        // Construct XPath for the current row and cell
                        string xpath = $"(//table//tbody//tr[{rowIndex}]//td[3]//span)[2]";
                        var elementHandle = await page.QuerySelectorAsync(xpath);

                        if (elementHandle != null)
                        {
                            // Extract the text content
                            string extractedContent = await elementHandle.InnerTextAsync();
                            string finalParticipant = extractedContent.Split(' ').FirstOrDefault()?.Trim() ?? string.Empty;

                            // Check if the extracted content matches the current participant
                            if (finalParticipant == expectedValue)
                            {
                                Test.Log(Status.Pass, $"Match found for {participantKey} in row {rowIndex}: {finalParticipant}");
                                matchFound = true;
                                break; // Stop checking other rows for this participant
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Test.Log(Status.Error, $"Error processing row {rowIndex} for {participantKey}: {ex.Message}");
                    }
                }

                // Log if no match was found for the participant in any row
                if (!matchFound)
                {
                    Test.Log(Status.Fail, $"No match found for {participantKey} with value {expectedValue} in any row.");
                }
            }


        }
    }
}
