using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumEasy.FunctionalTests.Extensions
{
    public static class IWebDriverExtensions
    {
        #region Extensions methods

        /// <summary>
        /// Checks whether IWebElement exists within the current IWebDriver context using the given mechanism.
        /// </summary>
        /// <param name="driver">Current IWebDriver context</param>
        /// <param name="by">The locating mechanism to use</param>
        /// <returns>True if element exists</returns>
        /// <remarks>Uses default timeout of 500 milliseconds</remarks>
        public static bool HasElement(this IWebDriver driver, By by)
        {
            const int defaultTimeoutMs = 500;
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(defaultTimeoutMs));
            bool hasElement = wait.Until(d => d.FindElements(by)).Count() > 0;

            return hasElement;
        }

        /// <summary>
        /// Check whether alert is currently displayed within the current IWebDriver context
        /// </summary>
        /// <param name="driver">Current IWebDriver context</param>
        /// <returns>True if alert is currently displayed</returns>
        public static bool AlertIsPresent(this IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the window titles of the open browser windows within the current IWebDriver context.
        /// </summary>
        /// <param name="driver">Current IWebDriver context</param>
        /// <returns>Titles of the open windows</returns>
        public static ReadOnlyCollection<string> WindowTitles(this IWebDriver driver)
        {
            string initialHandle = driver.CurrentWindowHandle;

            var windowTitles = new List<string>();
            foreach (var handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
                var title = driver.Title;
                windowTitles.Add(title);
            }

            driver.SwitchTo().Window(initialHandle);

            return new ReadOnlyCollection<string>(windowTitles);
        }

        /// <summary>
        /// Check whether window is currently open within the current IWebDriver context
        /// </summary>
        /// <param name="driver">Current IWebDriver context</param>
        /// <param name="windowTitle">Title of the window to be checked</param>
        /// <returns>True if the window is open</returns>
        /// <remarks>Uses default timeout of 3 seconds</remarks>
        public static bool WindowIsOpen(this IWebDriver driver, string windowTitle)
        {
            const int defaultTimeoutSecs = 3;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(defaultTimeoutSecs));
            try
            {
                wait.Until(d => d.WindowTitles().Any(x => x == windowTitle));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Closes browser window with the given title.
        /// </summary>
        /// <param name="driver">Current IWebDriver context</param>
        /// <param name="windowTitle">Title of the window to be closed</param>
        /// <remarks>Throws <see cref="InvalidOperationException"/> when trying to close the current window </remarks>
        /// <remarks>Throws <see cref="NoSuchWindowException"/> when window is not opened </remarks>
        public static void CloseWindow(this IWebDriver driver, string windowTitle)
        {
            string initialHandle = driver.CurrentWindowHandle;

            if (windowTitle == driver.Title)
            {
                throw new InvalidOperationException($"Trying to close currently open window. Window title: {windowTitle}");
            }
            if (!driver.WindowIsOpen(windowTitle))
            {
                throw new InvalidOperationException($"Trying to close window which is not opened. Window title: {windowTitle}");
            }

            // Switch to the window to be closed
            // ... throw "NoSuchWindowException" in case of trying swtich to non-existing window
            SwitchToWindow(driver, windowTitle);

            // Close target window and switch back to the initial one
            driver.Close();
            driver.SwitchTo().Window(initialHandle);
        }

        #endregion Extensions methods


        #region Private helpers

        private static string SwitchToWindow(IWebDriver driver, string windowTitle)
        {
            foreach (var handle in driver.WindowHandles)
            {
                var title = driver.SwitchTo().Window(handle).Title;
                if (title == windowTitle)
                {
                    return handle;
                }
            }

            throw new NoSuchWindowException($"Window not found. Window title: {windowTitle}");
        }

        #endregion Private helpers
    }
}
