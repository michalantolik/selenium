﻿using OpenQA.Selenium;
using SeleniumEasy.FunctionalTests.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class CheckboxPage
    {
        private IWebDriver driver;

        private const string PageUrl = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        private const string PageTitle = "Selenium Easy - Checkbox demo for automation using selenium";

        public CheckboxPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        #region Elements

        private IWebElement singleCheckbox => this.driver.FindElement(By.Id("isAgeSelected"));
        private By singleCheckboxCheckedLocator => By.Id("txtAge");
        private bool hasSingleCheckoxCheckedText => this.driver.HasElement(singleCheckboxCheckedLocator);
        private IWebElement singleCheckoxCheckedText => this.driver.FindElement(singleCheckboxCheckedLocator);

        private IReadOnlyCollection<IWebElement> multipleCheckboxDivElements => this.driver.FindElements(
            By.XPath(
                "//div[text()='Multiple Checkbox Demo']" +
                "/following-sibling::div" +
                "/div[@class='checkbox']"
            )
        );
        private IWebElement checkAllUncheckAllButton => this.driver.FindElement(By.Id("check1"));

        #endregion Elements


        #region Interaction

        public void NavigateTo()
        {
            this.driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoaded();
        }

        public void ClickSingleCheckbox()
        {
            this.singleCheckbox.Click();
        }

        public bool HasSingleCheckboxCheckedText()
        {
            return this.hasSingleCheckoxCheckedText;
        }

        public string GetSingleCheckboxCheckedText()
        {
            return this.singleCheckoxCheckedText.Text;
        }

        public string[] GetMutlipleCheckboxOptions()
        {
            return this.multipleCheckboxDivElements.Select(x => x.Text).ToArray();
        }

        public bool IsMultipleCheckboxOptionChecked(string option)
        {
            var checkbox = this.multipleCheckboxDivElements
                               .FirstOrDefault(x => x.Text == option)
                               .FindElement(By.TagName("input"));

            if (checkbox == null)
            {
                throw new Exception($"No such checkbox option: {option}");
            }
            return checkbox.Selected;
        }

        public void ClickMultipleCheckboxOption(string option)
        {
            var checkbox = this.multipleCheckboxDivElements
                               .FirstOrDefault(x => x.Text == option)
                               .FindElement(By.TagName("input"));

            if (checkbox == null)
            {
                throw new Exception($"No such checkbox option: {option}");
            }
            checkbox.Click();
        }

        public string GetCheckAllUncheckAllButtonText()
        {
            var text = this.checkAllUncheckAllButton.GetAttribute("value");
            return text;
        }

        public void ClickCheckAllUncheckAllButton()
        {
            this.checkAllUncheckAllButton.Click();
        }

        private void EnsurePageLoaded()
        {
            bool pageLoaded = this.driver.Url == PageUrl && this.driver.Title == PageTitle;
            if (!pageLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{this.driver.Url}' Page Source: \r\n {this.driver.PageSource}");
            }
        }

        #endregion Interaction
    }
}
