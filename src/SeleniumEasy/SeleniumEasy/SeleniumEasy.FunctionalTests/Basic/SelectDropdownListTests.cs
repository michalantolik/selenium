using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class SelectDropdownListTests
    {
        [Fact]
        public void SingleSelectList_SelectDay()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var dropdownListPage = new SelectDropdownListPage(driver);
                dropdownListPage.NavigateTo();

                // No day selected -> verify status text
                Assert.Equal($"", dropdownListPage.GetDayStatusText());

                // Select each day one by one -> verify status text
                var days = dropdownListPage.GetDays();
                foreach (var day in days)
                {
                    dropdownListPage.SelectDay(day);
                    Assert.Equal($"Day selected :- {day}", dropdownListPage.GetDayStatusText());
                }
            }
        }

        [Fact]
        public void MultiSelectList_SelectState()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var dropdownListPage = new SelectDropdownListPage(driver);
                dropdownListPage.NavigateTo();

                // No states selected -> verify status text
                dropdownListPage.ClickFirstSelectedButton();
                Assert.Equal("First selected option is : undefined", dropdownListPage.GetStateStatusText());

                dropdownListPage.ClickGetAllSelectedButton();
                Assert.Equal("Options selected are :", dropdownListPage.GetStateStatusText());

                // Select "Ohio" -> verify status text
                dropdownListPage.ClickState("Ohio");
                dropdownListPage.ClickFirstSelectedButton();
                Assert.Equal("First selected option is : Ohio", dropdownListPage.GetStateStatusText());
                dropdownListPage.ClickGetAllSelectedButton();
                Assert.Equal("Options selected are : Ohio", dropdownListPage.GetStateStatusText());

                // Select "Texas" -> verify status text
                dropdownListPage.ClickState("Texas", holdLeftControl: true);
                dropdownListPage.ClickFirstSelectedButton();
                Assert.Equal("First selected option is : Ohio", dropdownListPage.GetStateStatusText());
                dropdownListPage.ClickGetAllSelectedButton();
                Assert.Equal("Options selected are : Ohio,Texas", dropdownListPage.GetStateStatusText());

                // Select "Florida" -> verify status text
                dropdownListPage.ClickState("Florida", holdLeftControl: true);
                dropdownListPage.ClickFirstSelectedButton();
                Assert.Equal("First selected option is : Ohio", dropdownListPage.GetStateStatusText());
                dropdownListPage.ClickGetAllSelectedButton();
                Assert.Equal("Options selected are : Ohio,Texas,Florida", dropdownListPage.GetStateStatusText());
            }
        }
    }
}
