using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class CheckboxTests
    {
        [Fact]
        public void SingleCheckbox_CheckedConfirmationTextIsDisplayed()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var checkboxPage = new CheckboxPage(driver);
                checkboxPage.NavigateTo();

                // Click checkbox
                checkboxPage.ClickSingleCheckbox();

                // Verify if confirmation text got displayed
                Assert.True(checkboxPage.HasSingleCheckboxCheckedText());
                Assert.Equal("Success - Check box is checked", checkboxPage.GetSingleCheckboxCheckedText());
            }
        }

        [Fact]
        public void MultipleCheckbox_AllOptionsUncheckedByDefault()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var checkboxPage = new CheckboxPage(driver);
                checkboxPage.NavigateTo();

                // Read all checkbox options
                var options = checkboxPage.GetMutlipleCheckboxOptions();

                // Verify if all options are unchecked
                foreach (var singleOption in options)
                {
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.False(isChecked);
                }
            }
        }

        [Fact]
        public void MultipleCheckbox_SomeOptionsGetCheckedAndUnchecked()
        {
            using (var driver = new ChromeDriver())
            {
                // Arrange
                var options = new string[] { "Option 1", "Option 2" };

                // Go to page
                var checkboxPage = new CheckboxPage(driver);
                checkboxPage.NavigateTo();

                // Verify if tested options are unchecked
                foreach (var singleOption in options)
                {
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.False(isChecked);
                }

                // Click tested options and verfify if they got checked 
                foreach (var singleOption in options)
                {
                    checkboxPage.ClickMultipleCheckboxOption(singleOption);
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.True(isChecked);
                }

                // Click tested options again and verfify if they got unchecked 
                foreach (var singleOption in options)
                {
                    checkboxPage.ClickMultipleCheckboxOption(singleOption);
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.False(isChecked);
                }
            }
        }

        [Fact]
        public void MultipleCheckbox_AllOptionsCheckedAndUncheckedOneByOne()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var checkboxPage = new CheckboxPage(driver);
                checkboxPage.NavigateTo();

                // Verify if all options are unchecked
                var allOptions = checkboxPage.GetMutlipleCheckboxOptions();
                foreach (var singleOption in allOptions)
                {
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.False(isChecked);
                }

                // Check all options
                foreach (var singleOption in checkboxPage.GetMutlipleCheckboxOptions())
                {
                    checkboxPage.ClickMultipleCheckboxOption(singleOption);
                }

                // Verify if all options got checked and button text got updated
                foreach (var singleOption in checkboxPage.GetMutlipleCheckboxOptions())
                {
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.True(isChecked);
                }
                Assert.Equal("Uncheck All", checkboxPage.GetCheckAllUncheckAllButtonText());

                // Uncheck all options
                foreach (var singleOption in checkboxPage.GetMutlipleCheckboxOptions())
                {
                    checkboxPage.ClickMultipleCheckboxOption(singleOption);
                }

                // Verify if all options got unchecked and button text got updated
                foreach (var singleOption in checkboxPage.GetMutlipleCheckboxOptions())
                {
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.False(isChecked);
                }
                Assert.Equal("Check All", checkboxPage.GetCheckAllUncheckAllButtonText());
            }
        }

        [Fact]
        public void MultipleCheckbox_AllOptionsCheckedAndUncheckedAtOnceUsingButton()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var checkboxPage = new CheckboxPage(driver);
                checkboxPage.NavigateTo();

                // Verify if all options are unchecked
                var allOptions = checkboxPage.GetMutlipleCheckboxOptions();
                foreach (var singleOption in allOptions)
                {
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.False(isChecked);
                }

                // Check all options
                checkboxPage.ClickCheckAllUncheckAllButton();

                // Verify if all options got checked and button text got updated
                foreach (var singleOption in checkboxPage.GetMutlipleCheckboxOptions())
                {
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.True(isChecked);
                }
                Assert.Equal("Uncheck All", checkboxPage.GetCheckAllUncheckAllButtonText());

                // Uncheck all options
                checkboxPage.ClickCheckAllUncheckAllButton();

                // Verify if all options got unchecked and button text got updated
                foreach (var singleOption in checkboxPage.GetMutlipleCheckboxOptions())
                {
                    var isChecked = checkboxPage.IsMultipleCheckboxOptionChecked(singleOption);
                    Assert.False(isChecked);
                }
                Assert.Equal("Check All", checkboxPage.GetCheckAllUncheckAllButtonText());
            }
        }
    }
}
