using OpenQA.Selenium;
using SeleniumEasy.FunctionalTests.Extensions;
using System;

namespace SeleniumEasy.FunctionalTests.BaseClasses
{
    public abstract class Page
    {
        protected IWebDriver driver;
        protected abstract string pageUrl { get; }
        protected abstract string pageTitle { get; }

        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo()
        {
            this.driver.Navigate().GoToUrl(this.pageUrl);
            EnsurePageLoaded();
        }

        public void EnsurePageLoaded()
        {
            bool pageLoaded = this.driver.Url == this.pageUrl && this.driver.Title == this.pageTitle;
            if (!pageLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{this.driver.Url}' Page Source: \r\n {this.driver.PageSource}");
            }
        }

        public bool AlertIsPresent()
        {
            return this.driver.AlertIsPresent();
        }

        public IAlert SwitchToAlert()
        {
            return this.driver.SwitchTo().Alert();
        }
    }
}
