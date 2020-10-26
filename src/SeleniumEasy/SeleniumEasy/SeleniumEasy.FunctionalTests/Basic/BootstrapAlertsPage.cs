using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumEasy.FunctionalTests.BaseClasses;
using System;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class BootstrapAlertsPage : Page
    {
        protected override string pageUrl => "https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html";
        protected override string pageTitle => "Selenium Easy - Bootstrap Alerts Demo for Automation";

        public BootstrapAlertsPage(IWebDriver driver) : base(driver) { }


        #region Elements

        private IWebElement autocloseSuccessButton => this.driver.FindElement(By.Id("autoclosable-btn-success"));
        private By autocloseSuccessAlertSelector => By.ClassName("alert-autocloseable-success");
        private IWebElement autocloseSuccessAlert => this.driver.FindElement(autocloseSuccessAlertSelector);

        private IWebElement normalSuccessButton => this.driver.FindElement(By.Id("normal-btn-success"));
        private IWebElement normalSuccessAlert => this.driver.FindElement(By.ClassName("alert-normal-success"));
        private IWebElement normalSuccessAlertCloseButton => this.normalSuccessAlert.FindElement(By.ClassName("close"));

        #endregion Elements


        #region Interaction

        public void ClickAutocloseSuccessButton()
        {
            this.autocloseSuccessButton.Click();
        }

        public bool AutocloseSuccessAlertIsDisplayed()
        {
            return this.autocloseSuccessAlert.Displayed;
        }

        public bool AutocloseSuccessAlertIsNotDisplayed(TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, timeout);
            return wait.Until(d =>
            {
                var elementList = d.FindElements(this.autocloseSuccessAlertSelector);
                var elementDisplayed = elementList.Count > 0 && elementList[0].Displayed;
                return !elementDisplayed;
            });
        }

        public void ClickNormalSuccessButton()
        {
            this.normalSuccessButton.Click();
        }

        public bool NormalSuccessAlertIsDisplayed()
        {
            return this.normalSuccessAlert.Displayed;
        }

        public void CloseNormalSuccessAlert()
        {
            this.normalSuccessAlertCloseButton.Click();
        }

        #endregion Interaction
    }
}
