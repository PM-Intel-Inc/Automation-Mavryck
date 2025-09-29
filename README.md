# Running Playwright Tests in Visual Studio 2022

This guide explains how to set up and execute **Playwright test cases in C#/.NET** using **Visual Studio 2022**.


##  Prerequisites

1. **Visual Studio 2022**

   * Install with the following workloads:

     * **.NET desktop development**
     * **ASP.NET and web development**

2. **.NET SDK 6.0 or later**
   [Download here](https://dotnet.microsoft.com/download)

3. **Playwright for .NET**

   * Add the package via NuGet Package Manager or CLI:

     ```bash
     dotnet add package Microsoft.Playwright
     ```
   * Build the project once:

     ```bash
     dotnet build
     ```
   * Install browsers:

     ```powershell
     pwsh bin/Debug/net6.0/playwright.ps1 install
     ```

     *(Adjust path for your target framework, e.g., `net7.0`.)*

---

##  Running Tests in Visual Studio 2022

1. **Open the Solution**

   * Open your `.sln` file in Visual Studio 2022.

2. **Build the Project**

   * From the top menu:
     **Build → Build Solution** (or press `Ctrl+Shift+B`).

3. **Open the Test Explorer**

   * Navigate to:
     **Test → Test Explorer**
   * The Test Explorer window will display all your Playwright test cases (xUnit, NUnit, or MSTest supported).

4. **Run Tests**

   * In **Test Explorer**, click **Run All Tests**.
   * To run a specific test or class, right-click and select **Run**.

5. **Debug Tests**

   * Set breakpoints in your test code.
   * Right-click a test in **Test Explorer** and select **Debug**.
   * Playwright will launch the browser, and execution will pause at your breakpoints.

Viewing Results
Test results are shown in the Test Explorer panel.

✅ You can now **build, run, and debug Playwright tests** directly inside **Visual Studio 2022**!
