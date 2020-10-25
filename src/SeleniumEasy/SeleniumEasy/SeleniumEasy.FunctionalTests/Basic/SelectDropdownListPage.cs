using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumEasy.FunctionalTests.BaseClasses;
using System;
using System.Linq;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class SelectDropdownListPage : Page
    {
        protected override string pageUrl => "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        protected override string pageTitle => "Selenium Easy Demo - Automate All Scenarios";

        public SelectDropdownListPage(IWebDriver driver) : base(driver) { }


        #region Elements

        private IWebElement dayDropdown => this.driver.FindElement(By.Id("select-demo"));
        private IWebElement dayStatusParagraph => this.driver.FindElement(By.ClassName("selected-value"));

        private IWebElement stateMultiSelect => this.driver.FindElement(By.Id("multi-select"));
        private IWebElement firstSelectedButton => this.driver.FindElement(By.Id("printMe"));
        private IWebElement getAllSelectedButton => this.driver.FindElement(By.Id("printAll"));
        private IWebElement stateStatusParagraph => this.driver.FindElement(By.ClassName("getall-selected"));

        #endregion Elements


        #region Interaction

        public string[] GetDays()
        {
            var daySelect = new SelectElement(this.dayDropdown);
            var days = daySelect.Options
                .Where(x => x.Text != "Please select")
                .Select(x => x.Text)
                .ToArray();

            return days;
        }

        public void SelectDay(string day)
        {
            var daySelect = new SelectElement(this.dayDropdown);
            daySelect.SelectByText(day);
        }

        public string GetDayStatusText()
        {
            return this.dayStatusParagraph.Text;
        }

        public void ClickState(string state, bool holdLeftControl = false)
        {
            var stateSelect = new SelectElement(this.stateMultiSelect);

            if (holdLeftControl)
            {
                var actions = new Actions(this.driver);
                actions.KeyDown(Keys.LeftControl);

                var stateElement = stateSelect.Options.FirstOrDefault(x => x.Text == state);
                if (stateElement == null)
                {
                    throw new Exception($"No such state: {state}");
                }

                actions.Click(stateElement);
                actions.KeyUp(Keys.LeftControl);
                actions.Perform();
            }
            else
            {
                stateSelect.SelectByText(state);
            }
        }

        public string GetStateStatusText()
        {
            return this.stateStatusParagraph.Text;
        }

        public void ClickFirstSelectedButton()
        {
            this.firstSelectedButton.Click();
        }

        public void ClickGetAllSelectedButton()
        {
            this.getAllSelectedButton.Click();
        }

        #endregion Interaction
    }
}
