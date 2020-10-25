using OpenQA.Selenium;
using SeleniumEasy.FunctionalTests.BaseClasses;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class JavaScriptAlertsPage : Page
    {
        protected override string pageUrl => "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        protected override string pageTitle => "Selenium Easy Demo - Automate All Scenarios";

        public JavaScriptAlertsPage(IWebDriver driver) : base(driver) { }


        #region Elements

        private IWebElement simpleAlertButton => this.driver.FindElement(
            By.XPath(
                "//p[text()='Click the button to display an alert box:']" +
                "/following-sibling::button[text()='Click me!']"
            )
        );

        private IWebElement confirmationAlertButton => this.driver.FindElement(
            By.XPath(
                "//b[text()='Click the button to display an confirm box:']" +
                "/following-sibling::button[text()='Click me!']"
            )
        );
        private IWebElement confirmationAlertStatusParagraph => this.driver.FindElement(By.Id("confirm-demo"));

        private IWebElement promptAlertButton => this.driver.FindElement(
            By.XPath(
                "//b[text()='Click below button for prompt box.']" +
                "/following-sibling::button[text()='Click for Prompt Box']"
            )
        );
        private IWebElement promptAlertStatusParagraph => this.driver.FindElement(By.Id("prompt-demo"));


        #endregion Elements


        #region Interaction

        public void ClickSimpleAlertButton()
        {
            this.simpleAlertButton.Click();
        }

        public void ClickConfirmationAlertButton()
        {
            this.confirmationAlertButton.Click();
        }

        public string GetConfirmationAlertStatus()
        {
            return this.confirmationAlertStatusParagraph.Text;
        }

        public void ClickPromptAlertButton()
        {
            this.promptAlertButton.Click();
        }

        public string GetPromptAlertStatus()
        {
            return this.promptAlertStatusParagraph.Text;
        }

        #endregion Interaction
    }
}
