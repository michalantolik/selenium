using OpenQA.Selenium;
using SeleniumEasy.FunctionalTests.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class RadioButtonsPage : Page
    {
        protected override string pageUrl => "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
        protected override string pageTitle => "Selenium Easy Demo - Radio buttons demo for Automation";

        public RadioButtonsPage(IWebDriver driver) : base(driver) { }


        #region Elements

        private IReadOnlyCollection<IWebElement> singleGroupRadioButtons => this.driver.FindElements(By.Name("optradio"));
        private IWebElement getCheckedValueButton => this.driver.FindElement(By.XPath("//button[text()='Get Checked value']"));
        private IWebElement singleRadioButtonGroupStatusParagraph => this.driver.FindElement(By.ClassName("radiobutton"));

        private IReadOnlyCollection<IWebElement> genederRadioButtons => this.driver.FindElements(By.Name("gender"));
        private IReadOnlyCollection<IWebElement> ageGroupRadioButtons => this.driver.FindElements(By.Name("ageGroup"));
        private IWebElement getValuesButtons => this.driver.FindElement(By.XPath("//button[text()='Get values']"));
        private IWebElement multipleRadioButtonGroupsStatusParagraph => this.driver.FindElement(By.ClassName("groupradiobutton"));

        #endregion Elements


        #region Interaction

        public string[] GetSingleRadioButtonsGroupOptions()
        {
            return this.singleGroupRadioButtons.Select(x => x.GetAttribute("value")).ToArray();
        }

        public bool IsSingleRadioButtonsGroupOptionChecked(string option)
        {
            var radiobutton = this.singleGroupRadioButtons.FirstOrDefault(x => x.GetAttribute("value") == option);
            if (radiobutton == null)
            {
                throw new Exception($"No such checkbox option: {option}");
            }
            return radiobutton.Selected;
        }

        public void ClickOptionInSingleRadioButtonGroup(string option)
        {
            var radiobutton = this.singleGroupRadioButtons.FirstOrDefault(x => x.GetAttribute("value") == option);
            if (radiobutton == null)
            {
                throw new Exception($"No such checkbox option: {option}");
            }
            radiobutton.Click();
        }

        public string GetSingleRadioButtonGroupStatus()
        {
            return this.singleRadioButtonGroupStatusParagraph.Text;
        }

        public void ClickGetCheckedValueButton()
        {
            this.getCheckedValueButton.Click();
        }

        public string[] GetGenderOptions()
        {
            return this.genederRadioButtons.Select(x => x.GetAttribute("value")).ToArray();
        }

        public string[] GetAgeGroupOptions()
        {
            return this.ageGroupRadioButtons.Select(x => x.GetAttribute("value")).ToArray();
        }

        public bool IsGenderOptionChecked(string option)
        {
            var radiobutton = this.genederRadioButtons.FirstOrDefault(x => x.GetAttribute("value") == option);
            if (radiobutton == null)
            {
                throw new Exception($"No such checkbox option: {option}");
            }
            return radiobutton.Selected;
        }

        public bool IsAgeGrouprOptionChecked(string option)
        {
            var radiobutton = this.ageGroupRadioButtons.FirstOrDefault(x => x.GetAttribute("value") == option);
            if (radiobutton == null)
            {
                throw new Exception($"No such checkbox option: {option}");
            }
            return radiobutton.Selected;
        }

        public void ClickGenderOption(string option)
        {
            var radiobutton = this.genederRadioButtons.FirstOrDefault(x => x.GetAttribute("value") == option);
            if (radiobutton == null)
            {
                throw new Exception($"No such checkbox option: {option}");
            }
            radiobutton.Click();
        }

        public void ClickAgeGroupOption(string option)
        {
            var radiobutton = this.ageGroupRadioButtons.FirstOrDefault(x => x.GetAttribute("value") == option);
            if (radiobutton == null)
            {
                throw new Exception($"No such checkbox option: {option}");
            }
            radiobutton.Click();
        }

        public string GetMultipleRadioButtonGroupsStatus()
        {
            return this.multipleRadioButtonGroupsStatusParagraph.Text;
        }

        public void ClickGetValuesButton()
        {
            this.getValuesButtons.Click();
        }

        #endregion Interaction
    }
}
