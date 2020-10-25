using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class RadioButtonsTest
    {
        [Fact]
        public void SingleRadioButtonGroup_GetCheckedValue()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var radioButtonsPage = new RadioButtonsPage(driver);
                radioButtonsPage.NavigateTo();

                // Verify that no option is checked by default
                var allOptions = radioButtonsPage.GetSingleRadioButtonsGroupOptions();
                foreach (var singleOption in allOptions)
                {
                    Assert.False(radioButtonsPage.IsSingleRadioButtonsGroupOptionChecked(singleOption));
                }

                // No option is checked -> verify status text
                radioButtonsPage.ClickGetCheckedValueButton();
                Assert.Equal("Radio button is Not checked", radioButtonsPage.GetSingleRadioButtonGroupStatus());

                // "Male" option is checked -> verify status text
                radioButtonsPage.ClickOptionInSingleRadioButtonGroup("Male");
                radioButtonsPage.ClickGetCheckedValueButton();
                Assert.Equal("Radio button 'Male' is checked", radioButtonsPage.GetSingleRadioButtonGroupStatus());

                // "Female" option is checked -> verify status text
                radioButtonsPage.ClickOptionInSingleRadioButtonGroup("Female");
                radioButtonsPage.ClickGetCheckedValueButton();
                Assert.Equal("Radio button 'Female' is checked", radioButtonsPage.GetSingleRadioButtonGroupStatus());
            }
        }

        [Fact]
        public void MultipleRadioButtonGroups_GetValues()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var radioButtonsPage = new RadioButtonsPage(driver);
                radioButtonsPage.NavigateTo();

                // Verify that no options are checked by default
                var genederOptions = radioButtonsPage.GetGenderOptions();
                foreach (var gender in genederOptions)
                {
                    Assert.False(radioButtonsPage.IsGenderOptionChecked(gender));
                }
                var ageGroupOptions = radioButtonsPage.GetAgeGroupOptions();
                foreach (var ageGroup in ageGroupOptions)
                {
                    Assert.False(radioButtonsPage.IsAgeGrouprOptionChecked(ageGroup));
                }

                // No option is checked -> verify status text
                radioButtonsPage.ClickGetValuesButton();
                radioButtonsPage.GetSingleRadioButtonGroupStatus();
                Assert.Equal("Sex :\r\nAge group:", radioButtonsPage.GetMultipleRadioButtonGroupsStatus());

                // "Female" gender, no age group -> verify status text
                radioButtonsPage.ClickGenderOption("Female");
                radioButtonsPage.ClickGetValuesButton();
                radioButtonsPage.GetSingleRadioButtonGroupStatus();
                Assert.Equal("Sex : Female\r\nAge group:", radioButtonsPage.GetMultipleRadioButtonGroupsStatus());

                // "Female" gender, "15 to 30" age group -> verify status text
                radioButtonsPage.ClickAgeGroupOption("15 - 50");
                radioButtonsPage.ClickGetValuesButton();
                radioButtonsPage.GetSingleRadioButtonGroupStatus();
                Assert.Equal("Sex : Female\r\nAge group: 15 - 50", radioButtonsPage.GetMultipleRadioButtonGroupsStatus());
            }
        }
    }
}
