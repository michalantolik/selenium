using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumEasy.FunctionalTests.Extensions
{
    public static class IWebDriverExtensions
    {
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
    }
}
