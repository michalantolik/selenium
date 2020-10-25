using OpenQA.Selenium;
using SeleniumEasy.FunctionalTests.BaseClasses;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class SimpleFormPage : Page
    {
        protected override string pageUrl => "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
        protected override string pageTitle => "Selenium Easy Demo - Simple Form to Automate using Selenium";

        public SimpleFormPage(IWebDriver driver) : base(driver) { }


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

        #endregion Interaction
    }
}
