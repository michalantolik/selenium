using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class SimpleFormTests
    {
        [Fact]
        public void SingleInputField_MessageIsDisplayed()
        {
            using (var driver = new ChromeDriver())
            {
                var simpleFormPage = new SimpleFormPage(driver);
                simpleFormPage.NavigateTo();
                simpleFormPage.SetMessage("Hello world!");
                simpleFormPage.ClickShowMessage();
                Assert.Equal("Hello world!", simpleFormPage.GetYourMessageText());
            }
        }

        [Fact]
        public void TwoInputFields_SumIsDisplayed()
        {
            using (var driver = new ChromeDriver())
            {
                var simpleFormPage = new SimpleFormPage(driver);
                simpleFormPage.NavigateTo();
                simpleFormPage.SetValueA("2");
                simpleFormPage.SetValueB("3");
                simpleFormPage.ClickGetTotal();
                Assert.Equal("5", simpleFormPage.GetTotalValueText());
            }
        }
    }
}
