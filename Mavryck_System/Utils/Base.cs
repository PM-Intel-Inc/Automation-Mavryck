﻿using Microsoft.Playwright;
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
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using System.Collections;
using System.Net.Mail;
using System.Net;

namespace Mavryck_TimeManager.Utils
{
    public class Base : Constants
    {

        public static ArrayList _testResults = new ArrayList();

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
            catch (Exception)
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

       



        public static void DeleteImagesFromFolder()
        {
            try
            {
                // Get all files with a specific extension (e.g., .png) from the folder
                string[] files = Directory.GetFiles(Constants.ScreenshotPath, "*.png");

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

        public static void SendEmailWithReport()
        {
            try
            {
                
                string fromEmail = "natasha.javed@supersoft.com.pk";
                //string password = "wyqdtzliddoisnis";
                string password = "Supersoft@567";
                string toEmail = "swenatasha@gmail.com";
                string subject = "Automation Test Report";
                string body = "Hi,\n\nPlease find the attached automation test report.\n\nBest Regards,\nQA Team";
                string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                string reportsFolderPath = Path.Combine(projectDirectory, "report");
                string ReportPath = Path.Combine(reportsFolderPath, "index.html");
                MailMessage message = new();
                message.From = new MailAddress(fromEmail);
                message.To.Add(new MailAddress(toEmail));
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = false;

                // Attach the report
                Attachment attachment = new(ReportPath);
                message.Attachments.Add(attachment);

                // Configure SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.hostinger.com",587);
                smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                smtpClient.EnableSsl = true;

                // Send the email
                smtpClient.Send(message);

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
  
}
}