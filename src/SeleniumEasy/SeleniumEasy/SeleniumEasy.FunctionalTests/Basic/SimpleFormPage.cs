using OpenQA.Selenium;
using System;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class SimpleFormPage
    {
        private IWebDriver driver;

        private const string PageUrl = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
        private const string PageTitle = "Selenium Easy Demo - Simple Form to Automate using Selenium";

        public SimpleFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        #region Elements

        private IWebElement messageInput => this.driver.FindElement(By.Id("user-message"));
        private IWebElement showMessageButton => this.driver.FindElement(By.XPath("//button[text()='Show Message']"));
        private IWebElement yourMessageText => this.driver.FindElement(By.Id("display"));

        private IWebElement aValueInput => this.driver.FindElement(By.Id("sum1"));
        private IWebElement bValueInput => this.driver.FindElement(By.Id("sum2"));
        private IWebElement getTotalButton => this.driver.FindElement(By.XPath("//button[text()='Get Total']"));
        private IWebElement totalValueText => this.driver.FindElement(By.Id("displayvalue"));

        #endregion Elements


        #region Interaction

        public void NavigateTo()
        {
            this.driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoaded();
        }

        public void SetMessage(string message)
        {
            this.messageInput.SendKeys(message);
        }

        public void ClickShowMessage()
        {
            this.showMessageButton.Click();
        }

        public string GetYourMessageText()
        {
            return this.yourMessageText.Text;
        }

        public void SetValueA(string value)
        {
            this.aValueInput.SendKeys(value);
        }

        public void SetValueB(string value)
        {
            this.bValueInput.SendKeys(value);
        }

        public void ClickGetTotal()
        {
            this.getTotalButton.Click();
        }

        public string GetTotalValueText()
        {
            return this.totalValueText.Text;
        }

        private void EnsurePageLoaded()
        {
            bool pageLoaded = this.driver.Url == PageUrl && this.driver.Title == PageTitle;
            if(!pageLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{this.driver.Url}' Page Source: \r\n {this.driver.PageSource}");
            }
        }

        #endregion Interaction
    }
}
